using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using DAL.EF;


namespace Model.Mapping_Class
{
    public class CustomRoleProvider : RoleProvider
    {
         OnlineShopEntities db = new OnlineShopEntities();
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
            //Account acc = new Account();
            //    //var account = db.Accounts.Where(s => s.RoleId.Equals(username)).ToList();
            //    Account account = db.Accounts.Single(x => x.Email.Equals(username));
            //    //Account account = db.Accounts.Single(x => x.Email.Equals(username));
            //    if (account != null)
            //    {
            //        return new String[] { account.Role.RoleName };
            //    }
            //    else
            //        return new String[] { };
            string data = db.Accounts.Where(x => x.Email == username).FirstOrDefault().Role.RoleName;
            //string data1 = acc.LastName;
            string[] result = { data };
            return result;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
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