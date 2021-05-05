using DAL.DAL_Ad;
using DAL.EF;
using Model.DTO.DTO_Ad;
using Model.EF_Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Ad
{
    public class BLL_Checkout_Customer
    {

        DAL_Checkout_Customer bll_cAcc = new DAL_Checkout_Customer();
        public List<DTO_Checkout_Customer> GetAllAccounts()
        {
            EntityMapper<Checkout_Customer, DTO_Checkout_Customer> mapObj = new EntityMapper<Checkout_Customer, DTO_Checkout_Customer>();
            List<Checkout_Customer> account = bll_cAcc.GetAllAccounts();
            List<DTO_Checkout_Customer> dTO_Accounts = new List<DTO_Checkout_Customer>();
            foreach (var item in account)
            {
                dTO_Accounts.Add(mapObj.Translate(item));
            }
            return dTO_Accounts;
        }
        //public List<DTO_Account_Role> GetAllAccounts2()
        //{
        //    EntityMapper<Account_Role, DTO_Account_Role> mapObj = new EntityMapper<Account_Role, DTO_Account_Role>();
        //    List<Account_Role> account = bll_cAcc.GetAllAccounts2();
        //    List<DTO_Account_Role> dTO_Accounts = new List<DTO_Account_Role>();
        //    foreach (var item in account)
        //    {
        //        dTO_Accounts.Add(mapObj.Translate(item));
        //    }
        //    return dTO_Accounts;
        //}
        public DTO_Checkout_Customer GetAccountById(int id)
        {
            EntityMapper<Checkout_Customer, DTO_Checkout_Customer> mapObj = new EntityMapper<Checkout_Customer, DTO_Checkout_Customer>();
            Checkout_Customer account = bll_cAcc.GetAccountById(id);
            DTO_Checkout_Customer dTO_Accounts = mapObj.Translate(account);

            return dTO_Accounts;
        }
        public List< DTO_Checkout_Customer> GetListAccountById(int id)
        {
            EntityMapper<Checkout_Customer, DTO_Checkout_Customer> mapObj = new EntityMapper<Checkout_Customer, DTO_Checkout_Customer>();
            List<Checkout_Customer> account = bll_cAcc.GetListAccountById(id);
            List<DTO_Checkout_Customer> dTO_Accounts = new List<DTO_Checkout_Customer>();
            foreach(var item in account)
            {
                dTO_Accounts.Add(mapObj.Translate(item));
            }

            return dTO_Accounts;
        }

        public bool Update_Ad_acc(DTO_Checkout_Customer dTO_Account)
        {
            EntityMapper<DTO_Checkout_Customer, Checkout_Customer> mapObj = new EntityMapper<DTO_Checkout_Customer, Checkout_Customer>();
            Checkout_Customer account = mapObj.Translate(dTO_Account);
            return bll_cAcc.Edit(account);
        }
        public bool DeleteAccount(int id)
        {
            return bll_cAcc.DeleteAccount(id);
        }

    }
}
