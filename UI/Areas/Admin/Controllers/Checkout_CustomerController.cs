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
    public class Checkout_CustomerController : Controller
    {
        ServiceRepository service = new ServiceRepository();

        // GET: Admin/Checkout_Customer
        public ActionResult Index(string seachby)
        {


            var timkiemtim = Request.Form["timkiemtim"];

            
            if (seachby == "id")
            {
                HttpResponseMessage responseMessage1 = service.GetResponse("api/Checkout_Customer/GetListcustomerById/" + timkiemtim);
                responseMessage1.EnsureSuccessStatusCode();
                List<DTO_Checkout_Customer> dtocustomer = responseMessage1.Content.ReadAsAsync<List<DTO_Checkout_Customer>>().Result;
                return View(dtocustomer);
            }


            else
            {
                HttpResponseMessage responseMessage = service.GetResponse("api/Checkout_Customer/getallcustomer");
                responseMessage.EnsureSuccessStatusCode();
                List<DTO_Checkout_Customer> DTO_Checkout_Customers = responseMessage.Content.ReadAsAsync<List<DTO_Checkout_Customer>>().Result;
                return View(DTO_Checkout_Customers);
                
            }
                   


        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ServiceRepository service = new ServiceRepository();
            HttpResponseMessage responseMessage = service.GetResponse("api/Checkout_Customer/GetcustomerById/" + id);
            responseMessage.EnsureSuccessStatusCode();
            DTO_Checkout_Customer dtocustomer = responseMessage.Content.ReadAsAsync<DTO_Checkout_Customer>().Result;

            return View(dtocustomer);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            ServiceRepository service = new ServiceRepository();
            HttpResponseMessage responseMessage = service.GetResponse("api/Checkout_Customer/GetCustomerById/" + id);
            responseMessage.EnsureSuccessStatusCode();
            DTO_Checkout_Customer dtocustomer = responseMessage.Content.ReadAsAsync<DTO_Checkout_Customer>().Result;

            return View(dtocustomer);
        }
        [HttpPost]
        public ActionResult Edit(DTO_Checkout_Customer DTO_Checkout_Customer)
        {
            DTO_Checkout_Customer.TrangThai = Request.Form["stt"];
            

            HttpResponseMessage response = service.PostResponse("api/Checkout_Customer/Update/", DTO_Checkout_Customer);
            response.EnsureSuccessStatusCode();


            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {


            return View();

        }
        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(DTO_Checkout_Customer dtoProduct)
        {
            try
            {
                // TODO: Add insert logic here

                //HttpResponseMessage responseMessage = service.PostResponse("api/Checkout_Customer/Create/", dtoProduct);
                //responseMessage.EnsureSuccessStatusCode();
                return RedirectToAction("getAllcustomer");
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
        //    HttpResponseMessage responseMessage = service.GetResponse("api/Checkout_Customer/GetCustomerById/" + id);
        //    responseMessage.EnsureSuccessStatusCode();
        //    DTO_Checkout_Customer dtocustomer = responseMessage.Content.ReadAsAsync<DTO_Checkout_Customer>().Result;

        //    return View(dtocustomer);
        //}

        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                
                HttpResponseMessage responseMessage = service.GetResponse("api/Checkout_Order/GetOrderByIdKH/" + id);
                responseMessage.EnsureSuccessStatusCode();
                DTO_Checkout_Order dtoOrder = responseMessage.Content.ReadAsAsync<DTO_Checkout_Order>().Result;
                if (dtoOrder == null)
                {
                    HttpResponseMessage response = service.DeleteResponse("api/Checkout_Customer/Deletecustomer/" + id);
                    response.EnsureSuccessStatusCode();


                    return Json(new { mes = true });
                }
                else
                {
                    ViewBag.Mess = "Không thể xóa vì khách hàng đang còn đơn đặt hàng";
                    return Json(new { mes = false });
                }
               

               
            }
            catch
            {
                ViewBag.Mess = "Có lỗi ngoài ý muốn, vui lòng kiểm tra lại";
                return Json(new { mes = false });
            }
        }
    }
}
