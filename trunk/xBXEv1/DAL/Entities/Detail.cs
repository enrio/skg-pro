using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Chi tiết xe ra vào
    /// </summary>
    public class Detail
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        public long Id { set; get; }

        /// <summary>
        /// Mã nhân viên cho xe vào
        /// </summary>
        public long AccIn { set; get; }

        /// <summary>
        /// Mã nhân viên cho xe ra
        /// </summary>
        public long AccOut { set; get; }

        /// <summary>
        /// Biển số xe
        /// </summary>
        [StringLength(200)]
        public string Number { set; get; }

        /// <summary>
        /// Giờ vào bến
        /// </summary>
        public DateTime DateIn { set; get; }

        /// <summary>
        /// Giờ xuất bến
        /// </summary>
        public DateTime DateOut { set; get; }

        /// <summary>
        /// Số ngày đậu tại bến
        /// </summary>
        public int Day { set; get; }

        /// <summary>
        /// Số giờ lẻ đậu tại bến
        /// </summary>
        public int Hour { set; get; }

        /// <summary>
        /// Đơn giá nửa ngày
        /// </summary>
        public decimal Price1 { set; get; }

        /// <summary>
        /// Đơn giá một ngày
        /// </summary>
        public decimal Price2 { set; get; }

        /// <summary>
        /// Thành tiền
        /// </summary>
        public decimal Money { set; get; }

        /// <summary>
        /// Nhân viên cho xe vào
        /// </summary>
        public virtual User UserIn { get; set; }

        /// <summary>
        /// Nhân viên cho xe ra
        /// </summary>
        public virtual User UserOut { get; set; }

        /// <summary>
        /// Xe ra vào
        /// </summary>
        public virtual Vehicle Vehicle { get; set; }
    }
}