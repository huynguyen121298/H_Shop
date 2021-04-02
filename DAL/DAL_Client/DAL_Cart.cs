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
    }
}
