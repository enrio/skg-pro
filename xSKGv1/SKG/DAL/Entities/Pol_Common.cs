using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    /// <summary>
    /// Policy - Common data
    /// </summary>
    public class Pol_Common : Zinfors
    {
        public Guid? ParentId { get; set; }
        public virtual Pol_Common Parent { get; set; }
        public virtual ICollection<Pol_Common> Children { get; set; }
    }
}