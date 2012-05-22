﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Pol_RoleRight
    {
        [Key, Column(Order = 0), ForeignKey("Pol_Role")]
        public Guid RoleId { set; get; }
        public virtual Pol_Role Pol_Role { get; set; }

        [Key, Column(Order = 1), ForeignKey("Pol_Right")]
        public Guid RightId { set; get; }
        public virtual Pol_Right Pol_Right { get; set; }

        public bool Add { set; get; }
        public bool Edit { set; get; }
        public bool Delete { set; get; }
        public bool Query { set; get; }
        public bool Print { set; get; }
        public bool Full { set; get; }
        public bool None { set; get; }
    }
}