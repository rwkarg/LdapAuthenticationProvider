﻿using Octopus.Data.Resources;
using Octopus.Data.Resources.Attributes;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;
using System.ComponentModel;

namespace Octopus.Server.Extensibility.Authentication.Ldap.Configuration
{
    public class LdapConfigurationResource : ExtensionConfigurationResource
    {
        public const string ServerDescription = "Set the server URL.";
        public const string PortDescription = "Set the port using to connect.";
        public const string UsernameDescription = "Set the user DN to query LDAP.";
        public const string PasswordDescription = "Set the password to query LDAP.";
        public const string BaseDnDescription = "Set the root distinguished name (DN) to query LDAP.";
        public const string DefaultDomainDescription = "Set the default domain when none is given in the logon form. Optional.";
        public const string UserFilterDescription = "The filter to use when searching valid users.";
        public const string GroupFilterDescription = "The filter to use when searching valid user groups.";


        [DisplayName("Server")]
        [Description(ServerDescription)]
        [Writeable]
        public string Server { get; set; }

        [DisplayName("Port")]
        [Description(PortDescription)]
        [Writeable]
        public int Port { get; set; }

        [DisplayName("Username")]
        [Description(UsernameDescription)]
        [Writeable]
        public string ConnectUsername { get; set; }

        [DisplayName("Password")]
        [Description(PasswordDescription)]
        [Writeable]
        public SensitiveValue ConnectPassword { get; set; }

        [DisplayName("Base DN")]
        [Description(BaseDnDescription)]
        [Writeable]
        public string BaseDN { get; set; }

        [DisplayName("Default Domain")]
        [Description(DefaultDomainDescription)]
        [Writeable]
        public string DefaultDomain { get; set; }

        [DisplayName("User Filter")]
        [Description(UserFilterDescription)]
        [Writeable]
        public string UserFilter { get; set; }

        [DisplayName("Group Filter")]
        [Description(GroupFilterDescription)]
        [Writeable]
        public string GroupFilter { get; set; }

        [DisplayName("Attribute Mapping")]
        public LdapMappingConfigurationResource AttributeMapping { get; set; } = new LdapMappingConfigurationResource();
    }

    public class LdapMappingConfigurationResource
    {
        public const string UserNameAttributeDescription = "Set the name of the LDAP attribute containing the username, which is used to authenticate via the logon form.";
        public const string UserDisplayNameAttributeDescription = "Set the name of the LDAP attribute containing the user's full name.";
        public const string UserPrincipalNameAttributeDescription = "Set the name of the LDAP attribute containing the user's principal name.";
        public const string UserMembershipAttributeDescription = "Set the name of the LDAP attribute to use when loading the user's groups.";
        public const string UserEmailAttributeDescription = "Set the name of the LDAP attribute containing the user's email address.";
        public const string GroupNameAttributeDescription = "Set the name of the LDAP attribute containing the group's name.";

        [DisplayName("Username Attribute")]
        [Description(UserNameAttributeDescription)]
        [Writeable]
        public string UserNameAttribute { get; set; }

        [DisplayName("User Display Name Attribute")]
        [Description(UserDisplayNameAttributeDescription)]
        [Writeable]
        public string UserDisplayNameAttribute { get; set; }

        [DisplayName("User Principal Name Attribute")]
        [Description(UserPrincipalNameAttributeDescription)]
        [Writeable]
        public string UserPrincipalNameAttribute { get; set; }

        [DisplayName("User Membership Attribute")]
        [Description(UserMembershipAttributeDescription)]
        [Writeable]
        public string UserMembershipAttribute { get; set; }

        [DisplayName("User Email Attribute")]
        [Description(UserEmailAttributeDescription)]
        [Writeable]
        public string UserEmailAttribute { get; set; }

        [DisplayName("Group Name Attribute")]
        [Description(GroupNameAttributeDescription)]
        [Writeable]
        public string GroupNameAttribute { get; set; }
    }
}