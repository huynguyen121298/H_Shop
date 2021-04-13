using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL_Client
{
    public class DAL_Cart
    {
        OnlineShopEntities db = new OnlineShopEntities();
        public bool InsertCheckoutCustomer(Checkout_Customer ck)
        {
            try
            {
                db.Checkout_Customer.Add(ck);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertCheckoutOrder(Checkout_Oder cO)
        {
            try
            {
                db.Checkout_Oder.Add(cO);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int InsertBill(Checkout_Customer ck, List<Checkout_Oder> cO)
        {
            //bool status;

            using (var transaction = db.Database.BeginTransaction())
            {
                db.Checkout_Customer.Add(ck);
                db.SaveChanges();
                foreach(var item in cO)
                {
                    item.Id_KH = ck.Id_KH;
                    db.Checkout_Oder.Add(item);
                }
                




                try
                {
                    int result = db.SaveChanges();
                    transaction.Commit();
                    return result;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return -2;
                }
            }
        }

            public double GetGiamGia(string zipcode) {
            var list_temp = db.CodeDiscounts.ToList();
            var temp = db.CodeDiscounts.Where(s => s.Zipcode==zipcode).FirstOrDefault();
            if(temp != null)
            {
                return (double)temp.Discount; // vidu: 0.3 0.4
            }
            return 0;

         }
    }
}
