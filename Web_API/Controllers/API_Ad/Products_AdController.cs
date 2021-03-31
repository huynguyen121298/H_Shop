﻿using Model.DTO.DTO_Ad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Web_API.Controllers
{
    [RoutePrefix("api/Products_Ad")]
    public class ProductsController : ApiController
    {
        BLL.BLL_Ad.BLL_Products BLL_Products = new BLL.BLL_Ad.BLL_Products();
        // GET: api/Products
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Products/5
        [HttpGet]
        [Route("GetProductById/{Id:int}")]
        public JsonResult<DTO_Product> GetProductById(int Id)
        {
            return Json<DTO_Product>(BLL_Products.GetProductById(Id));
        }
        [HttpGet]
        [Route("GetAllProducts")]
        public JsonResult<List<DTO_Product>> GetAllProducts()
        {
            return Json<List<DTO_Product>>(BLL_Products.GetAllProducts());
        }
        [Route("CreateProduct")]
        public bool CreateProduct(DTO_Product dTO_Product)
        {
            return BLL_Products.CreateProduct(dTO_Product);
        }
        [Route("CreateItem")]
        public bool CreateItem( DTO_Item item)
        {
            return BLL_Products.CreateItem( item);
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [Route("DeleteProduct/{id:int}")]
        public bool DeleteProduct(int id)
        {
            return BLL_Products.DeleteAccount(id);
        }
    }
}
