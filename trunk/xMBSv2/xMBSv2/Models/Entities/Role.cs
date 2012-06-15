using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xMBSv2.Models.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Role
    {
        [Key]
        public virtual Guid RoleId { get; set; }

        [Required]
        public virtual string RoleName { get; set; }

        public virtual string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}