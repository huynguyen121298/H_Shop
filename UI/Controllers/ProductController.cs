using Model.DTO.DTO_Client;
using Model.DTO_Model;
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

            HttpResponseMessage responseMessage = service.GetResponse("api/product/getallproductitem");
            responseMessage.EnsureSuccessStatusCode();
           // List<DTO_Product_Client> dTO_Accounts = responseMessage.Content.ReadAsAsync<List<DTO_Product_Client>>().Result;
          List<DTO_Product_Item_Type> dTO_Accounts = responseMessage.Content.ReadAsAsync<List<DTO_Product_Item_Type>>().Result;
            return View(dTO_Accounts);
        }
        public ActionResult Index2(int id)
        {

            HttpResponseMessage responseMessage = service.GetResponse("api/product/GetAllProductByIdItemClient/"+id);
            responseMessage.EnsureSuccessStatusCode();
            // List<DTO_Product_Client> dTO_Accounts = responseMessage.Content.ReadAsAsync<List<DTO_Product_Client>>().Result;
            List<DTO_Product_Item_Type> dTO_Accounts = responseMessage.Content.ReadAsAsync<List<DTO_Product_Item_Type>>().Result;
            return View(dTO_Accounts);
        }

        // GET: Product/Details/5
        public ActionResult Details()
        {

            List<DTO_Product_Item_Type> cart = (List<DTO_Product_Item_Type>)Session["cart"];
            if (cart == null)
            {
                return View("~/Cart/Thankyou1");
            }


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



            //    int item = 0;
            //List<Item> cart = (List<Item>)Session["cart"];
            //Item item1 = new Item();

            //if (cart != null)
            //  item=

            try
            {
                if (Session["cart"] != null)
                {
                    List<DTO_Product_Item_Type> cart = (List<DTO_Product_Item_Type>)Session["cart"];

                    int total = cart.Count();
                    ViewBag.Quantity = total;

                }
            }
            catch
            {

                ViewBag.Quantity = 0;

            }


            //ViewBag.Quantity = item;




            return PartialView("BagCart");
        }
        public PartialViewResult BagCart_()
        {



            try
            {
                if (Session["cart_"] != null)
                {
                    List<DTO_Product_Item_Type> cart_ = (List<DTO_Product_Item_Type>)Session["cart_"];

                    int total1 = cart_.Count();
                    ViewBag.yeuthich = total1;

                }
            }
            catch
            {

                ViewBag.yeuthich = 0;

            }

            //ViewBag.Quantity = item;




            return PartialView("BagCart_");
        }

        private int isExist(int Id)
        {
           List<DTO_Product_Item_Type> cart = (List< DTO_Product_Item_Type>)Session["cart"];

            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Id_SanPham.Equals(Id))
                    return i;
            return -1;
        }
        public ActionResult Remove(int Id)
        {
            List<DTO_Product_Item_Type> cart = (List<DTO_Product_Item_Type>)Session["cart"];
            int index = isExist(Id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }
        public ActionResult Buy(int Id)
        {
            if (Session["cart"] == null)
            {
                List<DTO_Product_Item_Type> li = new List<DTO_Product_Item_Type>();
                // var product = db.Products.Find(Id);

                HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                responseUser.EnsureSuccessStatusCode();
                DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;


                li.Add(new DTO_Product_Item_Type()
                {
                   
                    Quantity = 1,
                    Id_SanPham = proItem.Id_SanPham,
                    Name = proItem.Name,
                    Price = proItem.Price,
                    Details = proItem.Details,
                    Photo = proItem.Photo,
                    Id_Item = proItem.Id_Item,
                    //Quantity = item.Quantity
                });
                Session["cart"] = li;






            }
            else
            {
                List<DTO_Product_Item_Type> li = (List<DTO_Product_Item_Type>)Session["cart"];
                HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                responseUser.EnsureSuccessStatusCode();
                DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

                int index = isExist(Id);
                if (index != -1)
                {
                    li[index].Quantity++;
                }
                else
                {
                    li.Add(new DTO_Product_Item_Type()
                    {
                        
                        Id_SanPham = proItem.Id_SanPham,
                        Name = proItem.Name,
                        Price = proItem.Price,
                        Details = proItem.Details,
                        Photo = proItem.Photo,
                        Id_Item = proItem.Id_Item,
                        Quantity = 1
                    });

                }


                Session["cart"] = li;

            }
            return RedirectToAction("Details", "Product");

        }
        
        public ActionResult Buy_Favorite(int Id)
        {
            if (Session["cart"] == null)
            {
                List<DTO_Product_Item_Type> li = new List<DTO_Product_Item_Type>();
                // var product = db.Products.Find(Id);

                HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                responseUser.EnsureSuccessStatusCode();
                DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;


               
                li.Add(new DTO_Product_Item_Type()
                {

                    Quantity = 1,
                    Id_SanPham = proItem.Id_SanPham,
                    Name = proItem.Name,
                    Price = proItem.Price,
                    Details = proItem.Details,
                    Photo = proItem.Photo,
                    Id_Item = proItem.Id_Item,
                    //Quantity = item.Quantity
                });
                Session["cart"] = li;






            }
            else
            {
                List<DTO_Product_Item_Type> li = (List<DTO_Product_Item_Type>)Session["cart"];
                HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                responseUser.EnsureSuccessStatusCode();
                DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

                int index = isExist(Id);
                if (index != -1)
                {
                    li[index].Quantity++;
                }
                else
                {
                    li.Add(new DTO_Product_Item_Type()
                    {

                        Id_SanPham = proItem.Id_SanPham,
                        Name = proItem.Name,
                        Price = proItem.Price,
                        Details = proItem.Details,
                        Photo = proItem.Photo,
                        Id_Item = proItem.Id_Item,
                        Quantity = 1
                    });

                }


                Session["cart"] = li;
            }
            return RedirectToAction("Index", "Product");
            //return View();
        }
        public ActionResult Giam(int Id, DTO_Product_Item_Type item1)
        {
            if (Session["cart"] == null)
            {
                List<DTO_Product_Item_Type> li = new List<DTO_Product_Item_Type> ();
                HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                responseUser.EnsureSuccessStatusCode();
                DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

                li.Add(new DTO_Product_Item_Type()
                {

                    Id_SanPham = proItem.Id_SanPham,
                    Name = proItem.Name,
                    Price = proItem.Price,
                    Details = proItem.Details,
                    Photo = proItem.Photo,
                    Id_Item = proItem.Id_Item,
                    Quantity = 1
                });
                Session["cart"] = li;
                return Json(new { soLuong = li });





            }
            else
            {
                List<DTO_Product_Item_Type> li = (List<DTO_Product_Item_Type>)Session["cart"];
                HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                responseUser.EnsureSuccessStatusCode();
                DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

                int index = isExist(Id);
                if (index != -1)
                {
                    li[index].Quantity--;
                    li[index].Price = proItem.Price * li[index].Quantity;
                }
                else
                {
                    li.Add(new DTO_Product_Item_Type()
                    {
                        Id_SanPham = proItem.Id_SanPham,
                        Name = proItem.Name,
                        Price = proItem.Price,
                        Details = proItem.Details,
                        Photo = proItem.Photo,
                        Id_Item = proItem.Id_Item,
                        Quantity = -1
                    });
                    return Json(new { soLuong = li });

                }


                Session["cart"] = li;
                return Json(new { soLuong = li });
            }

            

        }
        public ActionResult Update(int Id, FormCollection fc)
        {

            List<DTO_Product_Item_Type> li = (List<DTO_Product_Item_Type>)Session["cart"];
            HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
            responseUser.EnsureSuccessStatusCode();
            DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

            int index = isExist(Id);
            if (index != -1)
            {


                li[index].Quantity++;


            }
            else
            {
                li.Add(new DTO_Product_Item_Type()
                {

                    Id_SanPham = proItem.Id_SanPham,
                    Name = proItem.Name,
                    Price = proItem.Price,
                    Details = proItem.Details,
                    Photo = proItem.Photo,
                    Id_Item = proItem.Id_Item,
                    Quantity = 1
                });

            }


            Session["cart"] = li;


            return RedirectToAction("Details", "Product");
        }
        [HttpPost]
        public ActionResult Tang(int Id, DTO_Product_Item_Type item1)
        {
            if (Session["cart"] == null)
            {
                List<DTO_Product_Item_Type> li = new List<DTO_Product_Item_Type>();
                HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                responseUser.EnsureSuccessStatusCode();
                DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;
                DTO_Product_Item_Type dTO_Product_Item_Type = new DTO_Product_Item_Type();
                li.Add(new DTO_Product_Item_Type()
                {

                    Id_SanPham = proItem.Id_SanPham,
                    Name = proItem.Name,
                    Price = proItem.Price,
                    Details = proItem.Details,
                    Photo = proItem.Photo,
                    Id_Item = proItem.Id_Item,
                    Quantity = 1
                });
                Session["cart"] = li;
                return Json(new { soLuong = li });





            }
            else
            {
                List<DTO_Product_Item_Type> li = (List<DTO_Product_Item_Type>)Session["cart"];
                HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                responseUser.EnsureSuccessStatusCode();
                DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

                int index = isExist(Id);
                if (index != -1)
                {
                    li[index].Quantity++;
                    li[index].Price = proItem.Price * li[index].Quantity;
                }
                else
                {
                    DTO_Product_Item_Type dTO_Product_Item_Type = new DTO_Product_Item_Type();
                    li.Add(new DTO_Product_Item_Type()
                    {
                        Id_SanPham = proItem.Id_SanPham,
                        Name = proItem.Name,
                        Price = proItem.Price,
                        Details = proItem.Details,
                        Photo = proItem.Photo,
                        Id_Item = proItem.Id_Item,
                        Quantity = +1
                    });
                    return Json(new { soLuong = li});

                }


                Session["cart"] = li;
                return Json(new { soLuong = li });
            }
           
        }

        public ActionResult Details1(int Id)
        {
            if (Session["cart__"] == null)
            {
                List<DTO_Product_Item_Type> li = (List<DTO_Product_Item_Type>)Session["cart"];
                HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                responseUser.EnsureSuccessStatusCode();
                DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

                //var product = db.Products.Find(Id);

                new DTO_Product_Item_Type()
                {
                    Id_SanPham = proItem.Id_SanPham,
                    Name = proItem.Name,
                    Price = proItem.Price,
                    Details = proItem.Details,
                    Photo = proItem.Photo,
                    Id_Item = proItem.Id_Item,
                    Quantity = 1
                };
                Session["cart__"] = proItem;






            }
            else
            {
                //    Item li = (Item)Session["cart__"];
                //    var product = db.Products.Find(Id);



                //        new Item()
                //        {
                //            Product = product,
                //            Quantity = 1
                //        };
                List<DTO_Product_Item_Type> li = (List<DTO_Product_Item_Type>)Session["cart"];
                HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                responseUser.EnsureSuccessStatusCode();
                DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

                new DTO_Product_Item_Type()
                {
                    Id_SanPham = proItem.Id_SanPham,
                    Name = proItem.Name,
                    Price = proItem.Price,
                    Details = proItem.Details,
                    Photo = proItem.Photo,
                    Id_Item = proItem.Id_Item,
                    Quantity = 1
                };
                Session["cart__"] = proItem;






            }
            return RedirectToAction("LuaChon","Cart");
        }

       
    }
}
