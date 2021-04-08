using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAL_Model;
using DAL.EF;
using Model.DTO.DTO_Ad;
using Model.DTO_Model;
using Model.EF_Mapper;

namespace BLL.BLL_Ad
{
    public class BLL_Products
    {
        DAL.DAL_Ad.DAL_Products dAL_Product = new DAL.DAL_Ad.DAL_Products();
        public List<DTO_Product> GetAllProducts()
        {
            EntityMapper<Product, DTO_Product> mapObj = new EntityMapper<Product, DTO_Product>();
            List<Product> products = dAL_Product.GetAllProducts();
            List<DTO_Product> dTO_Products = new List<DTO_Product>();
            foreach (var item in products)
            {
                dTO_Products.Add(mapObj.Translate(item));
            }
            return dTO_Products;
        }
       
        public List<DTO_Product_Item_Type> GetAllProductItem()
        {
            EntityMapper<Product_Item_Type, DTO_Product_Item_Type> mapObj = new EntityMapper<Product_Item_Type, DTO_Product_Item_Type>();
            List<Product_Item_Type> products = dAL_Product.GetAllProductItemById();
            List<DTO_Product_Item_Type> dTO_Products = new List<DTO_Product_Item_Type>();
            foreach (var item in products)
            {
                dTO_Products.Add(mapObj.Translate(item));
            }
            return dTO_Products;
        }
        public List<List<DTO_Product>> GetAllProductItem_Type()
        {
            EntityMapper<Product, DTO_Product> mapObj = new EntityMapper<Product, DTO_Product>();
            List<List<Product>> products = dAL_Product.getproductByType();
            List<List<DTO_Product>> dTO_Products = new List<List<DTO_Product>>();
            foreach (var item in products)
            {
                List<DTO_Product> dTO_Products1 = new List<DTO_Product>();
                foreach(var item1 in item)
                {
                    dTO_Products1.Add(mapObj.Translate(item1));
                }
                dTO_Products.Add(dTO_Products1);
            }
            return dTO_Products;
        }
        public DTO_Product GetProductById(int id)
        {
            EntityMapper<Product, DTO_Product> mapObj = new EntityMapper<Product, DTO_Product>();
            Product account = dAL_Product.GetProDuctById(id);
            DTO_Product dTO_Accounts = mapObj.Translate(account);

            return dTO_Accounts;
        }
        public List<DTO_Product> GetProductById_Item(int id)
        {
            EntityMapper<Product, DTO_Product> mapObj = new EntityMapper<Product, DTO_Product>();
           List<Product> products = dAL_Product.getproductById_Item(id);
            List<DTO_Product> dTO_Accounts = new List<DTO_Product>();
            foreach (var item in products)
            {
                dTO_Accounts.Add(mapObj.Translate(item));
            }

            return dTO_Accounts;
        }
        public DTO_Product_Item_Type GetProductItemById(int id)
        {
            EntityMapper<Product_Item_Type, DTO_Product_Item_Type> mapObj = new EntityMapper<Product_Item_Type, DTO_Product_Item_Type>();
            Product_Item_Type account = dAL_Product.GetProductItemById(id);
            DTO_Product_Item_Type dTO_Accounts = mapObj.Translate(account);

            return dTO_Accounts;
        }
        public DTO_Product_Item_Type GetProductItemById2(string id)
        {
            EntityMapper<Product_Item_Type, DTO_Product_Item_Type> mapObj = new EntityMapper<Product_Item_Type, DTO_Product_Item_Type>();
            Product_Item_Type account = dAL_Product.GetProductItemById2(id);
            DTO_Product_Item_Type dTO_Accounts = mapObj.Translate(account);

            return dTO_Accounts;
        }
        public List<DTO_Product_Item_Type> GetProductItemByPageList()
        {
            EntityMapper<Product_Item_Type, DTO_Product_Item_Type> mapObj = new EntityMapper<Product_Item_Type, DTO_Product_Item_Type>();
            List<Product_Item_Type> account = dAL_Product.GetProductItemById3();
            List<DTO_Product_Item_Type> dTO_Accounts = new List<DTO_Product_Item_Type>();
            foreach (var item in account)
            {
                dTO_Accounts.Add(mapObj.Translate(item));
            }

            return dTO_Accounts;
        }
        public List<DTO_Product_Item_Type> GetProductItemById_client(int id)
        {
            EntityMapper<Product_Item_Type, DTO_Product_Item_Type> mapObj = new EntityMapper<Product_Item_Type, DTO_Product_Item_Type>();
            List<Product_Item_Type> account = dAL_Product.GetProductItemById_Client(id);
            List<DTO_Product_Item_Type> dTO_Accounts = new List<DTO_Product_Item_Type>();
            foreach(var item in account)
            {
                dTO_Accounts.Add(mapObj.Translate(item));
            }

            return dTO_Accounts;
        }
        //public bool Create_Ad_acc(DTO_Product dTO_Product)
        //{
        //    EntityMapper<Product, DTO_Product> mapObj = new EntityMapper<Product, DTO_Product>();
        //    EntityMapper<Item, DTO_Item> mapObj1 = new EntityMapper<Item, DTO_Item>();
        //    EntityMapper<Item_Type, DTO_Item_Type> mapObj2 = new EntityMapper<Item_Type, DTO_Item_Type>();

        //    Product product = mapObj.Translate(dTO_Product);
        //    return dAL_Product.InsertProduct(product);
        //    Item account = mapObj.Translate();
        //    return admin_Acc_dal.Create(account);
        //}
        public int CreateProduct(DTO_Product_Item_Type dTO_Account)
        {
            EntityMapper<DTO_Product_Item_Type, Product_Item_Type> mapObj = new EntityMapper< DTO_Product_Item_Type, Product_Item_Type> ();
            Product_Item_Type product_Item_Type = new Product_Item_Type();
            product_Item_Type = mapObj.Translate(dTO_Account);
            Product products = new Product();
            products.Id_Item = product_Item_Type.Id_Item;
            //products.Id_SanPham = product_Item_Type.Id_SanPham;
            products.Name = product_Item_Type.Name;
            products.Photo = product_Item_Type.Photo;
            products.Price = product_Item_Type.Price;
            products.Details = product_Item_Type.Details;

            Item item = new Item();
            //item.Id_SanPham = product_Item_Type.Id_SanPham;
            item.Quantity = product_Item_Type.Quantity;

          
               
            

          
               
            



            //EntityMapper<DTO_Product, Product> mapObj = new EntityMapper<DTO_Product, Product>();
            //Product account = mapObj.Translate(dTO_Account.);
            //EntityMapper<DTO_Item, Item> mapObj1 = new EntityMapper<DTO_Item, Item>();
            //Item account1 = mapObj1.Translate(item);
            
           
            return dAL_Product.InsertProduct(products,item);
        }
        //public bool CreateItem( DTO_Item item)
        //{
         
        //    EntityMapper<DTO_Item, Item> mapObj1 = new EntityMapper<DTO_Item, Item>();
           
        //    Item account1 = mapObj1.Translate(item);
            
        //    return dAL_Product.InsertItem( account1);
        //}
        public bool DeleteAccount(int id)
        {
            return dAL_Product.DeleteProduct(id);
        }
        //public DTO_Product GetProductById(int id)
        //{
        //    EntityMapper<Product, DTO_Product> mapObj = new EntityMapper<Product, DTO_Product>();
        //    Product account = dAL_Product.GetProDuctById(id);
        //    DTO_Product dTO_Accounts = mapObj.Translate(account);

        //    return dTO_Accounts;
        //}

        public int UpdateProduct(DTO_Product_Item_Type dTO_Account)
        {
            EntityMapper<DTO_Product_Item_Type, Product_Item_Type> mapObj = new EntityMapper<DTO_Product_Item_Type, Product_Item_Type>();
            Product_Item_Type product_Item_Type = new Product_Item_Type();
            product_Item_Type = mapObj.Translate(dTO_Account);
            Product products = new Product();
            products.Id_Item = product_Item_Type.Id_Item;
            products.Id_SanPham = product_Item_Type.Id_SanPham;
            products.Name = product_Item_Type.Name;
            products.Photo = product_Item_Type.Photo;
            products.Price = product_Item_Type.Price;
            products.Details = product_Item_Type.Details;

            Item item = new Item();
            item.Id_SanPham = product_Item_Type.Id_SanPham;
            item.Quantity = product_Item_Type.Quantity;











            //EntityMapper<DTO_Product, Product> mapObj = new EntityMapper<DTO_Product, Product>();
            //Product account = mapObj.Translate(dTO_Account.);
            //EntityMapper<DTO_Item, Item> mapObj1 = new EntityMapper<DTO_Item, Item>();
            //Item account1 = mapObj1.Translate(item);


            return dAL_Product.UpdateProduct(products, item);
        }

    }
}
