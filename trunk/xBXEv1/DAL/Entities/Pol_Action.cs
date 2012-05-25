using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Chính sách - Danh sách tên các hành động: Thêm, Xoá, Sửa, Truy vấn, In ấn, Tất cả, Không có
    /// 
    /// Tác giả:    Nguyễn Văn Toàn - LT11780
    /// Điện thoại: 01645 515 010
    /// Hộp thư:    nvt87x@gmail.com
    /// </summary>
    public class Pol_Action : Info
    {
        public string Name { set; get; }
    }
}