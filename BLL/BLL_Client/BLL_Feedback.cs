using DAL.DAL_Client;
using DAL.EF;
using Model.DTO.DTO_Client;
using Model.EF_Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Client
{
   
   public class BLL_Feedback
    {
        DAL_Feedback dalFb = new DAL_Feedback();
        public bool InsertFeedback(DTO_Feedback dTO_Feedback)
        {
            EntityMapper<DTO_Feedback, Feedback> mapObj = new EntityMapper<DTO_Feedback, Feedback>();
            Feedback account = mapObj.Translate(dTO_Feedback);
            return dalFb.InsertFeedback(account);
        }

        
    }
}
