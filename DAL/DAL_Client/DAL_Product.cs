using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAL_Model;
using DAL.EF;

namespace DAL.DAL_Client
{
    public class DAL_Product
    {
        OnlineShopEntities db = new OnlineShopEntities();
        public List<Product> GetAllRoducts()
        {
            //bool item = db.Items.Select(t => t.Id_SanPham == 11).SingleOrDefault();
            var acc = db.Accounts.Select(t => t.idUser == 5).FirstOrDefault();
            var temp = db.Accounts.ToList();
            return db.Products.ToList();

        }
        public Product GetProductById(int id)
        {
            return db.Products.Where(s => s.Id_SanPham == id).FirstOrDefault();
        }
        //public List<Dis_Product> GetProductByPrice(int? gia, int? gia_)
        //{
        //    var infoProduct = (from dis in db.Discount_Product
        //                      join product in db.Products on dis.Id_SanPham equals product.Id_SanPham

        //                      select new Dis_Product()
        //                      {
        //                          Id_SanPham = product.Id_SanPham,
        //                          Name = product.Name,
        //                          Price = product.Price,
        //                          Details = product.Details,
        //                          Photo = product.Photo,
        //                          Id_Item = product.Id_Item,
        //                          Content = dis.Content,
        //                          Price_Dis = dis.Price_Dis,
        //                          Start = dis.Start,
        //                          End = dis.End





        //                      }).Where(s => s.Price <= gia_ && s.Price >= gia).ToList();
        //    return infoProduct;
        //}

        public List<Dis_Product> GetProductByPrice(int? gia, int? gia_)
        {
            var infoProduct = from dis in db.Discount_Product
                               join product in db.Products on dis.Id_SanPham equals product.Id_SanPham

                               select new Dis_Product()
                               {
                                   Id_SanPham = product.Id_SanPham,
                                   Name = product.Name,
                                   Price = product.Price,
                                   Details = product.Details,
                                   Photo = product.Photo,
                                   Id_Item = product.Id_Item,
                                   Content = dis.Content,
                                   Price_Dis = dis.Price_Dis,
                                   Start = dis.Start,
                                   End = dis.End





                               };
            List<Dis_Product> dis_Product = new List<Dis_Product>();
            List<Dis_Product> dis_Product2 = new List<Dis_Product>();
            Dis_Product dis_Product3 = new Dis_Product();
            Dis_Product dis_Product4 = new Dis_Product();
            List<Dis_Product> dis_Product5 = new List<Dis_Product>();
            List<Dis_Product> dis_Product6 = new List<Dis_Product>();



            foreach (var item in infoProduct)
            {
                //dis_Product.Add(item);
                if (GetPriceDiscountById(Convert.ToInt32(item.Id_SanPham)) != 0)
                {
                    //item.Price = Convert.ToInt32(GetPriceDiscountById((Convert.ToInt32(item.Id_SanPham))));

                    bool dis_Product7 = (item.Price_Dis <= gia_ && item.Price_Dis >= gia);
                    if (dis_Product7 ==true)
                    {
                        dis_Product5.Add(item);
                    }
                    
                }
                else
                {
                    bool dis_Product8 = (item.Price <= gia_ && item.Price >= gia);
                    if (dis_Product8 ==true)
                    {
                        dis_Product2.Add(item);
                    }
                   
                }
                
               



            }
            dis_Product6.AddRange(dis_Product2);
            dis_Product6.AddRange(dis_Product5);



            return dis_Product6;
           
        }
        public double GetPriceDiscountById(int id)
        {
            DateTime dateTime = DateTime.Today;
            var item_discount = db.Discount_Product.Where(t => t.Id_SanPham == id && t.End.Value >= dateTime).FirstOrDefault();

            if (item_discount != null && item_discount.Price_Dis != null)
            {
                return Convert.ToDouble(item_discount.Price_Dis);
            }
            return 0;
        }

        //public List<Product> GetProductByName(string name)
        //{

        //    return db.Products.Where(s => s.Name.StartsWith(name)).ToList();
        //}
        public List<Dis_Product> GetProductByName(string name)
        {
            var infoProduct = (from dis in db.Discount_Product
                               join product in db.Products on dis.Id_SanPham equals product.Id_SanPham

                               select new Dis_Product()
                               {
                                   Id_SanPham = product.Id_SanPham,
                                   Name = product.Name,
                                   Price = product.Price,
                                   Details = product.Details,
                                   Photo = product.Photo,
                                   Id_Item = product.Id_Item,
                                   Content = dis.Content,
                                   Price_Dis = dis.Price_Dis,
                                   Start = dis.Start,
                                   End = dis.End





                               }).Where(s => s.Name.StartsWith(name)).ToList();

            return infoProduct;
        }
        public List<Product> GetProductByName2(string name)
        {

            return db.Products.Where(s => s.Name.Contains(name)).ToList();
        }
        public int GetSoLuong(int id)
        {
            
            var temp = db.Items.Where(s => s.Id_SanPham == id).FirstOrDefault();
            if (temp != null)
            {
                return (int)temp.Quantity; // vidu: 0.3 0.4
            }
            return 0;

        }
    }
}

