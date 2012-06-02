using System;
using System.Collections.Generic;
using System.Linq;

namespace UTL
{
    using System.Data;

    /// <summary>
    /// Các phương thức cơ bản của Data Access Layer (DAL)
    /// </summary>
    public interface IBaseDAL
    {
        /// <summary>
        /// Đếm số dòng trong bảng
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// Tìm theo mã (cột Code)
        /// </summary>
        /// <param name="code">Mã cần tìm</param>
        /// <returns>Đối tượng tìm</returns>
        object Select(string code);

        /// <summary>
        /// Tìm theo khoá ngoại
        /// </summary>
        /// <param name="fKey">Khoá ngoại</param>
        /// <returns>Dữ liệu</returns>
        DataTable Select(Guid fKey);

        /// <summary>
        /// Lấy dữ liệu, obj = null: lấy tất cả
        /// </summary>
        /// <param name="obj">Đối tượng (các class trong Entities) cần lọc</param>
        /// <param name="skip">Số dòng bỏ qua</param>
        /// <param name="take">Số dòng cần lấy</param>
        /// <returns>Dữ liệu</returns>
        DataTable Select(object obj = null, int skip = 0, int take = 0);

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="obj">Đối tượng (các class trong Entities)</param>
        /// <returns>Khác null: thêm thành công</returns>
        object Insert(object obj);

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="obj">Đối tượng (các class trong Entities)</param>
        /// <returns>Khác null: sửa thành công</returns>
        object Update(object obj);

        /// <summary>
        /// Xoá dữ liệu, không nhập khoá sẽ xoá tất cả
        /// </summary>
        /// <param name="id">Khoá chính</param>
        /// <returns>Khác null: xoá thành công</returns>
        object Delete(Guid id = new Guid());
    }
}