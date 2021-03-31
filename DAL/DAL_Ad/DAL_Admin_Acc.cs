using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DAL.DAL_Model;
using DAL.EF;

namespace DAL.DAL_Ad
{
    public class DAL_Admin_Acc
    {
        private OnlineShopEntities db = new OnlineShopEntities();

        // GET: Admin/Admin_acc
        public List<Account> GetAllAccounts()
        {
            //bool item = db.Items.Select(t => t.Id_SanPham == 11).SingleOrDefault();
           
            return db.Accounts.ToList();
            
        }

        public List<Account_Role> GetAllAccounts2()
        {
            //bool item = db.Items.Select(t => t.Id_SanPham == 11).SingleOrDefault();

            var accountInfo = from account in db.Accounts
                              join role in db.Roles on account.RoleId equals role.RoleId
                              select new Account_Role()
                              {
                                  idUser = account.idUser,
                                  FirstName = account.FirstName,
                                  LastName = account.LastName,
                                  RoleName = role.RoleName
                              };
            return accountInfo.ToList();

        }

        public Account GetAccountById(int id)
        {
            return db.Accounts.Where(s=>s.idUser==id).FirstOrDefault();
        }

        // GET: Admin/Admin_acc/Details/5
      

        public bool Create(Account account)
        {
            
            try 
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                 return true;
            }
            catch 
            {
                return false;
            }

        }

   
       
        public bool Edit( Account account)
        {
            
                // Account acc = db.Accounts.Where(s => s.idUser == account.idUser).FirstOrDefault();
                var acc = GetAccountById(account.idUser);
                if(acc!= null)
                {
                acc.idUser = account.idUser;
                acc.FirstName = account.FirstName;
                acc.Email = account.Email;
                acc.LastName = account.LastName;
                acc.Password = account.Password;
                acc.RoleId = account.RoleId;
               
                    db.SaveChanges();
                    return true;
                }


                    
                
          
                return false;
            

           
           
        }

        // GET: Admin/Admin_acc/Delete/5
      
        public bool DeleteAccount(int id)
        {
            try
            {
                Account account = db.Accounts.Find(id);
                db.Accounts.Remove(account);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
           
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
