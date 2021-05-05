using BLL.BLL_Client;
using log4net;
using Microsoft.AspNetCore.Cors;
using Model.DTO.DTO_Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private BLL_Home cusBll = new BLL_Home();
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string Secret = "ThisIsHuySuperSuperSecretKey1hai3bon5sau7tam";


        //[EnableCors(origins: "*", headers: "*", methods: "*")]

        [HttpGet]
        public HttpResponseMessage ValidLogin(string user, string pass)
        {
            if (user == "admin" && pass == "admin")
                return Request.CreateResponse(HttpStatusCode.OK, TokenManager.GenerateToken(user));
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not valid");
        }
        //public string GetLoginResultByUsernamePassword(string user, string pass)
        //{
        //    try
        //    {
        //        log.Info("Successful to response login result.");
        //        if(cusBll.LoginCustomer(user,pass)==1)
        //            return TokenManager.GenerateToken(user);
        //        return "0";
        //    }
        //    catch (Exception)
        //    {
        //        log.Error("Cannot response login result.");
        //        throw;
        //    }
        //}

        [HttpPut]
        [Route("UpdateCustomer")]
        public bool UpdateCustomer(DTO_Users_Acc model)
        {
            try
            {
                return cusBll.UpdateCustomer(model);
            }
            catch (Exception)
            {
                log.Error("Cannot response result");
                throw;
            }
        }
        [HttpPut]
        [Route("UpdateCustomer2")]
        public bool UpdateCustomer2(DTO_Users_Acc model)
        {
            try
            {
                return cusBll.UpdateCustomer2(model);
            }
            catch (Exception)
            {
                log.Error("Cannot response result");
                throw;
            }
        }
        [HttpPut]
        [Route("UpdateCustomer3")]
        public bool UpdateCustomer3(DTO_Users_Acc model)
        {
            try
            {
                return cusBll.UpdateCustomer3(model);
            }
            catch (Exception)
            {
                log.Error("Cannot response result");
                throw;
            }
        }

        [HttpPost]
        [Route("InsertForFacebook")]
        public long InsertForFacebook(DTO_Users_Acc model)
        {
            try
            {
                return cusBll.InsertForFacebook(model);
            }
            catch (Exception)
            {
                log.Error("Cannot response result");
                throw;
            }
        }
        [Route(" InsertForGoogle")]
        public long InsertForGoogle(DTO_Users_Acc model)
        {
            try
            {
                return cusBll.InsertForGoogle(model);
            }
            catch (Exception)
            {
                log.Error("Cannot response result");
                throw;
            }
        }
        [HttpPost]
        [Route("InsertCustomer")]
        public bool InsertCustomer(DTO_Users_Acc cusInsert)
        {
            try
            {
                return cusBll.InsertCustomer(cusInsert);
            }
            catch (Exception)
            {
                log.Error("Cannot response result");
                throw;
            }
        }
        //[HttpGet]
        //public string Validate(string token, string username)
        //{
        //    if (account_BLL.UserNameIsExitst(username)) return "Invalid User";
        //    string tokenUsername = TokenManager.ValidateToken(token);
        //    if (username.Equals(tokenUsername))
        //    {
        //        return "Valid token";
        //    }
        //    else
        //        return "Invalid token";
        //}

        #region Get information
        [HttpGet]
        [Route("GetToken")]
        public string GetToken(string username)
        {
            try
            {
                var token = TokenManager.GenerateToken(username);
                return token;
            }
            catch (Exception)
            {
                return null;
            }
        }
        [Route("GetCustomerByToken")]
        public DTO_Users_Acc GetCustomerByToken(string token)
        {
            try
            {
                string tokenUsername = TokenManager.ValidateToken(token);
                log.Info("Get token API successful.");
                return cusBll.GetCustomerByUsername(tokenUsername);
            }
            catch (Exception ex)
            {
                log.Error("Cannot get customer by token api " + ex);
                throw;
            }
        }
        [Route("GetCustomerByUsername")]
        public DTO_Users_Acc GetCustomerByUsername(string user)
        {
            try
            {
                //string tokenUsername = TokenManager.ValidateToken(token);
                //if (user.Equals(tokenUsername))
                return cusBll.GetCustomerByUsername(user);
                //return null;
            }
            catch (Exception ex)
            {
                log.Error("Cannot response result." + ex);
                throw;
            }
        }
        [Route("GetCustomerByEmail")]
        public DTO_Users_Acc GetCustomerByEmail(string mail)
        {
            try
            {
                return cusBll.GetCustomerByEmail(mail);
            }
            catch (Exception)
            {
                log.Error("Cannot response result.");
                throw;
            }
        }
        [Route("GetCustomerByPassword")]
        public string GetCustomerByPassword(string email)
        {
            try
            {
                return cusBll.GetCustomerByPassword(email);
            }
            catch (Exception)
            {
                log.Error("Cannot response result.");
                throw;
            }
        }
        [HttpGet]
        [Route("GetLoginResultByUsernamePassword")]
        public DTO_Users_Acc GetLoginResultByUsernamePassword(string user, string pass)
        {
            try
            {
                log.Info("Successful to response login result.");
                return cusBll.LoginCustomer(user, pass);
            }
            catch (Exception)
            {
                log.Error("Cannot response login result.");
                throw;
            }
        }
        #endregion
    }
}
