using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using UI.Service;
using Model.DTO.DTO_Ad;
using UI.Security_;

namespace UI.Areas.Admin.Controllers
{
    public class Admin_accController : Controller
    {
        ServiceRepository service = new ServiceRepository();

        // GET: Admin/Admin_acc

        [DeatAuthorize(Order =2)]
        public ActionResult Index()
        {

           
            HttpResponseMessage responseMessage = service.GetResponse("api/Admin_acc/getallaccounts");
            responseMessage.EnsureSuccessStatusCode();
            List<DTO_Account> dTO_Accounts = responseMessage.Content.ReadAsAsync<List<DTO_Account>>().Result;
            return View(dTO_Accounts);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ServiceRepository service = new ServiceRepository();
            HttpResponseMessage responseMessage = service.GetResponse("api/Admin_acc/GetAccountById/" + id);
            responseMessage.EnsureSuccessStatusCode();
            DTO_Account dtoAccounts = responseMessage.Content.ReadAsAsync<DTO_Account>().Result;
            
            return View(dtoAccounts);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            ServiceRepository service = new ServiceRepository();
            HttpResponseMessage responseMessage = service.GetResponse("api/Admin_acc/GetAccountById/" + id);
            responseMessage.EnsureSuccessStatusCode();
            DTO_Account dtoAccounts = responseMessage.Content.ReadAsAsync<DTO_Account>().Result;

            return View(dtoAccounts);
        }
        [HttpPost]
        public ActionResult Edit(DTO_Account dTO_Account)
        {
            var stt = Request.Form["stt"];
            var pass = Request.Form["pass"];
            if (stt == "Admin")
            {
                dTO_Account.RoleId = 1;
                if (pass != "")
                {
                    HttpResponseMessage response = service.PostResponse("api/Admin_acc/Update/", dTO_Account);
                    response.EnsureSuccessStatusCode();
                }
                else
                {

                    HttpResponseMessage response = service.PostResponse("api/Admin_acc/Update2/", dTO_Account);
                    response.EnsureSuccessStatusCode();
                }
                
            }
            else
            {

                dTO_Account.RoleId = 2;
                if (pass != "")
                {
                    HttpResponseMessage response = service.PostResponse("api/Admin_acc/Update/", dTO_Account);
                    response.EnsureSuccessStatusCode();
                }
                else
                {

                    HttpResponseMessage response = service.PostResponse("api/Admin_acc/Update2/", dTO_Account);
                    response.EnsureSuccessStatusCode();
                }
            }

           


            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {


            return View();

        }
        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(DTO_Account dtoProduct)
        {
            try
            {
                // TODO: Add insert logic here

                //HttpResponseMessage responseMessage = service.PostResponse("api/Admin_acc/Create/", dtoProduct);
                //responseMessage.EnsureSuccessStatusCode();
                return RedirectToAction("getAllAccounts");
            }
            catch
            {
                return View();
            }
        }
        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    ServiceRepository service = new ServiceRepository();
        //    HttpResponseMessage responseMessage = service.GetResponse("api/Admin_acc/GetAccountById/" + id);
        //    responseMessage.EnsureSuccessStatusCode();
        //    DTO_Account dtoAccounts = responseMessage.Content.ReadAsAsync<DTO_Account>().Result;

        //    return View(dtoAccounts);
        //}
        
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here


                HttpResponseMessage response = service.DeleteResponse("api/Admin_Acc/DeleteAccount/" + id);
                response.EnsureSuccessStatusCode();


                //return RedirectToAction("Index");
                return Json(new { mes = true });
            }
            catch
            {
                //return View();
                return Json(new { mes = false });
            }
        }
    }
}