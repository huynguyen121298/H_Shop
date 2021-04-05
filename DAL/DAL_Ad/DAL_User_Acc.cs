using DAL.Common;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL_Ad
{
    public class DAL_User_Acc
    {
        private OnlineShopEntities db = new OnlineShopEntities();

        // GET: Admin/Admin_acc
        public List<Users_Acc> GetAllAccounts()
        {
            //bool item = db.Items.Select(t => t.Id_SanPham == 11).SingleOrDefault();

            return db.Users_Acc.ToList();

        }
        public Users_Acc GetAccountById(int id)
        {
            return db.Users_Acc.Where(s => s.idUser == id).FirstOrDefault();
        }

        // GET: Admin/Admin_acc/Details/5
        public bool Edit(Users_Acc account)
        {

            // Account acc = db.Accounts.Where(s => s.idUser == account.idUser).FirstOrDefault();
            var acc = GetAccountById(account.idUser);
            if (acc != null)
            {
                acc.idUser = account.idUser;
                acc.FirstName = account.FirstName;
                acc.Email = account.Email;
                acc.LastName = account.LastName;
                acc.Password = Encryptor.MD5Hash(account.Password); 
                //acc.RoleId = account.RoleId;

                db.SaveChanges();
                return true;
            }





            return false;




        }

        public bool Create(Users_Acc account)
        {

            try
            {
                db.Users_Acc.Add(account);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool DeleteAccount(int id)
        {
            try
            {
                Users_Acc account = db.Users_Acc.Find(id);
                db.Users_Acc.Remove(account);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
