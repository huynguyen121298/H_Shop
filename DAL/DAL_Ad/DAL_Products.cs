using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DAL.DAL_Model;
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
            
        
        }
       



        public Product GetProDuctById(int id)
        {
            return db.Products.Where(s=>s.Id_SanPham==id).FirstOrDefault();
        }
        public Product_Item_Type GetProductItemById(int id)
        {
            var infoProduct = from item in db.Items
                              join product in db.Products on item.Id_SanPham equals product.Id_SanPham
                              where product.Id_SanPham == id && item.Id_SanPham==id
                              select new Product_Item_Type()
                              {
                                  Id_SanPham = product.Id_SanPham,
                                  Name = product.Name,
                                  Price = product.Price,
                                  Details = product.Details,
                                  Photo = product.Photo,
                                  Id_Item=product.Id_Item,
                                  Quantity=item.Quantity
                                     
                                  


                                   };
            return infoProduct.FirstOrDefault();
        }
        public Product_Item_Type GetProductItemById2(string id)
        {
            var infoProduct = from item in db.Items
                              join product in db.Products on item.Id_SanPham equals product.Id_SanPham
                              //where product.Id_SanPham == id && item.Id_SanPham == id
                              select new Product_Item_Type()
                              {
                                  Id_SanPham = product.Id_SanPham,
                                  Name = product.Name,
                                  Price = product.Price,
                                  Details = product.Details,
                                  Photo = product.Photo,
                                  Id_Item = product.Id_Item,
                                  Quantity = item.Quantity




                              };
            return infoProduct.FirstOrDefault();
        }
        public List<Product_Item_Type> GetProductItemById3()
        {
            var infoProduct = from item in db.Items
                              join product in db.Products on item.Id_SanPham equals product.Id_SanPham
                                orderby product.Id_SanPham 
                              select new Product_Item_Type()
                              {
                                  Id_SanPham = product.Id_SanPham,
                                  Name = product.Name,
                                  Price = product.Price,
                                  Details = product.Details,
                                  Photo = product.Photo,
                                  Id_Item = product.Id_Item,
                                  Quantity = item.Quantity





                              };
            return infoProduct.ToList();
        }
        public List<Product_Item_Type> GetProductItemById_Client(int id)
        {
            var infoProduct = from item in db.Item_Type
                              join product in db.Products on item.Id_Item equals product.Id_Item
                              where product.Id_Item == id && item.Id_Item == id
                              select new Product_Item_Type()
                              {
                                  Id_SanPham = product.Id_SanPham,
                                  Name = product.Name,
                                  Price = product.Price,
                                  Details = product.Details,
                                  Photo = product.Photo,
                                  Id_Item = product.Id_Item,
                                  Type_Product =item.Type_Product




                              };
            return infoProduct.ToList();
        }
        public List<Product_Item_Type> GetAllProductItemById()
        {
            var infoProduct = from item in db.Items
                              join product in db.Products on item.Id_SanPham equals product.Id_SanPham
                              
                              select new Product_Item_Type()
                              {
                                  Id_SanPham = product.Id_SanPham,
                                  Name = product.Name,
                                  Price = product.Price,
                                  Details = product.Details,
                                  Photo = product.Photo,
                                  Id_Item = product.Id_Item,
                                  Quantity = item.Quantity




                              };
            return infoProduct.ToList();
        }



        public int InsertProduct(Product productItem, Item item)
        {
            //bool status;

            using (var transaction = db.Database.BeginTransaction())
            {
                    db.Items.Add(item);
                 db.SaveChanges();
                    
                    productItem.Id_SanPham = item.Id_SanPham;
                    db.Products.Add(productItem);




                try
                {
                    int result = db.SaveChanges();
                    transaction.Commit();
                    return result;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return -2;
                }
            }


            //try
            //{
            //    db.Products.Add(productItem);
            //    d

            //    db.SaveChanges();
            //    status = true;
            //}
            //catch (Exception)
            //{
            //    status = false;
            //}
            //return status;
        }
        public bool UpdateQuantityItem(int id,int quantity)
        {
            var itemNow = db.Items.Where(s => s.Id_SanPham == id).FirstOrDefault();
           
            //var quantityNow;
            if (itemNow != null)
            {
               var quantityNow= itemNow.Quantity; // vidu: 0.3 0.4
                var quantityPay = quantityNow - quantity;
                //if(itemNow.Quantity - quantity > 0)
                if (quantityNow - quantityPay > 0)
                {
                    //Item item = new Item();
                    itemNow.Quantity = quantityPay;
                    //item.Id_SanPham = id;
                    db.SaveChanges();
                    return true; 
                }
               
            }
            return false;
          
           
           

          
        }
        public int UpdateProduct(Product productItem, Item item)
        {
            using (var transaction = db.Database.BeginTransaction())
            {



                Product prodItem = db.Products.Where(p => p.Id_SanPham == productItem.Id_SanPham).FirstOrDefault();
                if (prodItem != null)
                {
                    prodItem.Id_SanPham = productItem.Id_SanPham;
                    prodItem.Name = productItem.Name;
                    prodItem.Price = productItem.Price;
                    prodItem.Photo = productItem.Photo;
                    prodItem.Details = productItem.Details;
                    prodItem.Id_Item = productItem.Id_Item;
                    
                }

                Item it = db.Items.Where(p => p.Id_SanPham == productItem.Id_SanPham).FirstOrDefault();
                if (it != null)
                {
                    it.Id_SanPham = item.Id_SanPham;
                    it.Quantity = item.Quantity;
                    
                }

                try
                {


                    int result = db.SaveChanges();
                    transaction.Commit();
                    return result;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return -2;
                }
            }
            
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
                Item item = db.Items.Find(id);
                db.Products.Remove(product);
                db.Items.Remove(item);
                //db.Items.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
           
            
        }
        public List<Product> getproductById_Item(int id)
        {
            //List<Item_Type> item_Types = new List<Item_Type>();
           // List<Product> productsByType = new List<Product>();
           // item_Types = db.Item_Type.ToList();
            //foreach (Item_Type item in item_Types)
            //{
            //    List<Product> products = db.Products.Where(m => m.Id_Item == id).ToList();
            //    productsByType.Add(products);
            //}
            return db.Products.Where(m => m.Id_Item == id).ToList();
           
        }
        public List<List<Product>> getproductByType()
        {
            List<Item_Type> item_Types = new List<Item_Type>();
            List<List<Product>> productsByType = new List<List<Product>>();
            item_Types = db.Item_Type.ToList();
            foreach (Item_Type item in item_Types)
            {
                //    Product obj_name = new Product();
                //    obj_name.Id_Item = item.Id_Item;
                //    obj_name.Name = item.Type_Product;
                //    List<Product> products = db.Products.Where(m => m.Id_Item == item.Id_Item).ToList();
                //    obj_name.products = products;
                //    productsByType.Add(products);
                   List<Product> products = db.Products.Where(m => m.Id_Item == item.Id_Item).ToList();
                    productsByType.Add(products);
            }
            return productsByType.ToList();
            


       }

    }
}
