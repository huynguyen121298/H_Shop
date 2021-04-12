using Model.DTO.DTO_Ad;
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
    public class CartController : Controller
    {
        ServiceRepository service = new ServiceRepository();
        // GET: Cart
        public ActionResult Index()
        {
            List<DTO_Product_Item_Type> cart = (List<DTO_Product_Item_Type>)Session["cart"];

            if (cart == null)

                return View("Thankyou1");

            else

                return View();

        }
        public ActionResult Checkout()
        {




            List<DTO_Product_Item_Type> cart = (List<DTO_Product_Item_Type>)Session["cart"];
            if (cart == null)
            {
                return View("Thankyou1");
            }


            return View();

        }
        public ActionResult LuaChon()
        {
            return View();
        }
        public ActionResult Buy_()
        {
            //if (Session["cart"] == null)
            //{
            //    List<Item> li = new List<Item>();
            //    var product = db.Products.Find(Id);

            //    li.Add(new Item()
            //    {
            //        Product = product,
            //        Quantity = 1
            //    });
            //    Session["cart"] = li;






            //}
            //else
            //{
            //    List<Item> li = (List<Item>)Session["cart"];
            //    var product = db.Products.Find(Id);

            //    int index = isExist(Id);
            //    if (index != -1)
            //    {
            //        li[index].Quantity++;
            //    }
            //    else
            //    {
            //        li.Add(new Item()
            //        {
            //            Product = product,
            //            Quantity = 1
            //        });

            //    }


            //    Session["cart"] = li;

            //}
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult saveOrder1(FormCollection fc, DTO_Checkout_Customer check,DTO_Checkout_Order check1)
         {
            try
            {
                List<DTO_Product_Item_Type> cart = (List<DTO_Product_Item_Type>)Session["cart"];
                //DTO_Checkout_Customer check = new DTO_Checkout_Customer();
                check.Id_KH = Int32.Parse(fc["Id_KH"]);

                check.NgayTao = DateTime.Now;
                check.FirstName = fc["FirstName"];
                check.LastName = fc["LastName"];
                check.Email = fc["Email"];
                check.DiaChi = fc["diaChi"];
                check.TongTien = Int32.Parse(fc["gia1"]);
                check.GiamGia = Int32.Parse(fc["discount1"]);
                check.City = fc["city"];
                check.SDT = Int32.Parse(fc["sdt"]);
                check.TrangThai = "Đang chờ";
                HttpResponseMessage responseUser = service.PostResponse("api/Cart/InsertCKCustomer/", check);

                responseUser.EnsureSuccessStatusCode();

                foreach (DTO_Product_Item_Type item in cart)
                {
                    var total = (item.Quantity * item.Price);
                   // DTO_Checkout_Order check1 = new DTO_Checkout_Order();
                    check1.Id_KH = Int32.Parse(fc["Id_KH"]);




                    check1.Id_SanPham = item.Id_SanPham;
                    check1.TenSP = item.Name;
                    check1.SoLuong = (int)item.Quantity;
                    check1.Gia = total;
                    check1.NgayTao = DateTime.Now;
                    check1.TrangThai = "Đang chờ";

                    HttpResponseMessage responseUser1 = service.PostResponse("api/Cart/InsertCKOrder/", check1);

                    responseUser1.EnsureSuccessStatusCode();

                }
               // db.SaveChanges();
                Session.Clear();
                
                return View("Thankyou");
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }






        }

        public ActionResult YeuThich()
        {




            List<DTO_Product_Item_Type> cart = (List<DTO_Product_Item_Type>)Session["cart_"];
            if (cart == null)
            {
                return View("Thankyou1");
            }


            return View();

        }
        public ActionResult Details_(int Id)
        {
            if (Session["cart_"] == null)
            {
                List < DTO_Product_Item_Type > li = new List<DTO_Product_Item_Type > ();
                
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
                Session["cart_"] = li;
                return Json(new { buy = li });




            }
            else
            {
                List<DTO_Product_Item_Type> li = (List<DTO_Product_Item_Type>)Session["cart_"];
                HttpResponseMessage responseUser = service.GetResponse("api/Products_Ad/GetProductItemById/" + Id);
                responseUser.EnsureSuccessStatusCode();
                DTO_Product_Item_Type proItem = responseUser.Content.ReadAsAsync<DTO_Product_Item_Type>().Result;

                int index = isExist_(Id);
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
                    return Json(new { buy = li });
                }


                Session["cart_"] = li;
                ViewBag.IdPorduct = Id;
                return Json(new { buy = li });
            }



            //return View();
        }
        private int isExist_(int Id)
        {
            List<DTO_Product_Item_Type> cart = (List<DTO_Product_Item_Type>)Session["cart_"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Id_SanPham.Equals(Id))
                    return i;
            return -1;
        }
        public ActionResult Remove_(int Id)
        {
            List<DTO_Product_Item_Type> cart = (List<DTO_Product_Item_Type>)Session["cart_"];
            int index = isExist_(Id);
            cart.RemoveAt(index);
            Session["cart_"] = cart;
            return RedirectToAction("YeuThich");
        }
        public int isExist(int Id)
        {
            List<DTO_Product_Item_Type> cart = (List<DTO_Product_Item_Type>)Session["cart"];
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

        //public ActionResult YeuThich()
        //{




        //    List<DTO_Product_Item_Type> cart = (List<DTO_Product_Item_Type>)Session["cart_"];
        //    if (cart == null)
        //    {
        //        return View("Thankyou1");
        //    }


        //    return View();

        //}
        public ActionResult Thankyou()
        {

            return View();
        }
        public ActionResult Thankyou1()
        {

            return View();
        }
        public ActionResult Details_Buy(int Id)
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
            //return View();
        }
       


    }
}
