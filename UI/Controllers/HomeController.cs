using log4net;
using Model.DTO.DTO_Ad;
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
        ServiceRepository service = new ServiceRepository();

        //private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string userName;
        public ActionResult Index()
        {
            HttpResponseMessage responseUser = service.GetResponse("api/Home/GetAllItemType" );

            responseUser.EnsureSuccessStatusCode();
            List<DTO_Item_Type> result = responseUser.Content.ReadAsAsync<List<DTO_Item_Type>>().Result;
            //List<DTO_Item_Type> dTO_Item_Types = new List<DTO_Item_Type>();
            //DTO_Item_Type dTO_Item_Type = new DTO_Item_Type() { Id_Item = 1, Type_Product = "Type 001" };
            //DTO_Item_Type dTO_Item_Type2 = new DTO_Item_Type() { Id_Item = 2, Type_Product = "Type 002" };
            //DTO_Item_Type dTO_Item_Type3 = new DTO_Item_Type() { Id_Item = 3, Type_Product = "Type 003" };
            //DTO_Item_Type dTO_Item_Type4 = new DTO_Item_Type() { Id_Item = 4, Type_Product = "Type 004" };
            //dTO_Item_Types.Add(dTO_Item_Type);
            //dTO_Item_Types.Add(dTO_Item_Type2);
            //dTO_Item_Types.Add(dTO_Item_Type3);
            //dTO_Item_Types.Add(dTO_Item_Type4);
            return View(result);
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
                ViewData["ErrorMessageFeedback"]=("Gửi phản hồi thành công");
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
                ViewData["ErrorMessageFeedback"]=("Gửi phản hồi thành công");
                return View("~/Product/Details");
            }
            catch
            {
                return View("~/Views/Shared/Error_");
            }


        }
        [HttpPost]
        public ActionResult saveFeedbacksYeuThich(FormCollection fc, DTO_Feedback fb)
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
                ViewData["ErrorMessage"]=("Gửi phản hồi thành công");
                return View("~/Cart/YeuThich");
            }
            catch
            {
                return View("~/Views/Shared/Error_");
            }


        }
        public ActionResult saveFeedbacksLuaChon(FormCollection fc, DTO_Feedback fb)
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
                ViewData["ErrorMessage"]=("Gửi phản hồi thành công");
                return View("~/Cart/Luachon");
            }
            catch
            {
                return View("~/Views/Shared/Error_");
            }


        }




    }
}
