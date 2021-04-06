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
    [RoutePrefix("api/checkout_customer")]
    public class Checkout_CustomerController : ApiController
    {

        BLL_Checkout_Customer bLL_checkout_acc = new BLL_Checkout_Customer();
        // GET: api/Admin_acc
      
       

        // PUT: api/Admin_acc/5
        [Route("Update")]
        public bool Update(DTO_Checkout_Customer dTO_Account)
        {
            return bLL_checkout_acc.Update_Ad_acc(dTO_Account);
        }

        // DELETE: api/Admin_acc/5
        [Route("DeleteCustomer/{id:int}")]
        public bool DeleteCustomer(int id)
        {
            return bLL_checkout_acc.DeleteAccount(id);
        }
        [HttpGet]
        [Route("GetAllCustomer")]
        public JsonResult<List<DTO_Checkout_Customer>> GetAllCustomer()
        {
            return Json<List<DTO_Checkout_Customer>>(bLL_checkout_acc.GetAllAccounts());
        }
        //[HttpGet]
        //[Route("GetAllAccounts2")]
        //public JsonResult<List<DTO_Account_Role>> GetAllAccounts2()
        //{
        //    return Json<List<DTO_Account_Role>>(bLL_checkout_acc.GetAllAccounts2());
        //}
        [HttpGet]
        [Route("GetCustomerById/{Id:int}")]
        public JsonResult<DTO_Checkout_Customer> GetCustomerById(int Id)
        {
            return Json<DTO_Checkout_Customer>(bLL_checkout_acc.GetAccountById(Id));
        }
        [HttpGet]
        [Route("GetListCustomerById/{Id:int}")]
        public JsonResult <List<DTO_Checkout_Customer>> GetListCustomerById(int Id)
        {
            return Json<List<DTO_Checkout_Customer>>(bLL_checkout_acc.GetListAccountById(Id));
        }
    }
}
