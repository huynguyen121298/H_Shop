using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Common;
using DAL.DAL_Model;

namespace DAL.DAL_Ad
{
    public class DAL_Account
    {
        OnlineShopEntities db = new OnlineShopEntities();
        public  Account RegisterToAccountAdmin(Account registerAccount)
        {
            if (registerAccount != null)
            {
                var check = db.Accounts.FirstOrDefault(s => s.Email == registerAccount.Email);
                if(check == null)
                {
                    Account userAccount = new Account();
                    userAccount.idUser = registerAccount.idUser;
                    userAccount.Password = Encryptor.MD5Hash(registerAccount.Password);
                    userAccount.LastName = registerAccount.LastName;
                    userAccount.FirstName = registerAccount.FirstName;
                    userAccount.Email = registerAccount.Email;
                   
                    return userAccount;
                }
               
            }
            return null;
        }
        public bool UserNameIsExist(string userName)
        {
           
            var account = db.Accounts.Where(t => t.Email == userName).SingleOrDefault();
            if (account != null)
                return true;
            return false;
        }
        public bool AccountIsExist(string userName, string password)
        {
            string encryptPassword = Encryptor.MD5Hash(password);
            var account = db.Accounts.Where(t => t.Email == userName && t.Password == encryptPassword).SingleOrDefault();
            if (account != null)
                return true;
            return false;
        }
        public bool InsertUserAccount(Account custom)
        {
            if (!UserNameIsExist(custom.Email) && custom != null)
            {
                try
                {
                    custom.Password = Encryptor.MD5Hash(custom.Password);
                    db.Accounts.Add(custom);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }
        public Account Login( string user,string pass)
        {

            string hash = Encryptor.MD5Hash(pass);
            var cus = db.Accounts.FirstOrDefault(x => x.Email == user & x.Password == hash);
            if (cus != null)
                return new Account { Email = cus.Email, LastName = cus.LastName, FirstName = cus.FirstName, idUser = cus.idUser,RoleId=cus.RoleId };
            return new Account();


           
        }
        public bool UpdateCustomer(Account custom)
        {
            try
            {
                var userAccount = GetCustomerByID(custom.idUser);
                if (userAccount != null)
                {


                    userAccount.idUser = custom.idUser;
                    userAccount.Password = Encryptor.MD5Hash(custom.Password);
                    userAccount.LastName = custom.LastName;
                    userAccount.FirstName = custom.FirstName;
                    userAccount.Email = custom.Email;

                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Account GetCustomerByID(int id)
        {
            return db.Accounts.Where(t => t.idUser == id).FirstOrDefault();
        }
        public Account GetCustomerByEmail(string email)
        {
            return db.Accounts.Where(t => t.Email == email).FirstOrDefault();
        }
        public bool UpdatePassword(UpdateAccount updateAccount)
        {
            int result = -1;
          
            using (var transaction = db.Database.BeginTransaction())
            {
                string encryptPassword = Encryptor.MD5Hash(updateAccount.Password);
                var account = db.Accounts.Where(t => t.Email == updateAccount.Email && t.Password == encryptPassword).FirstOrDefault();
                if (account != null)
                {
                    try
                    {
                        account.Password = Encryptor.MD5Hash(updateAccount.NewPassword);
                        //account.UpdateBy = "User";
                        //account.UpdateTime = DateTime.Now;
                        //account.Role = 1;

                        result = db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception )
                    {
                        transaction.Rollback();
                    }
                }
            }
            if (result >= 1)
                return true;
            return false;
        }
        public bool DeleteCustomer(int id)
        {
            try
            {
                var itemDelete = GetCustomerByID(id);
                if (itemDelete != null)
                {
                    db.Accounts.Remove(itemDelete);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ResetPassword(string username, string password)
        {
            int result = -1;
           
            using (var transaction = db.Database.BeginTransaction())
            {
                var account = db.Accounts.Where(t => t.Email == username).FirstOrDefault();
                if (account != null)
                {
                    try
                    {
                        account.Password = Encryptor.MD5Hash(password);
                        //account.UpdateBy = "User";
                        //account.UpdateTime = DateTime.Now;
                        //account.Role = 1;

                        result = db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception )
                    {
                        transaction.Rollback();
                    }
                }
            }
            if (result >= 1)
                return true;
            return false;
        }
    }
}
