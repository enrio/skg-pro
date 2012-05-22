using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Chính sách - Quyền hạn
    /// </summary>
    public class Pol_Right
    {
        [Key]
        public Guid Id { set; get; }

        public string Name { set; get; }
        public string Descript { set; get; }
    }
}