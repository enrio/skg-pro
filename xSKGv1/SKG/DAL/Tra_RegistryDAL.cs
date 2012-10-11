using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL
{
    using Entities;
    using SKG.Extend;
    using System.Data;

    /// <summary>
    /// Vận tải - Xử lí bảng Tra_Registry
    /// </summary>
    public abstract class Tra_RegistryDAL : BaseDAL, IBase
    {
        #region Implement
        /// <summary>
        /// Đếm số dòng trong bảng
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _db.Tra_Registries.Count();
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
                var res = from s in _db.Tra_Registries
                          where s.TariffId == fKey
                          orderby s.Order
                          select new
                          {
                              s.Id,
                              s.Text,
                              Descript = s.Note,
                              s.Tariff.Price1,
                              s.Tariff.Price2,

                              s.Code,
                              s.Order,
                              s.Show
                          };

                return res.ToDataTable();
            }
            catch { return _tb; }
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
                return _db.Tra_Registries.SingleOrDefault(s => s.Code == code);
            }
            catch { return null; }
        }

        /// <summary>
        /// Lấy dữ liệu, obj = null: lấy tất cả
        /// </summary>
        /// <param name="obj">Đối tượng Tra_Registry cần lọc</param>
        /// <param name="skip">Số dòng bỏ qua</param>
        /// <param name="take">Số dòng cần lấy</param>
        /// <returns>Dữ liệu</returns>
        public DataTable Select(object obj = null, int skip = 0, int take = 0)
        {
            try
            {
                var res = from s in _db.Tra_Registries
                          //join k in _db.Pol_Dictionarys on s.DepartureId equals k.Id
                          orderby s.Vehicle.Transport.Text
                          select new
                          {
                              s.Id,
                              s.VehicleId,
                              Number = s.Vehicle.Code,
                              Transport = s.Vehicle.Transport.Text,
                              s.TariffId,
                              Tariff = s.Tariff.Text,
                              s.CommissionId,
                              Commission = s.Commission.Text,
                              s.Tariff.Price1,
                              s.Tariff.Price2,

                              //Tariff=  k.Text,

                              s.ArrivalId,
                              //Arrival = s.Arrival.Text,
                              s.DepartureId,
                              //Departure = s.Departure.Text,
                              s.TimeLeaves,
                              s.Code,
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
        /// <param name="obj">Đối tượng Tra_Registry</param>
        /// <returns>Khác null: thêm thành công</returns>
        public object Insert(object obj)
        {
            try
            {
                var o = (Tra_Registry)obj;
                o.Id = Guid.NewGuid();
                var oki = _db.Tra_Registries.Add(o);

                _db.SaveChanges();
                return oki;
            }
            catch { return null; }
        }

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="obj">Đối tượng Tra_Registry</param>
        /// <returns>Khác null: sửa thành công</returns>
        public object Update(object obj)
        {
            try
            {
                var o = (Tra_Registry)obj;
                var res = _db.Tra_Registries.SingleOrDefault(s => s.Id == o.Id);

                res.TariffId = o.TariffId;
                res.CommissionId = o.CommissionId;
                res.TimeLeaves = o.TimeLeaves;

                res.Text = o.Text;

                res.Code = o.Code;
                res.Note = o.Note;
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
                    var res = _db.Tra_Registries.SingleOrDefault(s => s.Id == id);
                    _db.Tra_Registries.Remove(res);
                }
                else
                {
                    var tmp = _db.Tra_Registries.ToList();
                    tmp.ForEach(s => _db.Tra_Registries.Remove(s));
                }

                return _db.SaveChanges();
            }
            catch { return null; }
        }
        #endregion
    }
}