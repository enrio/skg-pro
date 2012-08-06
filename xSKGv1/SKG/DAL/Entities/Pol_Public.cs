using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Policy - Data for public
    /// </summary>
    public class Pol_Public : Zinfors
    {
        public Guid? ParentId { get; set; }
        public virtual Pol_Public Parent { get; set; }
        public virtual ICollection<Pol_Public> Children { get; set; }
    }
}