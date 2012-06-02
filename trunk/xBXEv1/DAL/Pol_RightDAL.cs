using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    using System.Data;
    using Entities;

    /// <summary>
    /// Chính sách - Xử lí bảng Pol_Right
    /// </summary>
    public abstract class Pol_RightDAL : BaseDAL, UTL.IBaseDAL
    {
        #region Implement
        /// <summary>
        /// Đếm số dòng trong bảng
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _db.Pol_Rights.Count();
        }

        /// <summary>
        /// Tìm theo khoá ngoại
        /// </summary>
        /// <param name="fKey">Khoá ngoại</param>
        /// <returns>Dữ liệu</returns>
        public DataTable Select(Guid fKey)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Tìm theo mã (cột Code)
        /// </summary>
        /// <param name="code">Mã cần tìm</param>
        /// <returns>Đối tượng tìm</returns>
        public object Select(string code)
        {
            try
            {
                return _db.Pol_Rights.SingleOrDefault(s => s.Code == code);
            }
            catch { return null; }
        }

        /// <summary>
        /// Lấy dữ liệu, obj = null: lấy tất cả
        /// </summary>
        /// <param name="obj">Đối tượng Pol_Right cần lọc</param>
        /// <param name="skip">Số dòng bỏ qua</param>
        /// <param name="take">Số dòng cần lấy</param>
        /// <returns>Dữ liệu</returns>
        public DataTable Select(object obj = null, int skip = 0, int take = 0)
        {
            try
            {
                var res = from s in _db.Pol_Rights
                          select new
                          {
                              s.Id,
                              s.Code,
                              s.Name,
                              s.Descript
                          };

                if (obj != null) res = res.Where(s => s.Code == obj + "");
                if (take > 0) res = res.Skip(skip).Take(take);

                return res.ToDataTable();
            }
            catch { return _tb; }
        }

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="obj">Đối tượng Pol_Right</param>
        /// <returns>Khác null: thêm thành công</returns>
        public object Insert(object obj)
        {
            try
            {
                var o = (Pol_Right)obj;
                o.Id = Guid.NewGuid();
                var oki = _db.Pol_Rights.Add(o);

                _db.SaveChanges();
                return oki;
            }
            catch { return null; }
        }

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="obj">Đối tượng Pol_Right</param>
        /// <returns>Khác null: sửa thành công</returns>
        public object Update(object obj)
        {
            try
            {
                var o = (Pol_Right)obj;
                var res = _db.Pol_Rights.SingleOrDefault(s => s.Id == o.Id);

                res.Name = o.Name;

                res.Code = o.Code;
                res.Descript = o.Descript;
                res.Order = o.Order;
                res.Show = o.Show;

                return _db.SaveChanges();
            }
            catch { return null; }
        }

        /// <summary>
        /// Xoá dữ liệu, không nhập khoá sẽ xoá tất cả
        /// </summary>
        /// <param name="id">Khoá chính</param>
        /// <returns>Khác null: xoá thành công</returns>
        public object Delete(Guid id = new Guid())
        {
            try
            {
                if (id != new Guid())
                {
                    var res = _db.Pol_Rights.SingleOrDefault(s => s.Id == id);
                    _db.Pol_Rights.Remove(res);
                }
                else
                {
                    var tmp = _db.Pol_Rights.ToList();
                    tmp.ForEach(s => _db.Pol_Rights.Remove(s));
                }

                return _db.SaveChanges();
            }
            catch { return null; }
        }
        #endregion
    }
}