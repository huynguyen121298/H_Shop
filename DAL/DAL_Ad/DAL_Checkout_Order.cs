using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL_Ad
{
   public class DAL_Checkout_Order
    {
        private OnlineShopEntities db = new OnlineShopEntities();

        // GET: Admin/Admin_acc
        public List<Checkout_Oder> GetAllAccounts()
        {
            //bool item = db.Items.Select(t => t.Id_SanPham == 11).SingleOrDefault();

            return db.Checkout_Oder.ToList();

        }

        //public List<Account_Role> GetAllAccounts2()
        //{
        //    //bool item = db.Items.Select(t => t.Id_SanPham == 11).SingleOrDefault();

        //    var accountInfo = from account in db.Accounts
        //                      join role in db.Roles on account.RoleId equals role.RoleId
        //                      select new Account_Role()
        //                      {
        //                          idUser = account.idUser,
        //                          FirstName = account.FirstName,
        //                          LastName = account.LastName,
        //                          RoleName = role.RoleName
        //                      };
        //    return accountInfo.ToList();

        //}

        public Checkout_Oder GetAccountById(int id)
        {
            return db.Checkout_Oder.Where(s => s.ID == id).FirstOrDefault();
        }

        // GET: Admin/Admin_acc/Details/5




        public bool Edit(Checkout_Oder account)
        {

            // Account acc = db.Accounts.Where(s => s.idUser == account.idUser).FirstOrDefault();
            var acc = GetAccountById(account.ID);
            if (acc != null)
            {
                acc.Id_KH = account.Id_KH;
                acc.ID = account.ID;
                acc.Id_SanPham = account.Id_SanPham;
                acc.SoLuong = account.SoLuong;
               // acc.NgayTao = account.NgayTao;
                acc.TenSP = account.TenSP;
                acc.TrangThai = account.TrangThai;
               
                acc.Gia = account.Gia;
                

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
                Checkout_Oder account = db.Checkout_Oder.Find(id);
                db.Checkout_Oder.Remove(account);
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
