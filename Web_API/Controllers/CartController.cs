using BLL.BLL_Client;
using Model.DTO.DTO_Ad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_API.Controllers
{
    [RoutePrefix("api/Cart")]
    public class CartController : ApiController
    {

        BLL_Cart bLL_Cart = new BLL_Cart();
        [Route("InsertCKCustomer")]
        public bool InsertCKCustomer(DTO_Checkout_Customer dTO_Account)
        {
            return bLL_Cart.InsertCheckoutCustomer(dTO_Account);
        }
        [Route("InsertCKOrder")]
        public bool InsertCKOrder(DTO_Checkout_Order dTO_Account)
        {
            return bLL_Cart.InsertCheckoutOrder(dTO_Account);
        }
    }
}
