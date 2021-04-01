using BLL.BLL_Client;
using Model.DTO.DTO_Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_API.Controllers
{
    [RoutePrefix("api/Feedback")]
    public class FeedbackController : ApiController
    {
        BLL_Feedback bLL_Feedback = new BLL_Feedback();
        [Route("Create")]
        public bool Create(DTO_Feedback dTO_Account)
        {
            return bLL_Feedback.InsertFeedback(dTO_Account);
        }
    }
}
