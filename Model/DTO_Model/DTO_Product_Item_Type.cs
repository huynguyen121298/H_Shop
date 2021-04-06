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
            Photo = "~/images_product/gallery-add-512.png";
        }
        [Required(ErrorMessage = "Yêu cầu nhập mã sản phẩm")]
        public int Id_SanPham { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập số lượng")]
        public int? Quantity { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập loại sản phẩm")]
        public int Id_Item { get; set; }
        public string Type_Product { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập tên sản phẩm")]
        [StringLength(50)]
        public string Name { get; set; }

        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage = "Yêu cầu nhập giá sản phẩm")]
        public int? Price { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập hình ảnh")]
        [StringLength(50)]
        public string Photo { get; set; }
        
        
        public string Details { get; set; }
        //public DTO_Product_Item_Type() { }

        //public DTO_Product proModel{ get; set; }
        //public <DTO_Item itemModel { get; set; }


    }
}
