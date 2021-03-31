using BLL.BLL_Client;
using Model.DTO.DTO_Client;
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
        [Route("GetProductById/{Id:int}")]
        public JsonResult<DTO_Product_Client> GetProductById(int Id)
        {
            return Json<DTO_Product_Client>(bLL_Product.GetProductById(Id));
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
