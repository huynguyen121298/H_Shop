using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Common;
using DAL.EF;

namespace DAL.DAL_Client
{
    public class DAL_Home
    {
        private OnlineShopEntities db = new OnlineShopEntities();
        public DAL_Home()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        #region CRUD
        public List<Users_Acc> GetAllCustomers()
        {
            return db.Users_Acc.ToList();
        }
        public bool InsertCustomer(Users_Acc custom)
        {
            if (!UserNameIsExist(custom.Email) && custom != null)
            {
                try
                {
                    custom.Password = Encryptor.MD5Hash(custom.Password);
                    db.Users_Acc.Add(custom);
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
        public bool UserNameIsExist(string userName)
        {

            var account = db.Users_Acc.Where(t => t.Email == userName).SingleOrDefault();
            if (account != null)
                return true;
            return false;
        }
        public bool AccountIsExist(string userName, string password)
        {
            string encryptPassword = Encryptor.MD5Hash(password);
            var account = db.Users_Acc.Where(t => t.Email == userName && t.Password == encryptPassword).SingleOrDefault();
            if (account != null)
                return true;
            return false;
        }
        public long InsertForFacebook(Users_Acc model)
        {
            var user = db.Users_Acc.SingleOrDefault(x => x.Email== model.Email);
            if (user == null)
            {
                db.Users_Acc.Add(model);
                db.SaveChanges();
                return model.idUser;
            }
            else
            {
                return user.idUser;
            }
        }
        public long InsertForGoogle(Users_Acc model)
        {
            var user = db.Users_Acc.SingleOrDefault(x => x.Email == model.Email);
            if (user == null)
            {
                db.Users_Acc.Add(model);
                db.SaveChanges();
                return model.idUser;
            }
            else
            {
                return user.idUser;
            }
        }
        public bool DeleteCustomer(int id)
        {
            try
            {
                var itemDelete = GetCustomerByID(id);
                if (itemDelete != null)
                {
                    db.Users_Acc.Remove(itemDelete);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateCustomer(Users_Acc custom)
        {
            try
            {
                var userAccount = GetCustomerByID(custom.idUser);
                if (userAccount != null)
                {
            
                   
                    userAccount.idUser = custom.idUser;
                    //userAccount.Password = Encryptor.MD5Hash(custom.Password);
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
        #endregion

        #region Get Information 
        public Users_Acc GetCustomerByID(int id)
        {
            return db.Users_Acc.Where(t => t.idUser == id).FirstOrDefault();
        }
        //public bool ChangeStatusCustomer(int userID)
        //{
        //    try
        //    {
        //        var acc = db.Users_Acc.SingleOrDefault(x => x.idUser == userID);
        //        acc.Statu = !acc.Statu;
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
        public Users_Acc GetLoginResultByUsernamePassword(string user, string pass)
        {
            //0: Tên đăng nhập hoặc mật khẩu không tồn tại
            //1: Thành công
            string hash = Encryptor.MD5Hash(pass);
            var cus = db.Users_Acc.FirstOrDefault(x => x.Email == user & x.Password == hash);
            if (cus != null)
                return new Users_Acc { Email = cus.Email, LastName = cus.LastName, FirstName = cus.FirstName,idUser=cus.idUser }  ;
            return new Users_Acc();
            //else if (cus.Password != Encryptor.MD5Hash(pass))
            //    return 0;
            //else
            //    return 1;
        }
        public Users_Acc GetCustomerByUsername(string user)
        {
            return db.Users_Acc.SingleOrDefault(t => t.Email == user);
        }
        public Users_Acc GetCustomerByEmail(string mail)
        {
            return db.Users_Acc.FirstOrDefault(t => t.Email == mail);
        }
        #endregion
    }
}
