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
            var res = (from s in _db.Tra_Vehicles
                       where s.Code == ""
                       select s.Tra_Details).FirstOrDefault();

            var r = (from s in res
                     where s.UserOutId == null
                     select s).FirstOrDefault();



            //foreach (var x in res) 
            //{
            //   var xu= x.Sum(o => o.Money);
            //}

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
                              s.Node,
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
                if (code.ToUpper().Contains("BG"))
                {
                    var res = from s in _db.Tra_Vehicles
                              where !_db.Tra_Details.Any(p => p.VehicleId == s.Id && p.UserOutId == null)
                              && s.Tariff.Code == "J"
                              orderby s.Code
                              select s;
                    return res.FirstOrDefault();
                }
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
                              s.TariffId,
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
                              s.Node,
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
                if (Select(o.Code, o.Fixed) != null) return null; // number already exists

                o.Id = Guid.NewGuid();
                o.CreatorId = Global.Session.User.Id;
                o.CreateDate = Global.Session.Current;
                o.Code = o.Code.ToUpper();

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
                if (res.Code.ToUpper() != o.Code.ToUpper())
                    if (Select(o.Code, o.Fixed) != null) return null; // number already exists

                res.Code = o.Code.ToUpper();
                res.TransportId = o.TransportId;
                res.TariffId = o.TariffId;

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
                res.Node = o.Node;
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
                    if (res.Fixed == false) // xoá chi tiết xe trong bến của xe vãng lai
                    {
                        var tmp = _db.Tra_Details.Where(p => p.VehicleId == id && p.UserOutId == null).ToList();
                        tmp.ForEach(s => _db.Tra_Details.Remove(s));
                        if (tmp.Count > 0) _db.SaveChanges();
                    }
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

        /// <summary>
        /// Danh sách xe tuyến cố định
        /// </summary>
        /// <returns></returns>
        public DataTable SelectForFixed()
        {
            try
            {
                var res = from s in _db.Tra_Vehicles
                          where s.Fixed == true
                          orderby s.Tariff.Text
                          select new
                          {
                              s.Id,
                              s.Code,

                              s.CreatorId,
                              Creator = s.Creator.Name,
                              s.CreateDate,

                              s.TransportId,
                              s.TariffId,

                              Tariff = s.Tariff.Text,
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

                              s.Node,
                              s.Driver,
                              s.Birth,
                              s.Address,
                              s.Phone,

                              s.Text,
                              s.Note,
                              s.Order,
                              s.Show
                          };

                if (!Global.Session.User.CheckAdmin() && !Global.Session.User.CheckOperator())
                    res = res.Where(k => k.CreatorId == Global.Session.User.Id);

                return res.ToDataTable();
            }
            catch { return _tb; }
        }

        /// <summary>
        /// Danh sách xe vãng lai
        /// </summary>
        /// <returns></returns>
        public DataTable SelectForNormal()
        {
            try
            {
                var res = from s in _db.Tra_Vehicles
                          where s.Fixed == false //&& !s.Code.Contains("BG")
                          orderby s.Tariff.Text
                          select new
                          {
                              s.Id,
                              s.Code,

                              s.CreatorId,
                              Creator = s.Creator.Name,
                              s.CreateDate,

                              s.TariffId,
                              Kind = s.Tariff.Text,

                              GroupId = s.Tariff.Group.Id,
                              Group = s.Tariff.Group.Text,

                              s.Seats,
                              s.Beds,

                              s.Driver,
                              s.Birth,
                              s.Address,
                              s.Phone,

                              s.Text,
                              s.Note,
                              s.Order,
                              s.Show
                          };

                if (!Global.Session.User.CheckAdmin() && !Global.Session.User.CheckOperator())
                    res = res.Where(k => k.CreatorId == Global.Session.User.Id);

                return res.ToDataTable();
            }
            catch { return _tb; }
        }

        /// <summary>
        /// Tìm biển số xe
        /// </summary>
        /// <param name="code">Biển số</param>
        /// <param name="isFixed">Loại xe</param>
        /// <returns></returns>
        public object Select(string code, bool isFixed)
        {
            try
            {
                var gui = new Guid();
                var ok = Guid.TryParse(code, out gui);
                if (ok) return _db.Tra_Vehicles.FirstOrDefault(s => s.Id == gui);
                if (code.ToUpper().Contains("BG"))
                {
                    var res = from s in _db.Tra_Vehicles
                              where !_db.Tra_Details.Any(p => p.VehicleId == s.Id && p.UserOutId == null)
                              && s.Tariff.Code == "J"
                              orderby s.Code
                              select s;
                    return res.FirstOrDefault();
                }
                return _db.Tra_Vehicles.FirstOrDefault(s => s.Code == code && s.Fixed == isFixed);
            }
            catch { return null; }
        }
    }
}