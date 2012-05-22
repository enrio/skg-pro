using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class RoleRight
    {
        [Key]
        public Guid RoleId { set; get; }
        [Key]
        public Guid RightId { set; get; }

        public bool Add { set; get; }
        public bool Edit { set; get; }
        public bool Delete { set; get; }
        public bool Query { set; get; }
        public bool Print { set; get; }
        public bool Full { set; get; }
        public bool None { set; get; }
    }
}