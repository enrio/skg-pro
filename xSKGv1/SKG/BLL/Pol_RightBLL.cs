using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.BLL
{
    using DAL.Entities;

    /// <summary>
    /// Truy cập cơ sở dữ liệu bảng Pol_Right: danh mục form.
    /// </summary>
    public sealed class Pol_RightBLL : DAL.Pol_RightDAL
    {
        /// <summary>
        /// Thêm thông tin form
        /// </summary>
        /// <param name="code">Mã form (tên class của form)</param>
        /// <param name="name">Tên form</param>
        /// <param name="descript">Mô tả</param>
        /// <returns></returns>
        public object Insert(string code, string name, string descript)
        {
            var o = new Pol_Right() { Code = code, Name = name, Descript = descript };
            return Insert(o);
        }
    }
}