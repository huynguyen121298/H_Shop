using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.DTO_Ad
{
    public class DTO_Role
    {
        public int RoleId { get; set; }

        [StringLength(50)]
        public string RoleName { get; set; }

        [StringLength(10)]
        public string Details { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DTO_Account> Accounts { get; set; }
    }
}
