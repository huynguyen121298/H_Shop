using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.DTO_Ad
{
    public class DTO_Checkout_Customer
    {

        [Key]
       
        public int Id_KH { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public int SDT { get; set; }

        [Required]
        [StringLength(50)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        public string Zipcode { get; set; }

        public DateTime? NgayTao { get; set; }

        public double? GiamGia { get; set; }

        public double? TongTien { get; set; }
        public string TrangThai { get; set; }

       // public virtual ICollection<Checkout_Oder> Checkout_Oder { get; set; }
    }
}
