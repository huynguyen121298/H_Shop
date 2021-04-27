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
        public List<Dis_Product> GetProductByPrice(int? gia, int? gia_)
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





                              }).Where(s => s.Price <= gia_ && s.Price >= gia).ToList();
            return infoProduct;
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

