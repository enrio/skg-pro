using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    /// <summary>
    /// Chính sách - Danh sách tên các hành động: Thêm, Xoá, Sửa, Truy vấn, In ấn, Tất cả, Không có
    /// </summary>
    public class Pol_Action : ZInfor
    {
        /// <summary>
        /// Tên hành động
        /// </summary>
        public string Name { set; get; }
    }
}