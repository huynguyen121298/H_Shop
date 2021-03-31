using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DAL.EF;

namespace DAL.DAL_Ad
{
    public class DAL_Products
    {

        private OnlineShopEntities  db = new OnlineShopEntities();


        // GET: Admin/Products_Add
        public List<Product> GetAllProducts()
        {
          
            return db.Products.ToList();
            
           // return db.Products.Include("Items.Quantity").ToList();



        }



        public Product GetProDuctById(int id)
        {
            return db.Products.Where(s=>s.Id_SanPham==id).FirstOrDefault();
        }


        public bool InsertProduct(Product productItem)
        {
            bool status;
            try
            {
                db.Products.Add(productItem);
               
                db.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public bool InsertItem(Item item)
        {
            bool status;
            try
            {
              
                db.Items.Add(item);
                db.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public bool UpdateProduct(Product productItem)
        {
            bool status;
            try
            {
                Product prodItem = db.Products.Where(p => p.Id_SanPham == productItem.Id_SanPham).FirstOrDefault();
                if (prodItem != null)
                {
                    prodItem.Id_SanPham = productItem.Id_SanPham;
                    prodItem.Name = productItem.Name;
                    prodItem.Price = productItem.Price;
                    prodItem.Photo = prodItem.Photo;
                    prodItem.Details = prodItem.Details;
                    //prodItem.
                    //DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        //public bool DeleteProduct(int id)
        //{
        //    bool status;
        //    try
        //    {
        //        Product prodItem = DbContext.Products.Where(p => p.ProductId == id).FirstOrDefault();
        //        if (prodItem != null)
        //        {
        //            DbContext.Products.Remove(prodItem);
        //            DbContext.SaveChanges();
        //        }
        //        status = true;
        //    }
        //    catch (Exception)
        //    {
        //        status = false;
        //    }
        //    return status;
        //}

        public bool DeleteProduct(int id)
        {
            try
            {
                Product product = db.Products.Find(id);
                //Item item = db.Items.Find(id);
                db.Products.Remove(product);
                //db.Items.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
           
            
        }
        public List<Product> product(int id)
        {

            
            var results= db.Products.Where(m => m.Id_Item ==id).ToList();

            return (results);
            //if (results == 1)
                
            //        return db.Products.Where(m => m.Id_Item == 1).ToList();

                


            //if (results == 2)
            
            //    return db.Products.Where(m => m.Id_Item == 2).ToList();
            
            //if (results == 3)
            //{
            //    return db.Products.Where(m => m.Id_Item == 3).ToList();
            //}
            //if (results == 4)
            //{
            //    return db.Products.Where(m => m.Id_Item == 4).ToList();
            //}
            //if (results == 5)
            //{
            //    return db.Products.Where(m => m.Id_Item == 5).ToList();
            //}
            //if (results == 6)
            //{
            //    return db.Products.Where(m => m.Id_Item == 6).ToList();
            //}
            //if (results == 7)
            //{
            //    return db.Products.Where(m => m.Id_Item == 7).ToList();
            //}
            //if (results == 8)
            //{
            //    return db.Products.Where(m => m.Id_Item == 8).ToList();
            //}
            //if (results == 9)
            //{
            //    return db.Products.Where(m => m.Id_Item == 9).ToList();
            //}

               


        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

    }
}
