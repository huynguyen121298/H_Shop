using Model.DTO.DTO_Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using UI.Service;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        ServiceRepository service = new ServiceRepository();
        // GET: Product
        public ActionResult Index()
        {

            HttpResponseMessage responseMessage = service.GetResponse("api/product/getallproducts");
            responseMessage.EnsureSuccessStatusCode();
            List<DTO_Product_Client> dTO_Accounts = responseMessage.Content.ReadAsAsync<List<DTO_Product_Client>>().Result;
            return View(dTO_Accounts);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public PartialViewResult BagCart()
        {



            //    //    int item = 0;
            //    //List<Item> cart = (List<Item>)Session["cart"];
            //    //Item item1 = new Item();

            //    //if (cart != null)
            //    //  item=

            //    try
            //    {
            //        if (Session["cart"] != null)
            //        {
            //            List<Item> cart = (List<Item>)Session["cart"];

            //            int total = cart.Count();
            //            ViewBag.Quantity = total;

            //        }
            //    }
            //    catch
            //    {

            //        ViewBag.Quantity = 0;

            //    }


            //    //ViewBag.Quantity = item;




            return PartialView("BagCart");
        }
        public PartialViewResult BagCart_()
        {



            //    try
            //    {
            //        if (Session["cart_"] != null)
            //        {
            //            List<Item> cart_ = (List<Item>)Session["cart_"];

            //            int total1 = cart_.Count();
            //            ViewBag.yeuthich = total1;

            //        }
            //    }
            //    catch
            //    {

            //        ViewBag.yeuthich = 0;

            //    }

            //    //ViewBag.Quantity = item;




            return PartialView("BagCart_");
        }

    }
}
