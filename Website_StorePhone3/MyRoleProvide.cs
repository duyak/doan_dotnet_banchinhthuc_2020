using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using Website_StorePhone3.Models.db;

namespace Website_StorePhone3
{
    public class MyRoleProvide : RoleProvider
    {
        private int timeout = 1;
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            //check cache
            var cachekey = string.Format("{0}_role", username);
            if (HttpRuntime.Cache[cachekey] != null)
            {
                return (string[])HttpRuntime.Cache[cachekey]; 
            }
            string[] roles = new string[]{};
            using (dotnetstorephoneEntities1 p = new dotnetstorephoneEntities1())
            {
                 roles = (from a in p.roles
                             join b in p.roleusers on a.id equals b.roleId
                             join c in p.users on b.userId equals c.id
                             where c.username.Equals(username)
                             select a.roleName).ToArray<string>();
                if (roles.Count() > 0)
                {
                    HttpRuntime.Cache.Insert(cachekey, roles, null, DateTime.Now.AddMinutes(timeout), Cache.NoSlidingExpiration);

                }
            }
            return roles;

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var userRoles = GetRolesForUser(username);
            return userRoles.Contains(roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}