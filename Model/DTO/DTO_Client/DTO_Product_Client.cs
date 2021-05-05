using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.DTO_Client
{
    public class DTO_Product_Client
    {
        // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_SanPham { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Price { get; set; }

        [StringLength(50)]
        public string Photo { get; set; }

        public string Details { get; set; }

        public int Id_Item { get; set; }

        //public virtual DTO_Item_Client Item { get; set; }

      //  public virtual Item_Type Item_Type { get; set; }
    }
}
