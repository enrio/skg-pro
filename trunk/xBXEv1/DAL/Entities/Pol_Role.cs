using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Chính sách - Vai trò
    /// </summary>
    public class Pol_Role : Info
    {
        [Key]
        public Guid Id { set; get; }

        public string Name { set; get; }
        public string Descript { set; get; }

        public virtual ICollection<Pol_UserRole> Pol_UserRoles { get; set; }
        public virtual ICollection<Pol_RoleRight> Pol_RoleRights { get; set; }
    }
}