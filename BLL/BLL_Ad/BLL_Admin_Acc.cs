using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using Model.EF_Mapper;
using Model.DTO.DTO_Ad;
using DAL.DAL_Ad;
using DAL.DAL_Model;

namespace BLL.BLL_Ad
{
    public class BLL_Admin_Acc
    {
        DAL_Admin_Acc admin_Acc_dal = new DAL_Admin_Acc();
        public List<DTO_Account> GetAllAccounts()
        {
            EntityMapper<Account, DTO_Account> mapObj = new EntityMapper<Account, DTO_Account>();
            List<Account> account = admin_Acc_dal.GetAllAccounts();
            List<DTO_Account> dTO_Accounts = new List<DTO_Account>();
            foreach (var item in account)
            {
                dTO_Accounts.Add(mapObj.Translate(item));
            }
            return dTO_Accounts;
        }
        public List<DTO_Account_Role> GetAllAccounts2()
        {
            EntityMapper<Account_Role, DTO_Account_Role> mapObj = new EntityMapper<Account_Role, DTO_Account_Role>();
            List<Account_Role> account = admin_Acc_dal.GetAllAccounts2();
            List<DTO_Account_Role> dTO_Accounts = new List<DTO_Account_Role>();
            foreach (var item in account)
            {
                dTO_Accounts.Add(mapObj.Translate(item));
            }
            return dTO_Accounts;
        }
        public DTO_Account GetAccountById(int id)
        {
            EntityMapper<Account, DTO_Account> mapObj = new EntityMapper<Account, DTO_Account>();
            Account account = admin_Acc_dal.GetAccountById(id);
            DTO_Account dTO_Accounts = mapObj.Translate(account);
         
            return dTO_Accounts;
        }
        public bool Create_Ad_acc (DTO_Account dTO_Account)
        {
            EntityMapper<DTO_Account, Account> mapObj = new EntityMapper<DTO_Account, Account>();
            Account account = mapObj.Translate(dTO_Account);
            return admin_Acc_dal.Create(account);
        }
        public bool Update_Ad_acc(DTO_Account dTO_Account)
        {
            EntityMapper<DTO_Account, Account> mapObj = new EntityMapper<DTO_Account, Account>();
            Account account = mapObj.Translate(dTO_Account);
            return admin_Acc_dal.Edit(account);
        }
        public bool Update_Ad_acc2(DTO_Account dTO_Account)
        {
            EntityMapper<DTO_Account, Account> mapObj = new EntityMapper<DTO_Account, Account>();
            Account account = mapObj.Translate(dTO_Account);
            return admin_Acc_dal.Edit2(account);
        }
        public bool DeleteAccount (int id)
        {
            return admin_Acc_dal.DeleteAccount(id);
        }

    }
}
