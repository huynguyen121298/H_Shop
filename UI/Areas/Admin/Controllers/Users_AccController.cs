using Model.DTO.DTO_Ad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using UI.Service;

namespace UI.Areas.Admin.Controllers
{
    public class Users_AccController : Controller
    {
        ServiceRepository service = new ServiceRepository();

        // GET: Admin/Admin_acc
        public ActionResult Index()
        {


            HttpResponseMessage responseMessage = service.GetResponse("api/User_acc/getallaccounts");
            responseMessage.EnsureSuccessStatusCode();
            List<DTO_User_Acc> DTO_User_Accs = responseMessage.Content.ReadAsAsync<List<DTO_User_Acc>>().Result;
            return View(DTO_User_Accs);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ServiceRepository service = new ServiceRepository();
            HttpResponseMessage responseMessage = service.GetResponse("api/User_acc/GetAccountById/" + id);
            responseMessage.EnsureSuccessStatusCode();
            DTO_User_Acc dtoAccounts = responseMessage.Content.ReadAsAsync<DTO_User_Acc>().Result;

            return View(dtoAccounts);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            ServiceRepository service = new ServiceRepository();
            HttpResponseMessage responseMessage = service.GetResponse("api/User_acc/GetAccountById/" + id);
            responseMessage.EnsureSuccessStatusCode();
            DTO_User_Acc dtoAccounts = responseMessage.Content.ReadAsAsync<DTO_User_Acc>().Result;

            return View(dtoAccounts);
        }
        [HttpPost]
        public ActionResult Edit(DTO_User_Acc DTO_User_Acc)
        {

            HttpResponseMessage response = service.PostResponse("api/User_acc/Update/", DTO_User_Acc);
            response.EnsureSuccessStatusCode();


            return RedirectToAction("Index");
        }
       
    
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here


                HttpResponseMessage response = service.DeleteResponse("api/User_Acc/DeleteAccount/" + id);
                response.EnsureSuccessStatusCode();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
