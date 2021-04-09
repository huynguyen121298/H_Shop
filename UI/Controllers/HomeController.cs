using log4net;
using Model.DTO.DTO_Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;
using UI.Service;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        
        //private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string userName;
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult saveFeedbacks(FormCollection fc, DTO_Feedback fb)
        {

            try
            {
              
                fb.Name = fc["Name"];
                fb.Email = fc["Email"];
                fb.Details = fc["details"];
                fb.SDT = (fc["SDT"]);
                fb.Content = fc["content"];
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Feedback/Create/",fb);
                response.EnsureSuccessStatusCode();
                return View("Index");
            }
            catch
            {
                return View("~/Views/Shared/Error_");
            }


        }
        [HttpPost]
        public ActionResult saveFeedbacks2(FormCollection fc, DTO_Feedback fb)
        {

            try
            {

                fb.Name = fc["Name"];
                fb.Email = fc["Email"];
                fb.Details = fc["details"];
                fb.SDT = (fc["SDT"]);
                fb.Content = fc["content"];
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Feedback/Create/", fb);
                response.EnsureSuccessStatusCode();
                return View("~/Product/Details");
            }
            catch
            {
                return View("~/Views/Shared/Error_");
            }


        }




    }
}