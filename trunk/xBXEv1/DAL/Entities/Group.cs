using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Nhóm xe
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        public long Id { set; get; }

        /// <summary>
        /// Tên nhóm xe
        /// </summary>
        [StringLength(200)]
        public string Name { set; get; }

        /// <summary>
        /// Mô tả nhóm xe
        /// </summary>
        [StringLength(200)]
        public string Descript { set; get; }

        /// <summary>
        /// Danh sách loại xe
        /// </summary>
        public virtual ICollection<Kind> Kinds { get; set; }
    }
}