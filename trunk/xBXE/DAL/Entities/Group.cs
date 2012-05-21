using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Nhóm loại xe
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        public long Id { set; get; }

        /// <summary>
        /// Tên nhóm loại xe
        /// </summary>
        [StringLength(200)]
        public string Name { set; get; }

        public virtual ICollection<Kind> Kinds { get; set; }
    }
}