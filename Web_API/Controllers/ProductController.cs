using BLL.BLL_Client;
using Model.DTO.DTO_Client;
using Model.DTO_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Web_API.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        BLL_Product bLL_Product = new BLL_Product();
        BLL.BLL_Ad.BLL_Products BLL_Products = new BLL.BLL_Ad.BLL_Products();
        // GET: api/Product
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Product/5
        [HttpGet]
        [Route("GetAllproducts")]
        public JsonResult<List<DTO_Product_Client>> GetAllProducts()
        {
            return Json<List<DTO_Product_Client>>(bLL_Product.GetAllProducts());
        }
        [HttpGet]
        [Route("GetAllProductByPrice/{giaMin:int}/{giaMax:int}")]
        public JsonResult<List<DTO_Product_Client>> GetAllProductByPrice(int giaMin,int giaMax)
        {
            return Json<List<DTO_Product_Client>>(bLL_Product.GetAllProductByPrice(giaMin, giaMax));
        }
        [HttpGet]
        [Route("GetAllProductByName/{name}")]
        public JsonResult<List<DTO_Product_Client>> GetAllProductByName(string name)
        {
            return Json<List<DTO_Product_Client>>(bLL_Product.GetAllProductByName(name));
        }


        [HttpGet]
        [Route("GetAllProductItemByPageList")]
        public JsonResult<List<DTO_Product_Item_Type>> GetAllProductItemByPageList()
        {
            return Json<List<DTO_Product_Item_Type>>(BLL_Products.GetProductItemByPageList());
        }
        [Route("GetAllProductItem")]
        public JsonResult<List<DTO_Product_Item_Type>> GetAllProductItem()
        {
            return Json<List<DTO_Product_Item_Type>>(BLL_Products.GetAllProductItem());
        }
        [HttpGet]
        [Route("GetProductById/{Id:int}")]
        public JsonResult<DTO_Product_Client> GetProductById(int Id)
        {
            return Json<DTO_Product_Client>(bLL_Product.GetProductById(Id));
        }
        [HttpGet]
        [Route("GetAllProductByIdItemClient/{id:int}")]
        public JsonResult<List<DTO_Product_Item_Type>> GetAllProductByIdItem(int id)
        {
            return Json< List<DTO_Product_Item_Type >> (BLL_Products.GetProductItemById_client(id));
        }
        [HttpGet]
        [Route("GetProductItemById/{Id:int}")]
        public JsonResult<DTO_Product_Item_Type> GetProductItemById(int Id)
        {
            return Json<DTO_Product_Item_Type>(BLL_Products.GetProductItemById(Id));
        }
        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
