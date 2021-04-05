using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class RegisterModel
    {
        [Key, Column(Order = 1)]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int idUser { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập id")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập FisrtName")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }
       
        [Required(ErrorMessage = "Yêu cầu nhập email")]
        [EmailAddress(ErrorMessage = "Vui lòng nhập email thực.")]
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Mật khẩu")]
       
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string ConfirmPassword { get; set; }

        

    }
}