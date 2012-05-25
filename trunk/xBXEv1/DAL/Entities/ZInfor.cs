using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Thông tin dữ liệu cơ bản
    /// ------------- ^.^ ------------- @.@ -------------
    /// Tác giả:    Nguyễn Văn Toàn - LT11780
    /// Điện thoại: 01645 515 010
    /// Hộp thư:    nvt87x@gmail.com
    /// </summary>
    public abstract class ZInfor
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        [Key, Column(Order = 0)]
        public Guid Id { set; get; }

        /// <summary>
        /// Mã nhập dạng (khi cần sử dụng)
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
        public ZInfor() { Show = true; }
    }
}