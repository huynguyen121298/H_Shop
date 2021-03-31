using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.DTO_Ad
{
    public class DTO_Account_Role
    {
        public int idUser { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string Details { get; set; }
    }
}
