using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using BLL.BLL_Ad;
using Model.DTO.DTO_Ad;


namespace Web_API.Controllers
{
    [RoutePrefix("api/Admin_Acc")]
    public class Admin_accController : ApiController
    {
        BLL_Admin_Acc bLL_Admin_Acc = new BLL_Admin_Acc();
        // GET: api/Admin_acc
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Admin_acc/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Admin_acc
        [Route("Create")]
        public bool Create (DTO_Account dTO_Account)
        {
            return bLL_Admin_Acc.Create_Ad_acc(dTO_Account);
        }

        // PUT: api/Admin_acc/5
        [Route("Update")]
        public bool Update(DTO_Account dTO_Account)
        {
            return bLL_Admin_Acc.Update_Ad_acc(dTO_Account);
        }

        // DELETE: api/Admin_acc/5
        [Route("DeleteAccount/{id:int}")]
        public bool DeleteAccount(int id)
        {
            return bLL_Admin_Acc.DeleteAccount(id);
        }
        [HttpGet]
        [Route("GetAllAccounts")]
        public JsonResult<List<DTO_Account>> GetAllAccounts()
        {
            return Json<List<DTO_Account>>(bLL_Admin_Acc.GetAllAccounts());
        }
        [HttpGet]
        [Route("GetAllAccounts2")]
        public JsonResult<List<DTO_Account_Role>> GetAllAccounts2()
        {
            return Json<List<DTO_Account_Role>>(bLL_Admin_Acc.GetAllAccounts2());
        }
        [HttpGet]
        [Route("GetAccountById/{Id:int}")]
        public JsonResult<DTO_Account> GetProductById(int Id)
        {
            return Json<DTO_Account>(bLL_Admin_Acc.GetAccountById(Id));
        }
    }
}
