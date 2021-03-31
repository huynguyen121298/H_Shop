using DAL.EF;
using Model.DTO;
using Model.DTO.DTO_Ad;
using Model.EF_Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Ad
{
   public class BLL_Account
    {
        DAL.DAL_Ad.DAL_Account dal_acc = new DAL.DAL_Ad.DAL_Account();
        public BoolResult AccountIsExits(string userName, string password)
        {
            BoolResult boolResult = new BoolResult();
            boolResult.Result = dal_acc.AccountIsExist(userName, password);
            return boolResult;
        }
        public bool UserNameIsExitst(string username)
        {
            return dal_acc.UserNameIsExist(username);
        }
        //public int InsertUserAccount(DTO_Account dtoRegisterAccount)
        //{
        //    EntityMapper< DTO_Account, Account > mapObjRegis = new EntityMapper<DTO_Account, Account>();
        //    Account registerAccount = mapObjRegis.Translate(dtoRegisterAccount);

        //    //User user = ModuleParse.ParseDtoToEFModel.ParseDtoRegisterToUser(registerAccount);
        //    //UserAccount userAccount = ModuleParse.ParseDtoToEFModel.ParseDtoRegisterToAccount(registerAccount);
        //    //return account_dal.InsertUserAccount(user, userAccount);
        //}
        public bool UpdateCustomer(DTO_Account cusUpdate)
        {
            EntityMapper<DTO_Account, Account> mapObj = new EntityMapper<DTO_Account, Account>();
            Account customObj = mapObj.Translate(cusUpdate);
            return dal_acc.UpdateCustomer(customObj);
        }
        public bool DeleteCustomer(int id)
        {
            return  dal_acc.DeleteCustomer(id);
        }
        public bool InsertCustomer(DTO_Account cusInsert)
        {
            EntityMapper<DTO_Account, Account> mapObj = new EntityMapper<DTO_Account, Account>();
            Account customObj = mapObj.Translate(cusInsert);
            return dal_acc.InsertUserAccount(customObj);
        }
        public DTO_Account GetCustomerByID(int id)
        {
            EntityMapper<Account, DTO_Account> mapObj = new EntityMapper<Account, DTO_Account>();
            Account cus = dal_acc.GetCustomerByID(id);
            DTO_Account result = mapObj.Translate(cus);
            return result;
        }

        public DTO_Account GetCustomerByEmail(string email)
        {
            EntityMapper<Account, DTO_Account> mapObj = new EntityMapper<Account, DTO_Account>();
            Account cus = dal_acc.GetCustomerByEmail(email);
            DTO_Account result = mapObj.Translate(cus);
            return result;
        }
        public DTO_Account LoginCustomer(string user, string pass)
        {
            EntityMapper<Account, DTO_Account> mapObj = new EntityMapper<Account, DTO_Account>();
            Account custom = dal_acc.Login(user, pass);
            DTO_Account result = mapObj.Translate(custom);
            return result;
        }
    }
}
