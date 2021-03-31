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
    public class BLL_User_Acc
    {
        DAL_User_Acc admin_Acc_dal = new DAL_User_Acc();
        public List<DTO_User_Acc> GetAllAccounts()
        {
            EntityMapper<Users_Acc, DTO_User_Acc> mapObj = new EntityMapper<Users_Acc, DTO_User_Acc>();
            List<Users_Acc> account = admin_Acc_dal.GetAllAccounts();
            List<DTO_User_Acc> dTO_Accounts = new List<DTO_User_Acc>();
            foreach (var item in account)
            {
                dTO_Accounts.Add(mapObj.Translate(item));
            }
            return dTO_Accounts;
        }
        //public List<DTO_Account_Role> GetAllAccounts2()
        //{
        //    EntityMapper<Account_Role, DTO_Account_Role> mapObj = new EntityMapper<Account_Role, DTO_Account_Role>();
        //    List<Account_Role> account = admin_Acc_dal.GetAllAccounts2();
        //    List<DTO_Account_Role> dTO_Accounts = new List<DTO_Account_Role>();
        //    foreach (var item in account)
        //    {
        //        dTO_Accounts.Add(mapObj.Translate(item));
        //    }
        //    return dTO_Accounts;
        //}
        public DTO_User_Acc GetAccountById(int id)
        {
            EntityMapper<Users_Acc, DTO_User_Acc> mapObj = new EntityMapper<Users_Acc, DTO_User_Acc>();
            Users_Acc account = admin_Acc_dal.GetAccountById(id);
            DTO_User_Acc dTO_Accounts = mapObj.Translate(account);

            return dTO_Accounts;
        }
        //public bool Create_Ad_acc(DTO_Account dTO_Account)
        //{
        //    EntityMapper<DTO_Account, Account> mapObj = new EntityMapper<DTO_Account, Account>();
        //    Account account = mapObj.Translate(dTO_Account);
        //    return admin_Acc_dal.Create(account);
        //}
        public bool Update_Ad_acc(DTO_User_Acc dTO_Account)
        {
            EntityMapper<DTO_User_Acc, Users_Acc> mapObj = new EntityMapper<DTO_User_Acc, Users_Acc>();
            Users_Acc account = mapObj.Translate(dTO_Account);
            return admin_Acc_dal.Edit(account);
        }
        public bool DeleteAccount(int id)
        {
            return admin_Acc_dal.DeleteAccount(id);
        }
    }
}
