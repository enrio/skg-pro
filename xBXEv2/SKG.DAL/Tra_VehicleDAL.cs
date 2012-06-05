using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL
{
    using SKG.UTL;
    using System.Data;
    using Entities;

    /// <summary>
    /// Vận tải - Xử lí bảng Tra_Vehicle
    /// </summary>
    public abstract class Tra_VehicleDAL : BaseDAL, IBaseDAL
    {
        #region Implement
        /// <summary>
        /// Đếm số dòng trong bảng
        /// </summary>
        /// <returns>Số dòng</returns>
        public int Count()
        {
            return _db.Tra_Vehicles.Count();
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
                return _db.Tra_Vehicles.SingleOrDefault(s => s.Number == code);
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
            try
            {
                var res = from s in _db.Tra_Vehicles

                          where s.Tra_KindId == fKey
                          orderby s.Order

                          select new
                          {
                              s.Id,
                              s.Number,
                              s.Driver,
                              s.Birth,
                              s.Address,
                              s.Phone,

                              s.Code,
                              s.Descript,
                              s.Order,
                              s.Show
                          };

                return res.ToDataTable();
            }
            catch { return _tb; }
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
                var res = from s in _db.Tra_Vehicles
                          select new
                          {
                              s.Id,
                              s.Number,
                              s.Driver,
                              s.Birth,
                              s.Address,
                              s.Phone,

                              s.Code,
                              s.Descript,
                              s.Order,
                              s.Show
                          };

                if (obj != null) res = res.Where(s => s.Number == obj + "");
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
                var o = (Tra_Vehicle)obj;
                o.Id = Guid.NewGuid();
                var oki = _db.Tra_Vehicles.Add(o);

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
                var o = (Tra_Vehicle)obj;
                var res = _db.Tra_Vehicles.SingleOrDefault(s => s.Id == o.Id);

                res.Tra_KindId = o.Tra_KindId;
                res.Number = o.Number;
                res.Driver = o.Driver;
                res.Birth = o.Birth;
                res.Address = o.Address;
                res.Phone = o.Phone;

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
                    var res = _db.Tra_Vehicles.SingleOrDefault(s => s.Id == id);
                    _db.Tra_Vehicles.Remove(res);
                }
                else
                {
                    var tmp = _db.Tra_Vehicles.ToList();
                    tmp.ForEach(s => _db.Tra_Vehicles.Remove(s));
                }

                return _db.SaveChanges();
            }
            catch { return null; }
        }
        #endregion
    }
}