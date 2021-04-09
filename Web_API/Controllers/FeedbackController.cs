using BLL.BLL_Client;
using Model.DTO.DTO_Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Web_API.Controllers
{
    [RoutePrefix("api/Feedback")]
    public class FeedbackController : ApiController
    {
        BLL_Feedback bLL_Feedback = new BLL_Feedback();
        BLL_Home bll_home = new BLL_Home();
        [Route("Create")]
        public bool Create(DTO_Feedback dTO_Account)
        {
            return bLL_Feedback.InsertFeedback(dTO_Account);
        }
        [Route("getallfeedbacks")]
        public JsonResult<List<DTO_Feedback>> getallfeedbacks ()
        {
            return Json<List<DTO_Feedback>>(bll_home.GetAllFeedbacks());
        }
    }
}
