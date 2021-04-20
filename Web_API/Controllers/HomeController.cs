using BLL.BLL_Client;
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
    [RoutePrefix("api/Home")]
    public class HomeController : ApiController
    {
        BLL_Home bLL_Home = new BLL_Home();
        [HttpGet]
        [Route("GetAllItemType")]
        public JsonResult<List<DTO_Item_Type>> GetAllItemType()
        {
            return Json<List<DTO_Item_Type>>(bLL_Home.GetAllItemType());
        }
    }
}
