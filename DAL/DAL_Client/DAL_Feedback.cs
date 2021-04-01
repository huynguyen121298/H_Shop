using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL_Client
{
   public class DAL_Feedback
    {
        OnlineShopEntities db = new OnlineShopEntities();
        public bool InsertFeedback(Feedback fb)
        {
            try
            {
                db.Feedbacks.Add(fb);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
