using BLL.BLL_Ad;
using log4net;
using Model.DTO.DTO_Ad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_API.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        BLL_Account bll_acc = new BLL_Account();

        [HttpPut]
        [Route("UpdateAccount")]
        public bool UpdateCustomer(DTO_Account model)
        {
            try
            {
                return bll_acc.UpdateCustomer(model);
            }
            catch (Exception)
            {
                log.Error("Cannot response result");
                throw;
            }
        }
        [HttpPost]
        [Route("InsertAccount")]
        public bool InsertCustomer(DTO_Account cusInsert)
        {
            try
            {
                return bll_acc.InsertCustomer(cusInsert);
            }
            catch (Exception)
            {
                log.Error("Cannot response result");
                throw;
            }
        }
        [HttpGet]
        [Route("GetLoginResultByEmailPassword")]
        public DTO_Account GetLoginResultByEmailPassword(string user, string pass)
        {
            try
            {
                log.Info("Successful to response login result.");
                return bll_acc.LoginCustomer(user, pass);
            }
            catch (Exception)
            {
                log.Error("Cannot response login result.");
                throw;
            }
        }
        [Route("GetAccountById")]
        public DTO_Account GetAccountById(int id)
        {
            try
            {
                return bll_acc.GetCustomerByID(id);
            }
            catch (Exception)
            {
                log.Error("Cannot response result.");
                throw;
            }
        }
        [Route("GetAccountByEmail")]
        public DTO_Account GetAccountByEmail(string email)
        {
            try
            {
                return bll_acc.GetCustomerByEmail(email);
            }
            catch (Exception)
            {
                log.Error("Cannot response result.");
                throw;
            }
        }
    }
}
