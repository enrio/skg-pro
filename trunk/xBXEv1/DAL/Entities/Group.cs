using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Group
    {
        public Guid Id { set; get; }

        public string Name { set; get; }
        public string Descript { set; get; }

        public virtual ICollection<Kind> Kinds { get; set; }
    }
}