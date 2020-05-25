﻿using Octopus.Data.Model;
using Octopus.Data.Storage.Configuration;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Authentication.Ldap.Configuration
{
    public class LdapConfigurationStore : ExtensionConfigurationStore<LdapConfiguration>, ILdapConfigurationStore
    {
        public static string SingletonId = "authentication-ldap";

        public LdapConfigurationStore(IConfigurationStore configurationStore) : base(configurationStore)
        {
        }

        public override string Id => SingletonId;

        public string GetServer()
        {
            return GetProperty(doc => doc.Server);
        }

        public void SetServer(string server)
        {
            SetProperty(doc => doc.Server = server);
        }

        public int GetPort()
        {
            return GetProperty(doc => doc.Port);
        }

        public void SetPort(int port)
        {
            SetProperty(doc => doc.Port = port);
        }

        public string GetConnectUsername()
        {
            return GetProperty(doc => doc.ConnectUsername);
        }

        public void SetConnectUsername(string username)
        {
            SetProperty(doc => doc.ConnectUsername = username);
        }

        public string GetConnectPassword()
        {
            return GetProperty(doc => doc.ConnectPassword);
        }

        public void SetConnectPassword(string password)
        {
            SetProperty(doc => doc.ConnectPassword = password);
        }

        public string GetBaseDn()
        {
            return GetProperty(doc => doc.BaseDn);
        }

        public void SetBaseDn(string baseDn)
        {
            SetProperty(doc => doc.BaseDn = baseDn);
        }

        public string GetDefaultDomain()
        {
            return GetProperty(doc => doc.DefaultDomain);
        }

        public void SetDefaultDomain(string defaultDomain)
        {
            SetProperty(doc => doc.DefaultDomain = defaultDomain);
        }

        public string GetUserNameAttribute()
        {
            return GetProperty(doc => doc.AttributeMapping.UserNameAttribute);
        }

        public void SetUserNameAttribute(string samAccountNameAttribute)
        {
            SetProperty(doc => doc.AttributeMapping.UserNameAttribute = samAccountNameAttribute);
        }

        public string GetUserFilter()
        {
            return GetProperty(doc => doc.UserFilter);
        }

        public void SetUserFilter(string userFilter)
        {
            SetProperty(doc => doc.UserFilter = userFilter);
        }

        public string GetGroupFilter()
        {
            return GetProperty(doc => doc.GroupFilter);
        }

        public void SetGroupFilter(string groupFilter)
        {
            SetProperty(doc => doc.GroupFilter = groupFilter);
        }

        public string GetUserDisplayNameAttribute()
        {
            return GetProperty(doc => doc.AttributeMapping.UserDisplayNameAttribute);
        }

        public void SetUserDisplayNameAttribute(string userDisplayNameAttribute)
        {
            SetProperty(doc => doc.AttributeMapping.UserDisplayNameAttribute = userDisplayNameAttribute);
        }

        public string GetUserPrincipalNameAttribute()
        {
            return GetProperty(doc => doc.AttributeMapping.UserPrincipalNameAttribute);
        }

        public void SetUserPrincipalNameAttribute(string userPrincipalNameAttribute)
        {
            SetProperty(doc => doc.AttributeMapping.UserPrincipalNameAttribute = userPrincipalNameAttribute);
        }

        public string GetUserMembershipAttribute()
        {
            return GetProperty(doc => doc.AttributeMapping.UserMembershipAttribute);
        }

        public void SetUserMembershipAttribute(string userMembershipAttribute)
        {
            SetProperty(doc => doc.AttributeMapping.UserMembershipAttribute = userMembershipAttribute);
        }

        public string GetUserEmailAttribute()
        {
            return GetProperty(doc => doc.AttributeMapping.UserEmailAttribute);
        }

        public void SetUserEmailAttribute(string userEmailAttribute)
        {
            SetProperty(doc => doc.AttributeMapping.UserEmailAttribute = userEmailAttribute);
        }

        public string GetGroupNameAttribute()
        {
            return GetProperty(doc => doc.AttributeMapping.GroupNameAttribute);
        }

        public void SetGroupNameAttribute(string groupNameAttribute)
        {
            SetProperty(doc => doc.AttributeMapping.GroupNameAttribute = groupNameAttribute);
        }
    }
}