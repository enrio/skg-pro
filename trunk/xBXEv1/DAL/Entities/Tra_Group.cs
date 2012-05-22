using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Tra_Group
    {
        public Guid Id { set; get; }

        public string Name { set; get; }
        public string Descript { set; get; }

        public virtual ICollection<Tra_Kind> Kinds { get; set; }
    }
}