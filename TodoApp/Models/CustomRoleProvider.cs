using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace TodoApp.Models
{
    public class CustomRoleProvider : RoleProvider
    {
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

        // 追加実装
        public override string[] GetRolesForUser(string username)
        {
            // 固定で設定する
            //if ("administrator".Equals(username))
            //{
            //    return new string[] { "Administrator" };
            //}

            //return new string[] { "Users" };

            using (var db = new TodoesContext())
            {
                var user = db.Users
                    .Where(u => u.UserName == username)
                    .FirstOrDefault();　//ヒットすれば最初のユーザーを返す。

                if (user != null)
                {
                    // ヒット成功
                    return user.Roles.Select(role => role.RoleName).ToArray();
                }
            }

            // ヒットなしの場合、空を返す。											
            return new string[] { };
        }


        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        // 追加実装
        public override bool IsUserInRole(string username, string roleName)
        {
            // 固定で設定する
            //if ("administrator".Equals(username) && "Administrators".Equals(roleName))
            //{
            //    return true;
            //}

            //if ("user".Equals(username) && "User".Equals(roleName))
            //{
            //    return true;
            //}
            //return false;

            //using (var db = new TodoesContext())
            //{
            //    var user = db.Users
            //        .Where(u => u.UserName == username)
            //        .FirstOrDefault();　//ヒットすれば最初のユーザーを返す。

            //    if (user != null)
            //    {
            //        // ヒット成功
            //        string[] roles = user.Roles.Select(r => r.RoleName).ToArray();
            //        return roles.Contains(roleName);
            //    }
            //}

            string[] roles = this.GetRolesForUser(username);
            return roles.Contains(roleName);

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