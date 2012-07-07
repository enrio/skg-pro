using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Thông tin dữ liệu cơ bản
    /// </summary>
    public class Base
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        [Key, Column(Order = 0)]
        public Guid Id { set; get; }

        /// <summary>
        /// Mã nhận dạng (khi cần sử dụng)
        /// </summary>
        [StringLength(256)]
        public string Code { set; get; }

        /// <summary>
        /// Mô tả chi tiết, ghi chú, ...
        /// </summary>
        public string Descript { set; get; }

        /// <summary>
        /// Sắp xếp thứ tự
        /// </summary>
        public int Order { set; get; }

        /// <summary>
        /// Hiện dữ liệu
        /// </summary>
        public bool Show { set; get; }

        /// <summary>
        /// Mặc định dữ liệu được hiện
        /// </summary>
        public Base() { Show = true; }
    }
}