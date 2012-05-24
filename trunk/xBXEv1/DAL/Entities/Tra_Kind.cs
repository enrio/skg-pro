using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Vận tải - Loại xe
    /// </summary>
    public class Tra_Kind : Info
    {
        [Key]
        public Guid Id { set; get; }

        [ForeignKey("Tra_Group")]
        public Guid? Tra_GroupId { set; get; }
        public virtual Tra_Group Tra_Group { get; set; }

        public string Code { set; get; }
        public string Name { set; get; }
        public string Descript { set; get; }
        public int Price1 { set; get; }
        public int Price2 { set; get; }

        public virtual ICollection<Tra_Vehicle> Tra_Vehicles { get; set; }
    }
}