﻿using DAL.EF;
using Model.DTO.DTO_Client;
using Model.EF_Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Client
{
    public class BLL_Product
    {
        DAL.DAL_Client.DAL_Product dAL_Product = new DAL.DAL_Client.DAL_Product();
        public List<DTO_Product_Client> GetAllProducts()
        {
            EntityMapper<Product, DTO_Product_Client> mapObj = new EntityMapper<Product, DTO_Product_Client>();
            List<Product> products = dAL_Product.GetAllRoducts();
            List<DTO_Product_Client> dTO_Products = new List<DTO_Product_Client>();
            foreach (var item in products)
            {
                dTO_Products.Add(mapObj.Translate(item));
            }
            return dTO_Products;
        }
        public DTO_Product_Client GetProductById(int id)
        {
            EntityMapper<Product, DTO_Product_Client> mapObj = new EntityMapper<Product, DTO_Product_Client>();
            Product account = dAL_Product.GetProductById(id);
            DTO_Product_Client dTO_Accounts = mapObj.Translate(account);

            return dTO_Accounts;
        }
    }
}
