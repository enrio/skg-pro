﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 09/08/2013 20:32
 * Update: 09/08/2013 20:32
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL
{
    using Entities;
    using SKG.Extend;
    using System.Data;

    /// <summary>
    /// Vận tải - Xử lí bảng Tra_Vehicle
    /// </summary>
    public abstract class Tra_VehicleDAL : BaseDAL, IBase
    {
        #region Implement
        /// <summary>
        /// Đếm số dòng trong bảng
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _db.Tra_Vehicles.Count();
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
                          where s.TransportId == fKey
                          orderby s.Order
                          select new
                          {
                              s.Id,
                              s.Code,
                              s.TransportId,
                              Transport = s.Transport.Text,

                              s.Seats,
                              s.Beds,

                              s.High,
                              s.City,

                              s.ProductionYear,
                              s.LimitedRegistration,
                              s.TermInsurance,
                              s.TermFixedRoutes,
                              s.TermDriverLicense,

                              s.Fixed,
                              s.ServerQuality,
                              s.Driver,
                              s.Birth,
                              s.Address,
                              s.Phone,

                              s.Text,
                              s.Note,
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
                var gui = new Guid();
                var ok = Guid.TryParse(code, out gui);
                if (ok) return _db.Tra_Vehicles.SingleOrDefault(s => s.Id == gui);
                return _db.Tra_Vehicles.SingleOrDefault(s => s.Code == code);
            }
            catch { return null; }
        }

        /// <summary>
        /// Lấy dữ liệu, obj = null: lấy tất cả
        /// </summary>
        /// <param name="obj">Đối tượng Tra_Vehicle cần lọc</param>
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
                              s.Code,
                              s.TransportId,
                              Transport = s.Transport.Text,

                              s.Seats,
                              s.Beds,

                              s.High,
                              s.City,

                              s.ProductionYear,
                              s.LimitedRegistration,
                              s.TermInsurance,
                              s.TermFixedRoutes,
                              s.TermDriverLicense,

                              s.Fixed,
                              s.ServerQuality,
                              s.Driver,
                              s.Birth,
                              s.Address,
                              s.Phone,

                              s.Text,
                              s.Note,
                              s.Order,
                              s.Show
                          };

                var dk = obj + "";
                if (obj != null) res = res.Where(s => s.Code == dk);
                if (take > 0) res = res.Take(take);

                return res.ToDataTable();
            }
            catch { return _tb; }
        }

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="obj">Đối tượng Tra_Vehicle</param>
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
        /// <param name="obj">Đối tượng Tra_Vehicle</param>
        /// <returns>Khác null: sửa thành công</returns>
        public object Update(object obj)
        {
            try
            {
                var o = (Tra_Vehicle)obj;
                var res = _db.Tra_Vehicles.SingleOrDefault(s => s.Id == o.Id);

                res.Code = o.Code;
                res.TransportId = o.TransportId;


                res.Seats = o.Seats;
                res.Beds = o.Beds;

                res.High = o.High;
                res.City = o.City;

                res.ProductionYear = o.ProductionYear;
                res.LimitedRegistration = o.LimitedRegistration;
                res.TermInsurance = o.TermInsurance;
                res.TermFixedRoutes = o.TermFixedRoutes;
                res.TermDriverLicense = o.TermDriverLicense;

                res.Fixed = o.Fixed;
                res.ServerQuality = o.ServerQuality;
                res.Driver = o.Driver;
                res.Birth = o.Birth;
                res.Address = o.Address;
                res.Phone = o.Phone;

                res.Text = o.Text;
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