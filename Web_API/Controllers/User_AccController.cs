using BLL.BLL_Client;
using Model.DTO.DTO_Client;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Web_API.Controllers
{
    [RoutePrefix("api/User_Acc")]
    public class User_Acc : ApiController
    {
        private BLL_Home cusBll = new BLL_Home();
        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("GetAllCustomers")]
        public List<DTO_Users_Acc> GetAllCustomers()
        {
            return cusBll.GetAllCustomers();
        }
        [Route("GetDetailCustomer")]
        public DTO_Users_Acc GetDetailCustomer(int id)
        {
            return cusBll.GetCustomerByID(id);
        }
        [Route("InsertCustomer")]
        public bool InsertCustomer(DTO_Users_Acc cusInsert)
        {
            return cusBll.InsertCustomer(cusInsert);
        }
        [Route("UpdateCustomer")]
        public bool UpdateCustomer(DTO_Users_Acc cusUpdate)
        {
            return cusBll.UpdateCustomer(cusUpdate);
        }
        [Route("DeleteCustomer")]
        public bool DeleteCustomer(int id)
        {
            return cusBll.DeleteCustomer(id);
        }
        [Route("CountCustomer")]
        public int CountCustomer()
        {
            return cusBll.GetAllCustomers().Count();
        }
    }
}
