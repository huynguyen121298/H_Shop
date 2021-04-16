using Model.DTO.DTO_Ad;
using Model.DTO.DTO_Client;
using Model.DTO_Model;
using System;
using System.Collections.Generic;
using System.IO;
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
            bool flag = true;
            List<string> messages = new List<string>();
            List<DTO_Product_Item_Type> cart = (List<DTO_Product_Item_Type>)Session["cart"];
            foreach(var item in cart)
            {
                //int quantityBuy = Convert.ToInt32(Request.Form["quantity"]);

                HttpResponseMessage response = service.GetResponse("api/Product/GetSoLuong/" + item.Id_SanPham);

                response.EnsureSuccessStatusCode();
                int quantity = response.Content.ReadAsAsync<int>().Result;
                int quantityAfterBuy = quantity - (int)item.Quantity;
                if (quantityAfterBuy < 0)
                {
                    flag = false;
                    string message = (item.Name + " đã vượt quá số lượng đang có");
                    messages.Add(message);
                }
            }
            ViewData["messages"] = messages;
            if (flag)
                return RedirectToAction("Index", "Cart");
            return View("~/Views/Product/Details.cshtml");




        }
        public ActionResult saveOrder1(FormCollection fc, DTO_CheckoutCustomer_Order check)
        {
          



            try
            {
                var checkZip = check.Zipcode = fc["zip"];
                if (checkZip != "")
                {
                    HttpResponseMessage responseUser = service.GetResponse("api/Cart/GetGiamGia/" + check.Zipcode);

                    responseUser.EnsureSuccessStatusCode();
                    Double giamgia = responseUser.Content.ReadAsAsync<Double>().Result;
                    if (giamgia != 0)
                    {
                        var price = Request.Form["gia1"];
                        var price1 = Request.Form["discount1"];
                        List<DTO_Product_Item_Type> cart = (List<DTO_Product_Item_Type>)Session["cart"];
                        //DTO_Checkout_Customer check = new DTO_Checkout_Customer();
                        //check.Id_KH = Int32.Parse(fc["Id_KH"]);

                        check.NgayTao = DateTime.Now;
                        check.FirstName = fc["FirstName"];
                        check.LastName = fc["LastName"];
                        check.Email = fc["Email"];
                        check.Zipcode = fc["zip"];
                        check.DiaChi = fc["diaChi"];
                        check.TongTien = Convert.ToInt32(price);
                        check.GiamGia = Int32.Parse(price1);
                        check.City = fc["city"];
                        check.SDT = Int32.Parse(fc["sdt"]);
                        check.TrangThai = "Đang chờ";

                        check.dTO_Checkout_Orders = new List<DTO_Checkout_Order>();

                        foreach (DTO_Product_Item_Type item in cart)
                        {
                            DTO_Checkout_Order dTO_Checkout_Order = new DTO_Checkout_Order();
                            var total = (item.Quantity * item.Price);
                            // DTO_Checkout_Order check1 = new DTO_Checkout_Order();
                            //check1.Id_KH = Int32.Parse(fc["Id_KH"]);




                            dTO_Checkout_Order.Id_SanPham = item.Id_SanPham;
                            dTO_Checkout_Order.TenSP = item.Name;
                            dTO_Checkout_Order.SoLuong = (int)item.Quantity;
                            dTO_Checkout_Order.Gia = total;
                            dTO_Checkout_Order.NgayTao = DateTime.Now;
                            dTO_Checkout_Order.TrangThai = "Đang chờ";

                            check.dTO_Checkout_Orders.Add(dTO_Checkout_Order);

                           



                        }
                        HttpResponseMessage responseUser1 = service.PostResponse("api/Cart/InsertBill/", check);

                        responseUser1.EnsureSuccessStatusCode();
                        Session.Clear();
                        return View("Thankyou");
                    }
                    else
                    {
                        ViewData["Message"] = ("Mã code không hợp lệ");
                        return View("Checkout");
                    }


                }
                else
                {
                    checkZip = null;
                    var price = Request.Form["gia1"];
                    
                    List<DTO_Product_Item_Type> cart = (List<DTO_Product_Item_Type>)Session["cart"];
                    //DTO_Checkout_Customer check = new DTO_Checkout_Customer();
                    //check.Id_KH = Int32.Parse(fc["Id_KH"]);

                    check.NgayTao = DateTime.Now;
                    check.FirstName = fc["FirstName"];
                    check.LastName = fc["LastName"];
                    check.Email = fc["Email"];
                    check.Zipcode = checkZip;
                    check.DiaChi = fc["diaChi"];
                    check.TongTien = Int32.Parse(price);
                    //check.GiamGia = Int32.Parse(fc["discount1"]);
                    check.City = fc["city"];
                    check.SDT = Int32.Parse(fc["sdt"]);
                    check.TrangThai = "Đang chờ";

                    check.dTO_Checkout_Orders = new List<DTO_Checkout_Order>();

                    foreach (DTO_Product_Item_Type item in cart)
                    {
                        DTO_Checkout_Order dTO_Checkout_Order = new DTO_Checkout_Order();
                        var total = (item.Quantity * item.Price);
                        // DTO_Checkout_Order check1 = new DTO_Checkout_Order();
                        //check1.Id_KH = Int32.Parse(fc["Id_KH"]);




                        dTO_Checkout_Order.Id_SanPham = item.Id_SanPham;
                        dTO_Checkout_Order.TenSP = item.Name;
                        dTO_Checkout_Order.SoLuong = (int)item.Quantity;
                        dTO_Checkout_Order.Gia = total;
                        dTO_Checkout_Order.NgayTao = DateTime.Now;
                        dTO_Checkout_Order.TrangThai = "Đang chờ";

                        check.dTO_Checkout_Orders.Add(dTO_Checkout_Order);


                    }




                    HttpResponseMessage responseUser1 = service.PostResponse("api/Cart/InsertBill/", check);

                    responseUser1.EnsureSuccessStatusCode();
                    Session.Clear();
                    return View("Thankyou");






                }
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }






        }
        public ActionResult saveOrder2(string priceCode)
        {
            try
            {

              
                HttpResponseMessage responseUser = service.GetResponse("api/Cart/GetGiamGia/" + priceCode);

                responseUser.EnsureSuccessStatusCode();
                Double giamgia = responseUser.Content.ReadAsAsync<Double>().Result;




                //return Json(new
                //{
                //    view = RenderRazorViewToString(ControllerContext, "Checkout", check),
                //    isValid = false,
                //    description = "Error!",
                //    JsonRequestBehavior.AllowGet,
                //    checkout = giamgia
                //});
                string messsage = ("Mã code " + priceCode.ToString() + " hợp lệ");
                ViewBag.Message = messsage;
                return Json(new { checkout = giamgia }); 
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }






        }
        public static string RenderRazorViewToString(ControllerContext controllerContext, string viewName, object model)
        {
            controllerContext.Controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var ViewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                var ViewContext = new ViewContext(controllerContext, ViewResult.View, controllerContext.Controller.ViewData, controllerContext.Controller.TempData, sw);
                ViewResult.View.Render(ViewContext, sw);
                ViewResult.ViewEngine.ReleaseView(controllerContext, ViewResult.View);
                return sw.GetStringBuilder().ToString();
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
        public ActionResult HetHang()
        {
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
            
            HttpResponseMessage response = service.GetResponse("api/Product/GetSoLuong/" + Id);

            response.EnsureSuccessStatusCode();
            int quantity = response.Content.ReadAsAsync<int>().Result;
            if(quantity > 0)
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
            else
            {

                ViewData["MessQuantity"] = ("Sản phẩm đã hết");
                return View("LuaChon");
            }
          
            //return View();
        }
       


    }
}
