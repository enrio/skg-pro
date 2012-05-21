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
        /// Mã nhóm loại xe
        /// </summary>
        public long GroupId { set; get; }

        /// <summary>
        /// Mô tả nhóm xe
        /// </summary>
        [StringLength(200)]
        public string Descript { set; get; }

        /// <summary>
        /// Chiều dài tối thiểu
        /// </summary>
        public decimal LengthMin { set; get; }

        /// <summary>
        /// Chiều dài tối đa
        /// </summary>
        public decimal LengthMax { set; get; }

        /// <summary>
        /// Số ghế tối thiểu
        /// </summary>
        public int ChairMin { set; get; }

        /// <summary>
        /// Số ghế tối đa
        /// </summary>
        public int ChairMax { set; get; }

        /// <summary>
        /// Trọng tải tối thiểu
        /// </summary>
        public decimal WeightMin { set; get; }

        /// <summary>
        /// Trọng tải tối đa
        /// </summary>
        public decimal WeightMax { set; get; }

        /// <summary>
        /// Đơn giá nửa ngày
        /// </summary>
        public decimal Money1 { set; get; }

        /// <summary>
        /// Đơn giá một ngày
        /// </summary>
        public decimal Money2 { set; get; }

        public virtual Group Group { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}