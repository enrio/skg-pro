﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Chính sách - Người dùng có vai trò
    /// </summary>
    public class Pol_UserRole : ZInfor
    {
        [Key, Column(Order = 0), ForeignKey("Pol_User")]
        public Guid? Pol_UserId { set; get; }
        public virtual Pol_User Pol_User { get; set; }

        [Key, Column(Order = 1), ForeignKey("Pol_Role")]
        public Guid? Pol_RoleId { set; get; }
        public virtual Pol_Role Pol_Role { get; set; }

        public bool Add { set; get; }
        public bool Edit { set; get; }
        public bool Delete { set; get; }
        public bool Query { set; get; }
        public bool Print { set; get; }
        public bool Full { set; get; }
        public bool None { set; get; }
    }
}