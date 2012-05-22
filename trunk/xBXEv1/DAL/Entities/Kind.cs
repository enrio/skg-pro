using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Kind
    {
        public Guid Id { set; get; }

        public string Name { set; get; }
        public string Descript { set; get; }
        public int Price1 { set; get; }
        public int Price2 { set; get; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }

        [ForeignKey("Group")]
        public Guid? GroupId { set; get; }
        public virtual Group Group { get; set; }
    }
}