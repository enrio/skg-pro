﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Chính sách - Người dùng
    /// </summary>
    public class Pol_User : ZInfor
    {
        [Key]
        public Guid Id { set; get; }

        public string Acc { set; get; }
        public string Pass { set; get; }
        public string Name { set; get; }
        public DateTime Birth { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }

        public virtual ICollection<Pol_UserRight> Pol_UserRights { get; set; }
        public virtual ICollection<Pol_UserRole> Pol_UserRoles { get; set; }
    }
}