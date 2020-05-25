﻿using Octopus.Data.Model;
using Octopus.Diagnostics;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;
using System;
using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Authentication.Ldap.Configuration
{
    public class LdapConfigureCommands : IContributeToConfigureCommand
    {
        private readonly ILog log;
        private readonly Lazy<ILdapConfigurationStore> ldapConfiguration;

        public LdapConfigureCommands(
            ILog log,
            Lazy<ILdapConfigurationStore> ldapConfiguration)
        {
            this.log = log;
            this.ldapConfiguration = ldapConfiguration;
        }

        public IEnumerable<ConfigureCommandOption> GetOptions()
        {
            yield return new ConfigureCommandOption("ldapIsEnabled=", "Set whether ldap is enabled.", v =>
            {
                var isEnabled = bool.Parse(v);
                ldapConfiguration.Value.SetIsEnabled(isEnabled);
                log.Info($"LDAP IsEnabled set to: {isEnabled}");
            });
            yield return new ConfigureCommandOption("ldapServer=", LdapConfigurationResource.ServerDescription, v =>
            {
                ldapConfiguration.Value.SetServer(v);
                log.Info($"LDAP Server set to: {v}");
            });
            yield return new ConfigureCommandOption("ldapPort=", LdapConfigurationResource.PortDescription, v =>
            {
                int.TryParse(v, out var port);
                ldapConfiguration.Value.SetPort(port);
                log.Info("LDAP Port set to: " + port);
            });
            yield return new ConfigureCommandOption("ldapUsername=", LdapConfigurationResource.UsernameDescription, v =>
            {
                ldapConfiguration.Value.SetConnectUsername(v);
                log.Info("LDAP Username set to: " + v);
            });
            yield return new ConfigureCommandOption("ldapPassword=", LdapConfigurationResource.PasswordDescription, v =>
            {
                ldapConfiguration.Value.SetConnectPassword(v);
                log.Info("LDAP Password set");
            });
            yield return new ConfigureCommandOption("ldapBaseDn=", LdapConfigurationResource.BaseDnDescription, v =>
            {
                ldapConfiguration.Value.SetBaseDn(v);
                log.Info("LDAP Base DN set");
            });
            yield return new ConfigureCommandOption("ldapDefaultDomain=", LdapConfigurationResource.DefaultDomainDescription, v =>
            {
                ldapConfiguration.Value.SetDefaultDomain(v);
                log.Info("LDAP Default Domain set");
            });
            yield return new ConfigureCommandOption("ldapSamAccountNameAttribute=", LdapMappingConfigurationResource.UserNameAttributeDescription, v =>
            {
                ldapConfiguration.Value.SetUserNameAttribute(v);
                log.Info("LDAP SamAccountNameAttribute set to: " + v);
            });
            yield return new ConfigureCommandOption("ldapUserFilter=", LdapConfigurationResource.UserFilterDescription, v =>
            {
                ldapConfiguration.Value.SetUserFilter(v);
                log.Info("LDAP User Filter set to: " + v);
            });
            yield return new ConfigureCommandOption("ldapGroupFilter=", LdapConfigurationResource.GroupFilterDescription, v =>
            {
                ldapConfiguration.Value.SetGroupFilter(v);
                log.Info("LDAP Group Filter set to: " + v);
            });
            yield return new ConfigureCommandOption("ldapUserDisplayNameAttribute=", LdapMappingConfigurationResource.UserDisplayNameAttributeDescription, v =>
            {
                ldapConfiguration.Value.SetUserDisplayNameAttribute(v);
                log.Info("LDAP UserDisplayNameAttribute set to: " + v);
            });
            yield return new ConfigureCommandOption("ldapUserPrincipalNameAttribute=", LdapMappingConfigurationResource.UserPrincipalNameAttributeDescription, v =>
            {
                ldapConfiguration.Value.SetUserPrincipalNameAttribute(v);
                log.Info("LDAP UserPrincipalNameAttribute set to: " + v);
            });
            yield return new ConfigureCommandOption("ldapUserMembershipAttribute=", LdapMappingConfigurationResource.UserMembershipAttributeDescription, v =>
            {
                ldapConfiguration.Value.SetUserMembershipAttribute(v);
                log.Info("LDAP UserMembershipAttribute set to: " + v);
            });
            yield return new ConfigureCommandOption("ldapUserEmailAttribute=", LdapMappingConfigurationResource.UserEmailAttributeDescription, v =>
            {
                ldapConfiguration.Value.SetUserEmailAttribute(v);
                log.Info("LDAP UserEmailAttribute set to: " + v);
            });
            yield return new ConfigureCommandOption("ldapGroupNameAttribute=", LdapMappingConfigurationResource.GroupNameAttributeDescription, v =>
            {
                ldapConfiguration.Value.SetGroupNameAttribute(v);
                log.Info("LDAP GroupNameAttribute set to: " + v);
            });
        }
    }
}