using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL_Ad
{
    public class DAL_Checkout_Customer
    {
        private OnlineShopEntities db = new OnlineShopEntities();

        // GET: Admin/Admin_acc
        public List<Checkout_Customer> GetAllAccounts()
        {
            //bool item = db.Items.Select(t => t.Id_SanPham == 11).SingleOrDefault();

            return db.Checkout_Customer.ToList();

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

        public Checkout_Customer GetAccountById(int id)
        {
            return db.Checkout_Customer.Where(s => s.Id_KH == id).FirstOrDefault();
        }
        public List<Checkout_Customer> GetListAccountById(int id)
        {
            return db.Checkout_Customer.Where(s => s.Id_KH == id).ToList();
        }

        // GET: Admin/Admin_acc/Details/5




        public bool Edit(Checkout_Customer account)
        {

            // Account acc = db.Accounts.Where(s => s.idUser == account.idUser).FirstOrDefault();
            var acc = GetAccountById(account.Id_KH);
            if (acc != null)
            {
                acc.Id_KH = account.Id_KH;
                acc.FirstName = account.FirstName;
                acc.Email = account.Email;
                acc.LastName = account.LastName;
                //acc.NgayTao = account.NgayTao;
                acc.SDT = account.SDT;
                acc.TongTien = account.TongTien;
                acc.TrangThai = account.TrangThai;
                acc.Zipcode = account.Zipcode;
                acc.GiamGia = account.GiamGia;
                acc.DiaChi = account.DiaChi;

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
                Checkout_Customer account = db.Checkout_Customer.Find(id);
                db.Checkout_Customer.Remove(account);
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
