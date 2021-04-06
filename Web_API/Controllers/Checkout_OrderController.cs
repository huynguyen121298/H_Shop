using BLL.BLL_Ad;
using Model.DTO.DTO_Ad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Web_API.Controllers
{
    [RoutePrefix("api/Checkout_Order")]
    public class Checkout_OrderController : ApiController
    {

        BLL_Checkout_Order bLL_checkout_acc = new BLL_Checkout_Order();
        // GET: api/Admin_acc



        // PUT: api/Admin_acc/5
        [Route("Update")]
        public bool Update(DTO_Checkout_Order dTO_Account)
        {
            return bLL_checkout_acc.Update_Ad_acc(dTO_Account);
        }

        // DELETE: api/Admin_acc/5
        [Route("DeleteOrder/{id:int}")]
        public bool DeleteOrder(int id)
        {
            return bLL_checkout_acc.DeleteAccount(id);
        }
        [HttpGet]
        [Route("GetAllOrder")]
        public JsonResult<List<DTO_Checkout_Order>> GetAllOrder()
        {
            return Json<List<DTO_Checkout_Order>>(bLL_checkout_acc.GetAllAccounts());
        }
        //[HttpGet]
        //[Route("GetAllAccounts2")]
        //public JsonResult<List<DTO_Account_Role>> GetAllAccounts2()
        //{
        //    return Json<List<DTO_Account_Role>>(bLL_checkout_acc.GetAllAccounts2());
        //}
        [HttpGet]
        [Route("GetOrderById/{Id:int}")]
        public JsonResult<DTO_Checkout_Order> GetOrderById(int Id)
        {
            return Json<DTO_Checkout_Order>(bLL_checkout_acc.GetAccountById(Id));
        }
        [HttpGet]
        [Route("GetOrderByIdKH/{Id:int}")]
        public JsonResult<DTO_Checkout_Order> GetOrderByIdKH(int Id)
        {
            return Json<DTO_Checkout_Order>(bLL_checkout_acc.GetAccountByIdKH(Id));
        }
        [HttpGet]
        [Route("GetListOrderById/{Id:int}")]
        public JsonResult<List<DTO_Checkout_Order>> GetListOrderById(int Id)
        {
            return Json<List<DTO_Checkout_Order>>(bLL_checkout_acc.GetListAccountById(Id));
        }
    }
}
