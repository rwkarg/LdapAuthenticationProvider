﻿using Octopus.Data.Model;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Authentication.Ldap.Configuration
{
    public class LdapConfiguration : ExtensionConfigurationDocument
    {
        public LdapConfiguration() : base("Ldap", "Thomas Unger", "1.0")
        {
            Id = LdapConfigurationStore.SingletonId;
        }

        public string Server { get; set; }

        public int Port { get; set; } = 389;

        public string ConnectUsername { get; set; }

        [Encrypted]
        public string ConnectPassword { get; set; }

        public string BaseDn { get; set; }

        public string DefaultDomain { get; set; }

        public string UserFilter { get; set; } = "(&(objectClass=person)(sAMAccountName=*))";

        public string GroupFilter { get; set; } = "(&(objectClass=group)(cn=*))";

        public LdapMappingConfiguration AttributeMapping { get; set; } = new LdapMappingConfiguration();
    }

    public class LdapMappingConfiguration
    { 
        public string UserNameAttribute { get; set; } = "sAMAccountName";

        public string UserDisplayNameAttribute { get; set; } = "displayName";

        public string UserPrincipalNameAttribute { get; set; } = "userPrincipalName";

        public string UserMembershipAttribute { get; set; } = "memberOf";

        public string UserEmailAttribute { get; set; } = "mail";

        public string GroupNameAttribute { get; set; } = "cn";
    }
}