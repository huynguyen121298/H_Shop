using Model.DTO.DTO_Ad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO_Model
{
   public class DTO_Product_Item_Type
    {
        public DTO_Product_Item_Type()
        {
            Photo = "~/images_product/ap.jpg";
        }
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
        //public DTO_Product_Item_Type() { }

        //public DTO_Product proModel{ get; set; }
        //public <DTO_Item itemModel { get; set; }


    }
}
