using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Chính sách - Quyền hạn
    /// </summary>
    public class Pol_Right : Info
    {
        [Key]
        public Guid Id { set; get; }

        public string Name { set; get; }
        public string Descript { set; get; }

        public virtual ICollection<Pol_RoleRight> Pol_RoleRights { get; set; }
        public virtual ICollection<Pol_UserRight> Pol_UserRights { get; set; }
    }
}