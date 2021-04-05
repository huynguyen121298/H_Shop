using Model.DTO.DTO_Ad;
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
        [Route("GetProductItemById/{Id:int}")]
        public JsonResult<DTO_Product_Item_Type> GetProductItemById(int Id)
        {
            return Json<DTO_Product_Item_Type>(BLL_Products.GetProductItemById(Id));
        }
        [HttpGet]
        [Route("GetAllProducts")]
        public JsonResult<List<DTO_Product>> GetAllProducts()
        {
            return Json<List<DTO_Product>>(BLL_Products.GetAllProducts());
        }

        [HttpGet]
        [Route("GetAllProductByIdItem/{id:int}")]
        public JsonResult<List<DTO_Product>> GetAllProductByIdItem(int id)
        {
            return Json<List<DTO_Product>>(BLL_Products.GetProductById_Item(id));
        }

        [HttpGet]
        [Route("GetAllProductByType")]
        public JsonResult<List<List<DTO_Product>>> GetAllProductByType()
        {
            return Json<List<List<DTO_Product>>>(BLL_Products.GetAllProductItem_Type());
        }
        [Route("CreateProduct")]
        public int  CreateProduct(DTO_Product_Item_Type dTO_Product_Item)
        {
            return BLL_Products.CreateProduct(dTO_Product_Item);
        }
        [Route("UpdateProduct")]
        public int UpdateProduct(DTO_Product_Item_Type dTO_Product_Item)
        {
            return BLL_Products.UpdateProduct(dTO_Product_Item);
        }
        //[Route("CreateItem")]
        //public bool CreateItem( DTO_Item item)
        //{
        //    return BLL_Products.CreateItem( item);
        //}

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
