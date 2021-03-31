using Model.DTO.DTO_Ad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using UI.Service;

namespace UI.Areas.Admin.Controllers
{
    public class Products_AddController : Controller
    {
        ServiceRepository service = new ServiceRepository();
        // GET: Admin/Products_Add
        public ActionResult Index()
        {

            HttpResponseMessage responseMessage = service.GetResponse("api/Products_Ad/getallproducts");
            responseMessage.EnsureSuccessStatusCode();
            List<DTO_Product> dTO_Accounts = responseMessage.Content.ReadAsAsync<List<DTO_Product>>().Result;
            return View(dTO_Accounts);
        }

        // GET: Admin/Products_Add/Details/5
        public ActionResult Details(int Id)
        {
            HttpResponseMessage responseMessage = service.GetResponse("api/Products_Ad/GetProductById/"+Id);
            responseMessage.EnsureSuccessStatusCode();
            DTO_Product dTO_Accounts = responseMessage.Content.ReadAsAsync<DTO_Product>().Result;
            return View(dTO_Accounts);
        }

        // GET: Admin/Products_Add/Create
        public ActionResult Create()
        {
            DTO_Product pro = new DTO_Product();
            return View(pro);
        }
       

        
        public string ProcessUpload(HttpPostedFileBase file)
        {


            file.SaveAs(Server.MapPath("~/images_product/" + file.FileName));

            return "/images_product/" + file.FileName;
        }

        // POST: Admin/Products_Add/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, DTO_Product product,DTO_Item item, HttpPostedFileBase ImageUpload)
        {
            try
            {
                if (ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(ImageUpload.FileName);
                    string extension = Path.GetExtension(ImageUpload.FileName);
                    fileName = fileName + extension;
                    product.Photo = "~/images_product/" + fileName;
                    ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/images_product/"), fileName));
                }
                var idSP = Request.Form["idSP"];
                item.Id_SanPham = Convert.ToInt32(idSP);
                product.Id_SanPham = Convert.ToInt32(idSP);
                product.Photo = Request.Form["ImageUpload"];
                HttpResponseMessage responseUser = service.PostResponse("api/Products_Ad/CreateProduct/" ,product);
                responseUser.EnsureSuccessStatusCode();
                HttpResponseMessage responseUser1 = service.PostResponse("api/Products_Ad/CreateItem/", item);
                responseUser1.EnsureSuccessStatusCode();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Products_Add/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Products_Add/Edit/5
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

        // GET: Admin/Products_Add/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Admin/Products_Add/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here


                HttpResponseMessage response = service.DeleteResponse("api/Products_Ad/DeleteProduct/" + id);
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
