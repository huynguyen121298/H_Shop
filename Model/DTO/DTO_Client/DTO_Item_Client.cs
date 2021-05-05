using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.DTO_Client
{
    public class DTO_Item_Client
    {
         List<DTO_Item_Client> items = new List<DTO_Item_Client>();
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_SanPham { get; set; }

        public int? Quantity { get; set; }

        public virtual DTO_Product_Client Product { get; set; }
        public int Total_Quantity()
        {
            return (int)items.Sum(s => s.Quantity);
        }
    }
}
