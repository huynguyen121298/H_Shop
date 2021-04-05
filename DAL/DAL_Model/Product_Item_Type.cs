using DAL.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL_Model
{
    public class Product_Item_Type
    {
        public int Id_SanPham { get; set; }

        public int? Quantity { get; set; }

        public int Id_Item { get; set; }
        public string Type_Product { get; set; }


        [StringLength(50)]
        public string Name { get; set; }

        public int? Price { get; set; }

        [StringLength(50)]
        public string Photo { get; set; }
        //public HttpPostedFileBase ImageUpload { get; set; }

        public string Details { get; set; }

        //public Product_Item_Type() { }

        //public List<Product> proModel { get; set; }
        //public List<Item> itemModel { get; set; }



    }
}
