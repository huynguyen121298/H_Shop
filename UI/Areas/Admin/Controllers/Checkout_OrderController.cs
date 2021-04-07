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
    public class Checkout_OrderController : Controller
    {

        ServiceRepository service = new ServiceRepository();

        // GET: Admin/Checkout_Order
        public ActionResult Index(string seachby, int? timkiemtim)
        {

            if (seachby == "id")
            {
                HttpResponseMessage responseMessage1 = service.GetResponse("api/Checkout_Customer/GetListOrderById/" + timkiemtim);
                responseMessage1.EnsureSuccessStatusCode();
                List<DTO_Checkout_Order> dtocustomer = responseMessage1.Content.ReadAsAsync<List<DTO_Checkout_Order>>().Result;
                return View(dtocustomer);
            }


            else
            {
                HttpResponseMessage responseMessage = service.GetResponse("api/Checkout_Order/getallOrder");
                responseMessage.EnsureSuccessStatusCode();
                List<DTO_Checkout_Order> DTO_Checkout_Orders = responseMessage.Content.ReadAsAsync<List<DTO_Checkout_Order>>().Result;
                return View(DTO_Checkout_Orders);

            }


           
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ServiceRepository service = new ServiceRepository();
            HttpResponseMessage responseMessage = service.GetResponse("api/Checkout_Order/GetOrderById/" + id);
            responseMessage.EnsureSuccessStatusCode();
            DTO_Checkout_Order dtoOrder = responseMessage.Content.ReadAsAsync<DTO_Checkout_Order>().Result;

            return View(dtoOrder);
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
        public ActionResult Edit(DTO_Checkout_Order DTO_Checkout_Order)
        {
            DTO_Checkout_Order.TrangThai = Request.Form["stt"];
            HttpResponseMessage response = service.PostResponse("api/Checkout_Order/Update/", DTO_Checkout_Order);
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
        public ActionResult Create(DTO_Checkout_Order dtoProduct)
        {
            try
            {
                // TODO: Add insert logic here

                //HttpResponseMessage responseMessage = service.PostResponse("api/Checkout_Order/Create/", dtoProduct);
                //responseMessage.EnsureSuccessStatusCode();
                return RedirectToAction("getAllOrder");
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
        //    HttpResponseMessage responseMessage = service.GetResponse("api/Checkout_Order/GetAccountById/" + id);
        //    responseMessage.EnsureSuccessStatusCode();
        //    DTO_Checkout_Order dtoOrder = responseMessage.Content.ReadAsAsync<DTO_Checkout_Order>().Result;

        //    return View(dtoOrder);
        //}

        public ActionResult Delete(int id)
        {
            //try
            //{
            //    // TODO: Add delete logic here


            //    HttpResponseMessage response = service.DeleteResponse("api/Checkout_Order/DeleteOrder/" + id);
            //    response.EnsureSuccessStatusCode();


            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
            try
            {
                // TODO: Add delete logic here


                HttpResponseMessage response = service.DeleteResponse("api/Checkout_Order/DeleteOrder/" + id);
                response.EnsureSuccessStatusCode();


                return Json(new { mes = true });
            }
            catch
            {
                return Json(new { mes = false });
            }
        }
    }
}
