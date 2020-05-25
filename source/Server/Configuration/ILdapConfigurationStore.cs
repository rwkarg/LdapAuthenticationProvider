﻿using Octopus.Data.Model;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Authentication.Ldap.Configuration
{
    public interface ILdapConfigurationStore : IExtensionConfigurationStore<LdapConfiguration>
    {
        string GetServer();

        void SetServer(string server);

        int GetPort();

        void SetPort(int port);

        string GetConnectUsername();

        void SetConnectUsername(string username);

        string GetConnectPassword();

        void SetConnectPassword(string password);

        string GetBaseDn();

        void SetBaseDn(string baseDn);

        string GetDefaultDomain();

        void SetDefaultDomain(string defaultDomain);

        string GetUserNameAttribute();

        void SetUserNameAttribute(string userNameAttribute);

        string GetUserFilter();

        void SetUserFilter(string userFilter);

        string GetGroupFilter();

        void SetGroupFilter(string groupFilter);

        string GetUserDisplayNameAttribute();

        void SetUserDisplayNameAttribute(string userDisplayNameAttribute);

        string GetUserPrincipalNameAttribute();

        void SetUserPrincipalNameAttribute(string userPrincipalNameAttribute);

        string GetUserMembershipAttribute();

        void SetUserMembershipAttribute(string userMembershipAttribute);

        string GetUserEmailAttribute();

        void SetUserEmailAttribute(string userEmailAttribute);

        string GetGroupNameAttribute();

        void SetGroupNameAttribute(string groupNameAttribute);
    }
}