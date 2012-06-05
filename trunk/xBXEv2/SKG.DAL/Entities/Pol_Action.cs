using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    /// <summary>
    /// Chính sách - Danh sách tên các hành động: Thêm, Sửa, Xoá, In ấn, Truy cập, Tất cả, Không có, Mặc định
    /// </summary>
    public class Pol_Action : ZInfor
    {
        /// <summary>
        /// Tên hành động
        /// </summary>
        public string Name { set; get; }
    }
}