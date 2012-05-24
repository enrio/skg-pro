using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Vận tải - Nhóm xe
    /// </summary>
    public class Tra_Group : Info
    {
        [Key]
        public Guid Id { set; get; }

        public string Name { set; get; }
        public string Descript { set; get; }

        public virtual ICollection<Tra_Kind> Tra_Kinds { get; set; }
    }
}