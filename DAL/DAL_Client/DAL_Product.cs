using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace DAL.DAL_Client
{
    public class DAL_Product
    {
        OnlineShopEntities db = new OnlineShopEntities();
        public List<Product> GetAllRoducts()
        {
            //bool item = db.Items.Select(t => t.Id_SanPham == 11).SingleOrDefault();
            var acc = db.Accounts.Select(t => t.idUser == 5).FirstOrDefault();
            var temp = db.Accounts.ToList();
            return db.Products.ToList();

        }
        public Product GetProductById(int id)
        {
            return db.Products.Where(s => s.Id_SanPham == id).FirstOrDefault();
        }
    }
}
