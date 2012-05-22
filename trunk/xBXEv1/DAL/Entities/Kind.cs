using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Loại xe
    /// </summary>
    public class Kind
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        public long Id { set; get; }

        /// <summary>
        /// Tên loại xe
        /// </summary>
        [StringLength(200)]
        public string Name { set; get; }

        /// <summary>
        /// Mô tả loại xe
        /// </summary>
        [StringLength(200)]
        public string Descript { set; get; }

        /// <summary>
        /// Đơn giá nửa ngày
        /// </summary>
        public int Price1 { set; get; }

        /// <summary>
        /// Đơn giá một ngày
        /// </summary>
        public int Price2 { set; get; }

        /// <summary>
        /// Mã nhóm xe
        /// </summary>
        public long GroupId { set; get; }

        /// <summary>
        /// Khoá ngoại nhóm xe
        /// </summary>
        public virtual Group Group { get; set; }

        /// <summary>
        /// Danh sách xe
        /// </summary>
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}