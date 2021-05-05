using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL_Model
{
    public class CheckoutCustomer_Order
    {
        public int Id_KH { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int SDT { get; set; }
        public string DiaChi { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public Nullable<double> GiamGia { get; set; }
        public Nullable<double> TongTien { get; set; }
        public string TrangThai { get; set; }
        public int ID { get; set; }

        public List<Checkout_Oder> Checkout_Orders { get; set; }
    }
   }
