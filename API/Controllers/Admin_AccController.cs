using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using BLL.BLL_Ad;
using Model.DTO.DTO_Ad;

namespace API.Controllers
{  
    [RoutePrefix("api/Admin_Acc")]
    public class Admin_AccController : ApiController
    {
        BLL_Admin_Acc bLL_Admin_Acc = new BLL_Admin_Acc();
        // GET: api/Admin_Acc
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Admin_Acc/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Admin_Acc
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Admin_Acc/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Admin_Acc/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("getAllAccount")]
        public JsonResult<List<DTO_Account>> GetALLAccount()
        {
            return Json<List<DTO_Account>>(bLL_Admin_Acc.GetAllAccounts());
        }
    }
}
