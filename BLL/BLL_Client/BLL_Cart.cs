using DAL.DAL_Client;
using DAL.EF;
using Model.DTO.DTO_Ad;
using Model.EF_Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Client
{
   public class BLL_Cart
    {
        DAL_Cart dalFb = new DAL_Cart();
        public bool InsertCheckoutCustomer(DTO_Checkout_Customer dTO_Feedback)
        {
            EntityMapper<DTO_Checkout_Customer, Checkout_Customer> mapObj = new EntityMapper<DTO_Checkout_Customer, Checkout_Customer>();
            Checkout_Customer account = mapObj.Translate(dTO_Feedback);
            return dalFb.InsertCheckoutCustomer(account);
        }

        public bool InsertCheckoutOrder(DTO_Checkout_Order dTO_Feedback)
        {
            EntityMapper<DTO_Checkout_Order, Checkout_Oder> mapObj = new EntityMapper<DTO_Checkout_Order, Checkout_Oder>();
            Checkout_Oder account = mapObj.Translate(dTO_Feedback);
            return dalFb.InsertCheckoutOrder(account);
        }
    }
}
