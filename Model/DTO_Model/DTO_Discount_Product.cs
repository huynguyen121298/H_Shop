using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO_Model
{
    public class DTO_Discount_Product
    {
        public int ID_Discount { get; set; }
        public string Content { get; set; }
        public Nullable<double> Price_Dis { get; set; }
        public Nullable<System.DateTime> Start { get; set; }
        public Nullable<System.DateTime> End { get; set; }
       
        public Nullable<int> Id_SanPham { get; set; }

       
    }
}
