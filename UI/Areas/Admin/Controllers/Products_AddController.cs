using Model.DTO.DTO_Ad;
using Model.DTO_Model;
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
        public ActionResult Index(DTO_Product dTO_Product)
        {
            try
            {
                HttpResponseMessage responseMessage = service.GetResponse("api/Products_Ad/getallproducts");
                responseMessage.EnsureSuccessStatusCode();
                List<DTO_Product> dTO_Accounts = responseMessage.Content.ReadAsAsync<List<DTO_Product>>().Result;
                return View(dTO_Accounts);
            }
            catch
            {
                return View(dTO_Product);
            }

           
        }
        public ActionResult GetAllProductByType()
        {

            HttpResponseMessage responseMessage = service.GetResponse("api/Products_Ad/GetAllProductByType");
            responseMessage.EnsureSuccessStatusCode();
            List<List<DTO_Product>> dTO_Accounts = responseMessage.Content.ReadAsAsync<List<List<DTO_Product>>>().Result;
            return View(dTO_Accounts);
        }
        public ActionResult Index2(int id)
        {
           


            HttpResponseMessage responseMessage = service.GetResponse("api/Products_Ad/GetAllProductByIdItem/"+id);
            responseMessage.EnsureSuccessStatusCode();
            List<DTO_Product> dTO_Accounts = responseMessage.Content.ReadAsAsync<List<DTO_Product>>().Result;
            return View(dTO_Accounts);
        }



        // GET: Admin/Products_Add/Details/5
        public ActionResult Details(int Id)
        {
            HttpResponseMessage responseMessage = service.GetResponse("api/Products_Ad/GetProductItemById/"+Id);
            responseMessage.EnsureSuccessStatusCode();
            DTO_Product_Item_Type dTO_Accounts = responseMessage.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;
            return View(dTO_Accounts);
        }

        // GET: Admin/Products_Add/Create
        public ActionResult Create()
        {
            DTO_Product_Item_Type pro = new DTO_Product_Item_Type();
            return View(pro);
        }
       

        
        public string ProcessUpload(HttpPostedFileBase file)
        {


            file.SaveAs(Server.MapPath("~/images_product/" + file.FileName));

            return "/images_product/" + file.FileName;
        }

        // POST: Admin/Products_Add/Create
       
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(FormCollection collection, DTO_Product_Item_Type dTO_Product_Item_Type, HttpPostedFileBase ImageUpload)
        {
            
            string Id = dTO_Product_Item_Type.Photo;
            //DTO_Product_Item_Type dTO_Product_Item_Type = new DTO_Product_Item_Type();
            var stt = Request.Form["stt"];
            if (stt == "Đồng hồ")
            {
                dTO_Product_Item_Type.Id_Item = 1;

               
            }
            if (stt == "Máy ảnh và máy quay phim")
            {
                dTO_Product_Item_Type.Id_Item = 2;


            }
            if (stt == "Máy tính và laptop")
            {
                dTO_Product_Item_Type.Id_Item = 3;


            }
            if (stt == "Mẹ và bé")
            {
                dTO_Product_Item_Type.Id_Item = 4;


            }
            if (stt == "Sức khỏe và sắc đẹp")
            {
                dTO_Product_Item_Type.Id_Item = 5;


            }
            if (stt == "Thể thao và du lịch")
            {
                dTO_Product_Item_Type.Id_Item = 6;



            }
            if (stt == "Thiết bị gia dụng")
            {
                dTO_Product_Item_Type.Id_Item = 7;


            }
            if (stt == "Thời trang nam")
            {
                dTO_Product_Item_Type.Id_Item = 8;


            }
            if (stt == "Thời trang nữ")
            {
                dTO_Product_Item_Type.Id_Item = 9;


            }

          



            try
            {
                if (ImageUpload != null)
                {
                    //HttpResponseMessage responseMessage = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                    //responseMessage.EnsureSuccessStatusCode();
                    //DTO_Product_Item_Type dTO_Accounts = responseMessage.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

                    ////DTO_Product dTO_Product = new DTO_Product();
                    ////dTO_Product.Id_SanPham = Id;
                    //if (dTO_Accounts == null)
                    //{
                    string fileName = Path.GetFileNameWithoutExtension(ImageUpload.FileName);
                    string extension = Path.GetExtension(ImageUpload.FileName);
                    fileName = fileName + extension;
                    dTO_Product_Item_Type.Photo = "~/images_product/" + fileName;
                    ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/images_product/"), fileName));
                    //var idSP = Request.Form["id"];
                    //var quantity = Request.Form["sl"];
                    //dTO_Product_Item_Type.Id_SanPham = Convert.ToInt32(idSP);
                    //dTO_Product_Item_Type.Details = Request.Form["details"];



                    //dTO_Product_Item_Type.Quantity = Convert.ToInt32(quantity);
                    HttpResponseMessage responseUser = service.PostResponse("api/Products_Ad/CreateProduct/", dTO_Product_Item_Type);

                    responseUser.EnsureSuccessStatusCode();
                        //HttpResponseMessage responseUser1 = service.PostResponse("api/Products_Ad/CreateItem/", item);
                    //}
                    //else
                    //{
                    //    ViewData["ErrorMessage1"] = "Hình ảnh Sản phẩm đã có rồi, vui lòng chọn mã sản phẩm khác";
                    //    return View(dTO_Product_Item_Type);
                    //}



                }
                else
                {
                    ViewData["ErrorMessage"] = "Bạn chưa chọn hình ảnh cho sản phẩm";
                    return View(dTO_Product_Item_Type);
                }

                return RedirectToAction("Index");

            }
            catch
            {
                ViewData["ErrorMessage2"] = "Hình ảnh sản phẩm đã tổn tại,vui lòng chọn hình ảnh khác";
                return View(dTO_Product_Item_Type);
            }
        }

        // GET: Admin/Products_Add/Edit/5
        public ActionResult Edit(int Id)
        {
            ServiceRepository service = new ServiceRepository();
            HttpResponseMessage responseMessage = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
            responseMessage.EnsureSuccessStatusCode();
            DTO_Product_Item_Type dtoAccounts = responseMessage.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

            return View(dtoAccounts);
        }

        // POST: Admin/Products_Add/Edit/5
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection collection, DTO_Product_Item_Type dTO_Product_Item_Type, HttpPostedFileBase ImageUpload)
        {
            var stt = Request.Form["stt"];
            if (stt == "Đồng hồ")
            {
                dTO_Product_Item_Type.Id_Item = 1;


            }
            if (stt == "Máy ảnh và máy quay phim")
            {
                dTO_Product_Item_Type.Id_Item = 2;


            }
            if (stt == "Máy tính và laptop")
            {
                dTO_Product_Item_Type.Id_Item = 3;


            }
            if (stt == "Mẹ và bé")
            {
                dTO_Product_Item_Type.Id_Item = 4;


            }
            if (stt == "Sức khỏe và sắc đẹp")
            {
                dTO_Product_Item_Type.Id_Item = 5;


            }
            if (stt == "Thể thao và du lịch")
            {
                dTO_Product_Item_Type.Id_Item = 6;



            }
            if (stt == "Thiết bị gia dụng")
            {
                dTO_Product_Item_Type.Id_Item = 7;


            }
            if (stt == "Thời trang nam")
            {
                dTO_Product_Item_Type.Id_Item = 8;


            }
            if (stt == "Thời trang nữ")
            {
                dTO_Product_Item_Type.Id_Item = 9;


            }





            try
            {
                if (ModelState.IsValid)
                {
                    
                    if (ImageUpload != null)
                    {

                        string fileName = Path.GetFileNameWithoutExtension(ImageUpload.FileName);
                        string extension = Path.GetExtension(ImageUpload.FileName);
                        fileName = fileName + extension;
                        ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/images_product/"), fileName));
                        dTO_Product_Item_Type.Photo = "~/images_product/" + fileName;
                        //dTO_Product_Item_Type.Details = Request.Form["details"];

                        //dTO_Product_Item_Type.Quantity = Convert.ToInt32(quantity);
                        HttpResponseMessage responseUser = service.PostResponse("api/Products_Ad/UpdateProduct/", dTO_Product_Item_Type);

                        responseUser.EnsureSuccessStatusCode();
                        //var idSP = Request.Form["id"];
                        //var quantity = Request.Form["sl"];
                        //dTO_Product_Item_Type.Id_SanPham = Convert.ToInt32(idSP);

                        //HttpResponseMessage responseUser1 = service.PostResponse("api/Products_Ad/CreateItem/", item);

                    }
                    else
                    {
                        //dTO_Product_Item_Type.Details = Request.Form["details"];

                        //dTO_Product_Item_Type.Quantity = Convert.ToInt32(quantity);
                        HttpResponseMessage responseUser = service.PostResponse("api/Products_Ad/UpdateProduct/", dTO_Product_Item_Type);

                        responseUser.EnsureSuccessStatusCode();
                    }
                  
                   
                }
               














          


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


                // return RedirectToAction("Index");
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
