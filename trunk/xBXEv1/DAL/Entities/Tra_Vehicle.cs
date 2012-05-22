using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Tra_Vehicle
    {
        public Guid Id { set; get; }

        public string Number { set; get; }
        public string Descript { set; get; }
        public string Driver { set; get; }
        public DateTime Birth { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        
        public virtual ICollection<Tra_Detail> Details { get; set; }

        [ForeignKey("Kind")]
        public Guid? KindId { set; get; }
        public virtual Tra_Kind Kind { get; set; }
    }
}