using Novell.Directory.Ldap;
using Octopus.Diagnostics;
using Octopus.Server.Extensibility.Authentication.Extensions;
using Octopus.Server.Extensibility.Authentication.HostServices;
using Octopus.Server.Extensibility.Authentication.Ldap.Configuration;
using Octopus.Server.Extensibility.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Octopus.Server.Extensibility.Authentication.Ldap
{
    public class LdapExternalSecurityGroupLocator : ILdapExternalSecurityGroupLocator
    {
        private readonly ILog log;
        private readonly ILdapContextProvider contextProvider;
        private readonly ILdapObjectNameNormalizer objectNameNormalizer;
        private readonly ILdapConfigurationStore configurationStore;
        private readonly IUserPrincipalFinder userPrincipalFinder;

        public string IdentityProviderName => LdapAuthentication.ProviderName;

        public LdapExternalSecurityGroupLocator(
            ILog log,
            ILdapContextProvider contextProvider,
            ILdapObjectNameNormalizer objectNameNormalizer,
            ILdapConfigurationStore configurationStore,
            IUserPrincipalFinder userPrincipalFinder)
        {
            this.log = log;
            this.contextProvider = contextProvider;
            this.objectNameNormalizer = objectNameNormalizer;
            this.configurationStore = configurationStore;
            this.userPrincipalFinder = userPrincipalFinder;
        }

        public IResultFromExtension<ExternalSecurityGroupResult> Search(string name, CancellationToken cancellationToken)
        {
            if (!configurationStore.GetIsEnabled())
                return ResultFromExtension<ExternalSecurityGroupResult>.ExtensionDisabled();

            var groups = FindGroups(name, cancellationToken);
            var result = new ExternalSecurityGroupResult(groups);

            return ResultFromExtension<ExternalSecurityGroupResult>.Success(result);
        }

        public ExternalSecurityGroup[] FindGroups(string name, CancellationToken cancellationToken)
        {
            var results = new List<ExternalSecurityGroup>();
            string domain;
            string partialGroupName;
            objectNameNormalizer.NormalizeName(name, out partialGroupName, out domain);
            using var context = contextProvider.GetContext();
            var filterToken = $"*{partialGroupName}*";
            var lsc = context.LdapConnection.Search(
                context.BaseDN,
                LdapConnection.ScopeSub,
                context.GroupFilter?.Replace("*", filterToken),
                new[] { context.GroupNameAttribute },
                false
            );
            var searchResults = lsc.ToList();
            results.AddRange(searchResults.Select(x => new ExternalSecurityGroup
            {
                Id = x.Dn,
                DisplayName = x.GetAttribute(context.GroupNameAttribute).StringValue
            }));

            return results.OrderBy(o => o.DisplayName).ToArray();
        }

        public LdapExternalSecurityGroupLocatorResult GetGroupIdsForUser(string username, CancellationToken cancellationToken)
        {
            if (username == null)
                throw new ArgumentNullException(nameof(username), "The username is null, indicating we were not able to associate this Octopus user account with an identifier from LDAP.");

            try
            {
                log.Verbose($"Finding external security groups for '{username}'...");

                objectNameNormalizer.NormalizeName(username, out username, out var domain);

                using var context = contextProvider.GetContext();
                cancellationToken.ThrowIfCancellationRequested();

                var uniqueAccountName = objectNameNormalizer.BuildUserName(username, domain);
                var principal = userPrincipalFinder.FindByIdentity(context, uniqueAccountName);

                if (principal == null)
                {
                    var searchedContext = domain ?? context.BaseDN;
                    log.Trace($"While loading security groups, a principal identifiable by '{uniqueAccountName}' was not found in '{searchedContext}'");
                    return new LdapExternalSecurityGroupLocatorResult();
                }

                cancellationToken.ThrowIfCancellationRequested();

                return new LdapExternalSecurityGroupLocatorResult(principal.Groups.ToList());
            }
            catch (OperationCanceledException)
            {
                return new LdapExternalSecurityGroupLocatorResult();
            }
            catch (Exception ex)
            {
                log.ErrorFormat(ex, "LDAP search for {0} failed.", username);
                return new LdapExternalSecurityGroupLocatorResult();
            }
        }
    }
}