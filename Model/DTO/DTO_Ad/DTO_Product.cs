using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.DTO_Ad
{
    public class DTO_Product
    {
        public DTO_Product()
        {
            Photo = "~/images_product/ap.jpg";
        }
        [Key]
        
        public int Id_SanPham { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Price { get; set; }

        [StringLength(50)]
        public string Photo { get; set; }
        //public HttpPostedFileBase ImageUpload { get; set; }

        public string Details { get; set; }

        //public int Id_Item { get; set; }

       // public virtual DTO_Item Item { get; set; }

        //public virtual Item_Type Item_Type { get; set; }
    }
}
