using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL
{
    using Entities;
    using SKG.Extend;
    using System.Data;

    /// <summary>
    /// Chính sách - Xử lí bảng Pol_Menu
    /// </summary>
    public abstract class Pol_MenuDAL : BaseDAL, IBase
    {
        #region Implement
        /// <summary>
        /// Đếm số dòng trong bảng
        /// </summary>
        /// <returns>Số dòng</returns>
        public int Count()
        {
            return _db.Pol_Menus.Count();
        }

        /// <summary>
        /// Tìm theo mã (cột Code), hoặc cột khác
        /// </summary>
        /// <param name="code">Mã cần tìm</param>
        /// <returns>Đối tượng tìm</returns>
        public object Select(string code)
        {
            try
            {
                return _db.Pol_Menus.SingleOrDefault(s => s.Code == code);
            }
            catch { return null; }
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
        /// Lấy dữ liệu, obj = null: lấy tất cả
        /// </summary>
        /// <param name="obj">Đối tượng cần lọc</param>
        /// <param name="skip">Số dòng bỏ qua</param>
        /// <param name="take">Số dòng cần lấy</param>
        /// <returns>Dữ liệu</returns>
        public DataTable Select(object obj = null, int skip = 0, int take = 0)
        {
            try
            {
                var res = from s in _db.Pol_Menus
                          orderby s.Type.Substring(1, 3), s.Order
                          select new
                          {
                              s.Id,
                              s.Level,
                              s.Caption,
                              s.LangF,
                              s.LangS,
                              s.LangT,
                              s.Type,
                              s.Picture,

                              s.Code,
                              s.Descript,
                              s.Order,
                              s.Show
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
        /// <param name="obj">Đối tượng cần thêm</param>
        /// <returns>Khác null: thêm thành công</returns>
        public object Insert(object obj)
        {
            try
            {
                var o = (Pol_Menu)obj;
                o.Id = Guid.NewGuid();
                var oki = _db.Pol_Menus.Add(o);

                _db.SaveChanges();
                return oki;
            }
            catch { return null; }
        }

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="obj">Đối tượng cần sửa</param>
        /// <returns>Khác null: sửa thành công</returns>
        public object Update(object obj)
        {
            try
            {
                var o = (Pol_Menu)obj;
                var res = _db.Pol_Menus.SingleOrDefault(s => s.Id == o.Id);

                res.Level = o.Level;
                res.Caption = o.Caption;
                res.LangF = o.LangF;
                res.LangS = o.LangS;
                res.LangT = o.LangT;
                res.Type = o.Type;
                res.Picture = o.Picture;

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
                    var res = _db.Pol_Menus.SingleOrDefault(s => s.Id == id);
                    _db.Pol_Menus.Remove(res);
                }
                else
                {
                    var tmp = _db.Pol_Menus.ToList();
                    tmp.ForEach(s => _db.Pol_Menus.Remove(s));
                }

                return _db.SaveChanges();
            }
            catch { return null; }
        }
        #endregion
    }
}