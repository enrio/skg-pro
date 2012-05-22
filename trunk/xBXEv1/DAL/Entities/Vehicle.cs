using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Xe cộ
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        public long Id { set; get; }

        /// <summary>
        /// Biển số xe (không trùng nhau)
        /// </summary>
        [StringLength(200)]
        public string Number { set; get; }

        /// <summary>
        /// Mô tả xe (trọng tải, số ghế, màu xe, ...)
        /// </summary>
        [StringLength(200)]
        public string Descript { set; get; }

        /// <summary>
        /// Họ tên tài xế
        /// </summary>
        [StringLength(200)]
        public string Name { set; get; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime Birth { set; get; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        [StringLength(200)]
        public string Address { set; get; }

        /// <summary>
        /// Điện thoại
        /// </summary>
        [StringLength(200)]
        public string Phone { set; get; }

        /// <summary>
        /// Mã loại xe
        /// </summary>
        public long KindId { set; get; }

        /// <summary>
        /// Khoá ngoại loại xe
        /// </summary>
        public virtual Kind Kind { get; set; }

        /// <summary>
        /// Chi tiết ra vào
        /// </summary>
        public virtual ICollection<Detail> Details { get; set; }
    }
}