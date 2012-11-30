﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL
{
    using Entities;
    using SKG.Extend;
    using System.Data;

    /// <summary>
    /// Vận tải - Xử lí bảng Tra_Detail
    /// </summary>
    public abstract class Tra_DetailDAL : BaseDAL, IBase
    {
        /// <summary>
        /// Nhóm xe khi in
        /// </summary>
        public enum Group
        {
            /// <summary>
            /// Nhóm xe tải lưu đậu
            /// </summary>
            A,

            /// <summary>
            /// Nhóm xe sang hàng
            /// </summary>
            B,

            /// <summary>
            /// Tất cả xe vãng lai
            /// </summary>
            N,

            /// <summary>
            /// Tất cả xe cố định
            /// </summary>
            F,

            /// <summary>
            /// Tất cả xe
            /// </summary>
            Z
        }

        #region Implement
        /// <summary>
        /// Đếm số dòng trong bảng
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _db.Tra_Details.Count();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lấy dữ liệu, obj = null: lấy tất cả
        /// </summary>
        /// <param name="obj">Đối tượng Tra_Detail cần lọc</param>
        /// <param name="skip">Số dòng bỏ qua</param>
        /// <param name="take">Số dòng cần lấy</param>
        /// <returns>Dữ liệu</returns>
        public DataTable Select(object obj = null, int skip = 0, int take = 0)
        {
            try
            {
                var res = from s in _db.Tra_Details
                          select new
                          {
                              s.Id,
                              Tra_VehicleId = s.VehicleId,
                              Pol_UserInId = s.UserInId,
                              Pol_UserOutId = s.UserOutId,
                              s.DateIn,
                              s.DateOut,

                              s.Code,
                              s.Order,
                              s.Show
                          };

                if (obj != null)
                {
                    var o = (Tra_Detail)obj;
                    res = res.Where(s => s.Id == o.Id);
                }

                if (take > 0) res = res.Skip(skip).Take(take);

                return res.ToDataTable();
            }
            catch { return _tb; }
        }

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="obj">Đối tượng Tra_Detail</param>
        /// <returns>Khác null: thêm thành công</returns>
        public object Insert(object obj)
        {
            try
            {
                var o = (Tra_Detail)obj;

                var res = from s in _db.Tra_Details
                          where s.UserOutId == null && s.VehicleId == o.VehicleId
                          select s;
                if (res.Count() > 0) return null; // xe này còn ở trong bến

                o.Id = Guid.NewGuid();
                o.UserInId = Global.Session.User.Id;

                // Cập nhật mã nhóm xe vãng lai/mã vùng xe cố định
                var ve = _db.Tra_Vehicles.SingleOrDefault(p => p.Id == o.VehicleId);
                var c = ve.Tariff.Group.Code.Substring(0, 1);
                if (c == "P") o.Code = "FIXED";
                else o.Code = ve.Tariff.Group.Code;

                var oki = _db.Tra_Details.Add(o);

                _db.SaveChanges();
                return oki;
            }
            catch { return null; }
        }

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="obj">Đối tượng Tra_Detail</param>
        /// <returns>Khác null: sửa thành công</returns>
        public object Update(object obj)
        {
            try
            {
                var o = (Tra_Detail)obj;
                var res = _db.Tra_Details.SingleOrDefault(s => s.Id == o.Id);

                //res.Tra_VehicleId = o.Tra_VehicleId;
                //res.Pol_UserInId = o.Pol_UserInId;
                //res.Pol_UserOutId = o.Pol_UserOutId;
                res.DateIn = o.DateIn;
                //res.DateOut = o.DateOut;

                res.Guest = o.Guest;
                res.Code = o.Code;
                res.Note = o.Note;
                res.Order = o.Order;
                res.Show = o.Show;

                return _db.SaveChanges();
            }
            catch { return null; }
        }

        public object Delete(Guid id = new Guid())
        {
            try
            {
                if (id != new Guid())
                {
                    var res = _db.Tra_Details.SingleOrDefault(s => s.Id == id);
                    _db.Tra_Details.Remove(res);
                }
                else
                {
                    var tmp = _db.Tra_Details.ToList();
                    tmp.ForEach(s => _db.Tra_Details.Remove(s));
                }

                return _db.SaveChanges();
            }
            catch { return null; }
        }

        /// <summary>
        /// Delete temp out gate
        /// </summary>
        /// <param name="obj">Detail</param>
        /// <returns></returns>
        public object DeleteTempOut(Guid id)
        {
            try
            {
                var res = _db.Tra_Details.SingleOrDefault(s => s.Id == id);

                res.Repair = false;
                res.Note = null;

                return _db.SaveChanges();
            }
            catch { return null; }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Find vehicle in depot
        /// </summary>
        /// <param name="group">Group of vehicle</param>
        /// <param name="number">Number of vehicle</param>
        /// <returns></returns>
        private IQueryable<dynamic> FindInDepot(Group group, string number = null)
        {
            try
            {
                var res = from s in _db.Tra_Details
                          where s.UserOutId == null
                          orderby s.DateIn descending, s.Vehicle.Code
                          select new
                          {
                              s.Id,

                              s.UserIn.Phone,
                              UserIn = s.UserIn.Name,
                              s.UserInId,
                              //UserOut = s.UserOut.Name,

                              s.DateIn,
                              //s.DateOut,

                              s.Vehicle.Code,
                              s.Vehicle.Seats,
                              s.Vehicle.Beds,

                              s.Guest,
                              s.Vehicle.Node,

                              Tariff = s.Vehicle.Tariff.Text,
                              Transport = s.Vehicle.Transport == null ? "" : s.Vehicle.Transport.Text,
                              Group = s.Vehicle.Tariff.Group.Text,

                              s.Price1,
                              s.Price2,
                              s.Rose1,
                              s.Rose2,
                              //s.Money,

                              s.Vehicle.Fixed,
                              GroupCode = s.Vehicle.Tariff.Group.Code
                          };
                switch (group)
                {
                    case Group.A:
                        res = res.Where(p => p.GroupCode == "GROUP_0");
                        break;
                    case Group.B:
                        res = res.Where(p => p.GroupCode == "GROUP_1");
                        break;
                    case Group.N:
                        res = res.Where(p => p.Fixed == false);
                        break;
                    case Group.F:
                        res = res.Where(p => p.Fixed == true);
                        break;
                    default:
                        break;
                }
                //var ql = Global.Session.User.CheckOperator() || Global.Session.User.CheckAdmin();
                //if (!ql) res = res.Where(p => p.UserInId == Global.Session.User.Id);

                if (number != null) res = res.Where(p => p.Code == number);
                return res;
            }
            catch { return null; }
        }

        /// <summary>
        /// Find vehicle out depot
        /// </summary>
        /// <param name="group">Group of vihicel</param>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        /// <param name="number">Number of vehicle</param>
        /// <returns></returns>
        private IQueryable<dynamic> FindOutDepot(Group group, DateTime fr, DateTime to, string number = null)
        {
            try
            {
                var res = from s in _db.Tra_Details
                          where s.UserOutId != null
                          && s.DateOut >= fr && s.DateOut <= to
                          orderby s.DateIn descending, s.Vehicle.Code
                          select new
                          {
                              s.Id,

                              s.UserIn.Phone,
                              UserIn = s.UserIn.Name,
                              UserOut = s.UserOut.Name,
                              s.UserOutId,

                              s.DateIn,
                              s.DateOut,

                              s.Vehicle.Code,
                              s.Vehicle.Seats,
                              s.Vehicle.Beds,

                              s.Guest,
                              s.Vehicle.Node,

                              Tariff = s.Vehicle.Tariff.Text,
                              Transport = s.Vehicle.Transport == null ? "" : s.Vehicle.Transport.Text,
                              Group = s.Vehicle.Tariff.Group.Text,

                              s.Price1,
                              s.Price2,
                              s.Rose1,
                              s.Rose2,

                              s.Cost,
                              s.Rose,
                              s.Parked,
                              s.Money,

                              s.Vehicle.Fixed,
                              GroupCode = s.Vehicle.Tariff.Group.Code
                          };
                switch (group)
                {
                    case Group.A:
                        res = res.Where(p => p.GroupCode == "GROUP_0");
                        break;
                    case Group.B:
                        res = res.Where(p => p.GroupCode == "GROUP_1");
                        break;
                    case Group.N:
                        res = res.Where(p => p.Fixed == false);
                        break;
                    case Group.F:
                        res = res.Where(p => p.Fixed == true);
                        break;
                    default:
                        break;
                }
                var ql = Global.Session.User.CheckOperator() || Global.Session.User.CheckAdmin();
                if (!ql) res = res.Where(p => p.UserOutId == Global.Session.User.Id);

                if (number != null) res = res.Where(p => p.Code == number);
                return res;
            }
            catch { return null; }
        }
        #endregion

        /// <summary>
        /// List of all vehicle in depot
        /// </summary>
        /// <param name="number">Number of vehicle</param>
        /// <returns></returns>
        public DataTable GetInDepot(string number = null)
        {
            return FindInDepot(Group.Z, number).ToDataTable();
        }

        /// <summary>
        /// List of all vehicle in depot for out gate
        /// </summary>
        /// <param name="fix">Sum of vehicle fixed</param>
        /// <param name="nor">Sum of vehicle normal</param>
        /// <returns></returns>
        public DataTable GetInDepot(out int fix, out int nor)
        {
            fix = nor = 0;
            try
            {
                var res = from s in _db.Tra_Details
                          where s.UserOutId == null
                          orderby s.Vehicle.Code
                          select new
                          {
                              s.Id,
                              s.Vehicle.Code,
                              s.Vehicle.Fixed
                          };
                fix = SumInDepotFixed;
                nor = SumInDepotNormal;

                var ql = Global.Session.User.CheckOperator() || Global.Session.User.CheckAdmin();
                if (ql) res = res.Where(p => p.Fixed == true);
                return res.ToDataTable();
            }
            catch { return null; }
        }

        /// <summary>
        /// List of all vehicle out depot
        /// </summary>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        /// <param name="number">Number of vehicle</param>
        /// <returns></returns>
        public DataTable GetOutDepot(DateTime fr, DateTime to, string number = null)
        {
            return FindOutDepot(Group.Z, fr, to, number).ToDataTable();
        }

        /// <summary>
        /// Charge money and exit vehicle out gate
        /// </summary>
        /// <param name="number">Number of vehicle</param>
        /// <param name="isOut">For out gate</param>
        /// <param name="dateOut">Date out</param>
        /// <param name="isRepair">Out gate to repair</param>
        /// <param name="note">Note</param>
        /// <returns></returns>
        public Tra_Detail InvoiceOut(string number, bool isOut, DateTime? dateOut = null, bool isRepair = true, string note = "")
        {
            try
            {
                int m, y;
                _db = new Context();
                var a = _db.Tra_Details.SingleOrDefault(k => k.Vehicle.Code == number && k.UserOutId == null);
                if (dateOut == null)
                {
                    a.DateOut = Global.Session.Current;
                    m = Global.Session.Current.Month;
                    y = Global.Session.Current.Year;
                }
                else
                {
                    a.DateOut = dateOut;
                    m = dateOut.Value.Month;
                    y = dateOut.Value.Year;
                }

                var ql = Global.Session.User.CheckOperator() || Global.Session.User.CheckAdmin();
                if (ql && a.Vehicle.Fixed)
                {
                    a.Note = "ĐỘI ĐIỀU HÀNH: ";
                    if (isRepair)
                    {
                        a.Repair = true; // cho ra ngoài để sửa chữa (không tính tiền lúc ra bến)
                        a.Note += "TẠM CHO XE RA BẾN";
                    }
                    else
                    {
                        a.Show = false; // xe không đủ điều kiện (không tính tiền lúc ra bến)
                        a.Note += "XE KHÔNG ĐỦ ĐIỀU KIỆN";
                    }
                    a.Note += String.Format("\n\r{0};!;{1}", Global.Session.User.Name, note);
                }

                if (isOut && !ql) // cho ra
                {
                    // Người cho ra
                    a.UserOutId = Global.Session.User.Id;

                    if (a.Vehicle.Fixed)
                    {
                        // Đánh số phiếu thu theo tháng, năm (xe cố định)
                        var dt = _db.Tra_Details.Where(p => p.Code == a.Code
                            && p.Cost != 0
                            && p.DateOut.Value.Month == m
                            && p.DateOut.Value.Year == y);
                        if (dt.Count() > 0)
                            a.Order = dt.Max(p => p.Order) + 1;
                    }
                    else
                    {
                        // Đánh số thứ tự từng nhóm xe (tải lưu đậu, sang hàng)
                        var dt = _db.Tra_Details.Where(p => p.Code == a.Code);
                        if (dt.Count() > 0)
                            a.Order = dt.Max(p => p.Order) + 1;
                    }
                }

                a.Seats = a.Vehicle.Seats;
                a.Beds = a.Vehicle.Beds;

                a.Price1 = a.Vehicle.Tariff.Price1;
                a.Rose1 = a.Vehicle.Tariff.Rose1;

                a.Price2 = a.Vehicle.Tariff.Price2;
                a.Rose2 = a.Vehicle.Tariff.Rose2;

                var dateIn = a.DateIn.AddMinutes(11);
                var t = a.DateOut.Value - dateIn;
                var o = t.TotalDays - t.Days;

                a.FullDay = t.Days;
                if (o < 0.5)
                    a.HalfDay = 1;
                else
                {
                    a.HalfDay = 0;
                    a.FullDay++;
                }

                a.Money = a.Vehicle.Fixed ? a.ChargeForFixed() : a.ChargeForNormal();

                // Tính tiền lưu đậu đêm lần trước (ra do xin ra ngoài sửa xe)
                var b = _db.Tra_Details.FirstOrDefault(k => k.Vehicle.Code == number && k.Repair == true && k.Id != a.Id);
                if (b != null)
                {
                    a.Parked += b.Parked;
                    a.Money += b.Parked;
                    a.Note = String.Format("{0} + Lưu đậu đêm: {1:#,#đ}", b.Note, b.Parked);
                    if (isOut) b.Repair = false;
                }

                // Xe ra ngoài sửa không tính tiền phí, hoa hồng; chỉ tính tiền lưu đậu đêm
                if (a.Repair)
                {
                    a.Cost = 0;
                    a.Rose = 0;
                    a.Money = a.Parked;
                }

                _db.SaveChanges();
                return a;
            }
            catch { return null; }
        }

        #region Vehicle fixed
        /// <summary>
        /// Sum of vehicle fixed in depot
        /// </summary>
        /// <returns></returns>
        public int SumInDepotFixed
        {
            get
            {
                return _db.Tra_Details.Count(k => k.UserOutId == null && k.Vehicle.Fixed == true);
            }
        }

        /// <summary>
        /// Revenue of vehicle fixed from 13:00:01 yesterday ago to 13:00:00 today
        /// </summary>
        /// <param name="sum">Sum of money</param>
        /// <returns></returns>
        public DataTable GetRevenueToday(out decimal sum, out string receipt)
        {
            sum = 0;
            receipt = "";
            try
            {
                var to = Global.Session.Current.Date.AddHours(13);
                var fr = to.AddDays(-1).AddSeconds(1);
                return GetRevenueFixed(out sum, out receipt, fr, to);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// List of 20 lastest vehicles normal
        /// </summary>
        public DataTable GetLatestFixed
        {
            get
            {
                try
                {
                    var res = from s in _db.Tra_Details
                              where s.UserOutId == null
                              && s.Vehicle.Fixed == true
                              orderby s.DateIn descending
                              select new
                              {
                                  s.Id,
                                  UserInName = s.UserIn.Name,
                                  UserInPhone = s.UserIn.Phone,
                                  s.DateIn,

                                  KindId = s.Vehicle.TransportId,
                                  Transport = s.Vehicle.Transport.Text,
                                  Route = s.Vehicle.Tariff.Text,

                                  s.Vehicle.Code,
                                  s.Vehicle.Seats,
                                  s.Vehicle.Beds,

                                  Descript = s.Vehicle.Note,
                                  s.Vehicle.Driver,
                                  s.Vehicle.Birth,
                                  s.Vehicle.Address,
                                  s.Vehicle.Phone
                              };
                    return res.Take(20).ToDataTable();
                }
                catch { return null; }
            }
        }

        /// <summary>
        /// List all of vehicles fixed in depot
        /// </summary>
        /// <param name="number">Number of vehicle</param>
        /// <returns></returns>
        public DataTable GetInDepotFixed(string number = null)
        {
            return FindInDepot(Group.F, number).ToDataTable();
        }

        /// <summary>
        /// List all of vehicle fixed temp out gate
        /// </summary>
        /// <param name="number">Number of vehicle</param>
        /// <returns></returns>
        public DataTable GetTempOut(string number = null)
        {
            try
            {
                var res = from s in _db.Tra_Details
                          where s.Repair == true
                          && s.Vehicle.Fixed == true
                          orderby s.DateIn descending, s.Vehicle.Code
                          select new
                          {
                              s.Id,
                              s.Note,

                              s.UserIn.Phone,
                              UserIn = s.UserIn.Name,
                              s.UserInId,
                              UserOut = s.UserOut.Name,

                              s.DateIn,
                              s.DateOut,

                              s.Vehicle.Code,
                              s.Vehicle.Seats,
                              s.Vehicle.Beds,

                              s.Guest,
                              s.Vehicle.Node,

                              Tariff = s.Vehicle.Tariff.Text,
                              Transport = s.Vehicle.Transport == null ? "" : s.Vehicle.Transport.Text,
                              Group = s.Vehicle.Tariff.Group.Text,

                              s.Price1,
                              s.Price2,
                              s.Rose1,
                              s.Rose2,
                              //s.Money,
                              s.Parked,

                              s.Vehicle.Fixed,
                              GroupCode = s.Vehicle.Tariff.Group.Code
                          };
                if (number != null) res = res.Where(p => p.Code == number);
                return res.ToDataTable();
            }
            catch { return null; }
        }

        /// <summary>
        /// Sumary vehicle fixed
        /// </summary>
        /// <param name="sum">Total money</param>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        /// <returns></returns>
        public DataTable SumaryFixed(out decimal sum, DateTime fr, DateTime to)
        {
            sum = 0;
            try
            {
                var res = from s in _db.Tra_Details
                          where s.UserOutId != null
                          && s.DateOut >= fr && s.DateOut <= to
                          && s.Vehicle.Fixed == true
                          && s.Money != s.Parked
                          orderby s.DateOut descending
                          select new
                          {
                              s.Id,
                              s.More,
                              s.Text,

                              UserIn = s.UserIn.Name,
                              Phone = s.UserIn.Phone,

                              UserOut = s.UserOut.Name,
                              s.Vehicle.Code,

                              s.DateIn,
                              s.DateOut,

                              s.FullDay,
                              s.HalfDay,
                              TotalDays = s.FullDay + (s.HalfDay == 1 ? 0.5 : 0),
                              Money = s.Money + (s.Arrears ?? 0) * (s.Cost + s.Rose),

                              s.Price1,
                              s.Price2,

                              Region = s.Vehicle.Tariff.Group.Parent.Parent.Text,
                              Area = s.Vehicle.Tariff.Group.Parent.Text,
                              Province = s.Vehicle.Tariff.Group.Text,
                              Tariff = s.Vehicle.Tariff.Text,
                              Transport = s.Vehicle.Transport.Text,

                              s.Parked,
                              s.Cost,
                              s.Rose,
                              Arrears = (s.Arrears ?? 0) * (s.Cost + s.Rose),
                              s.UserOutId
                          };
                var ql = Global.Session.User.CheckOperator() || Global.Session.User.CheckAdmin();
                if (!ql) res = res.Where(p => p.UserOutId == Global.Session.User.Id);

                sum = res.Sum(k => k.Money);
                return res.ToDataTable();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Revenue of vehicle fixed
        /// </summary>
        /// <param name="sum">Totals money</param>
        /// <param name="receipt">Range of receipt</param>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        /// <returns></returns>
        public DataTable GetRevenueFixed(out decimal sum, out string receipt, DateTime fr, DateTime to)
        {
            sum = 0;
            receipt = "";
            try
            {
                #region Max, min number of receipt
                var max = (from s in _db.Tra_Details
                           where s.UserOutId != null
                           && s.DateOut >= fr && s.DateOut <= to
                           && s.Vehicle.Fixed == true
                           && s.Repair == false
                           && s.Money != s.Parked
                           group s by s.Code into g
                           select new
                           {
                               Order = g.Max(p => p.Order),
                               DateOut = g.Max(p => p.DateOut)
                           }).FirstOrDefault();
                var min = (from s in _db.Tra_Details
                           where s.UserOutId != null
                           && s.DateOut >= fr && s.DateOut <= to
                           && s.Vehicle.Fixed == true
                           && s.Repair == false
                           && s.Money != s.Parked
                           group s by s.Code into g
                           select new
                           {
                               Order = g.Min(p => p.Order),
                               DateOut = g.Min(p => p.DateOut)
                           }).FirstOrDefault();
                receipt = String.Format("{0}/{1} - {2}/{3}",
                    min.Order, min.DateOut.Value.Month,
                    max.Order, max.DateOut.Value.Month);
                #endregion

                var res1 = from s in _db.Tra_Details
                           where s.UserOutId != null
                           && s.DateOut >= fr && s.DateOut <= to
                           && s.Vehicle.Fixed == true
                           && s.Repair == false
                           && s.Money != s.Parked
                           group s by new
                           {
                               s.Vehicle.Tariff.Code,
                               Hoadon = s.Vehicle.Transport.Note == null ? "A" : "B"
                           } into g
                           select new
                           {
                               g.Key.Code,
                               g.Key.Hoadon,

                               Count = g.Count(),
                               Arrears = g.Sum(p => p.Arrears ?? 0),
                               ArrearsMoney = g.Sum(p => (p.Arrears ?? 0) * (p.Cost + p.Rose)),

                               Seats = g.Sum(p => p.Vehicle.Seats ?? 0),
                               Beds = g.Sum(p => p.Vehicle.Beds ?? 0),

                               Cost = g.Sum(p => p.Cost),
                               Rose = g.Sum(p => p.Rose),
                               Parked = g.Sum(p => p.Parked)
                           };

                var res2 = from s in res1
                           join t in _db.Tra_Tariffs on s.Code equals t.Code
                           select new
                           {
                               s.Code,
                               s.Hoadon,
                               s.Count,

                               s.Seats,
                               s.Beds,
                               s.Arrears,

                               t.Rose1,
                               t.Rose2,
                               t.Price1,
                               t.Price2,

                               s.Cost,
                               s.Rose,
                               s.Parked,
                               s.ArrearsMoney,

                               Totals = s.Parked + s.Cost + s.Rose,

                               Station = t.Text,
                               Province = t.Group.Text,
                               Area = t.Group.Parent.Text,
                               Region = t.Group.Parent.Parent.Text
                           };

                var res3 = from s in res2
                           group s by new
                           {
                               s.Hoadon,
                               s.Province,
                               s.Area,
                               s.Region,

                               s.Rose1,
                               s.Rose2,
                               s.Price1,
                               s.Price2,
                           } into g
                           select new
                           {
                               g.Key.Hoadon,
                               g.Key.Region,
                               g.Key.Area,
                               g.Key.Province,

                               g.Key.Rose1,
                               g.Key.Rose2,
                               g.Key.Price1,
                               g.Key.Price2,

                               Count = g.Sum(p => p.Count),
                               Seats = g.Sum(p => p.Seats),
                               Beds = g.Sum(p => p.Beds),

                               Cost = g.Sum(p => p.Cost),
                               Rose = g.Sum(p => p.Rose),
                               Parked = g.Sum(p => p.Parked),

                               Arrears = g.Sum(p => p.Arrears),
                               ArrearsMoney = g.Sum(p => p.ArrearsMoney),
                               Totals = g.Sum(p => p.Totals) + g.Sum(p => p.ArrearsMoney),

                               Vat = g.Sum(p => p.Totals) * 10 / 100,
                               Sales = g.Sum(p => p.Totals) * 90 / 100
                           };
                sum = res3.Sum(k => k.Totals);
                return res3.ToDataTable();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Audit vehicle fixed
        /// </summary>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        /// <param name="isOut">In depot</param>
        /// <returns></returns>
        public DataTable GetAuditFixed(DateTime fr, DateTime to, bool isOut = true)
        {
            try
            {
                var res = from s in _db.Tra_Details
                          where s.Vehicle.Fixed == true
                          orderby s.DateOut descending, s.DateIn descending, s.Vehicle.Code
                          select new
                          {
                              s.Id,
                              UserIn = s.UserIn.Name,
                              Phone = s.UserIn.Phone,
                              s.DateIn,

                              s.Guest,
                              s.Discount,
                              s.Arrears,

                              Route = s.Vehicle.Tariff.Text,
                              s.Vehicle.Node,

                              s.Vehicle.Code,
                              s.Vehicle.Seats,
                              s.Vehicle.Beds,
                              Transport = s.Vehicle.Transport.Text,

                              UserOut = s.UserOut.Name,
                              s.DateOut,
                              s.UserOutId
                          };
                if (isOut)
                    res = res.Where(p => p.DateOut >= fr && p.DateOut <= to && p.UserOutId != null);
                else
                    res = res.Where(p => p.UserOutId == null);
                return res.ToDataTable();
            }
            catch { return null; }
        }

        /// <summary>
        /// Audit month vehicle fixed
        /// </summary>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        /// <param name="hideActive">Hide vehicle active</param>
        /// <returns></returns>
        public DataTable AuditMonthFixed(DateTime fr, DateTime to, bool hideActive)
        {
            try
            {
                var res1 = from s in _db.Tra_Details
                           where s.UserOutId != null
                           && s.Vehicle.Fixed == true
                           && s.Repair == false
                           && s.DateOut >= fr && s.DateOut <= to
                           && s.Parked != s.Money
                           group s by s.VehicleId into g
                           select new
                           {
                               g.Key,
                               Th_Lx_Xuatben = g.Count(),
                               Th_Lk_Di = g.Sum(p => p.Guest ?? 0)
                           };

                var res2 =
                           from v in _db.Tra_Vehicles
                           join r in res1 on v.Id equals r.Key into l
                           from s in l.DefaultIfEmpty()
                           where v.Fixed == true
                           orderby v.Tariff.Group.Parent.Parent.Code descending,
                           v.Tariff.Group.Parent.Code descending, v.Tariff.Group.Code,
                           v.Tariff.Code, v.Transport.Code, v.Code
                           select new
                           {
                               Region = v.Tariff.Group.Parent.Parent.Text,
                               Area = v.Tariff.Group.Parent.Text,
                               Province = v.Tariff.Group.Text,
                               Station = v.Tariff.Text,
                               Transport = v.Transport.Text,

                               RegionCode = v.Tariff.Group.Parent.Parent.Code,
                               AreaCode = v.Tariff.Group.Parent.Code,
                               ProvinceCode = v.Tariff.Group.Code,
                               StationCode = v.Tariff.Code,
                               TransportCode = v.Transport.Code,

                               v.Code,
                               Kh_Soxe = 1,
                               Kh_Lx_Xuatben = v.Node,

                               Kh_So_Ghe = (v.Seats + v.Beds) - 1,
                               Kh_Ts_Ghe = ((v.Seats + v.Beds) - 1) * (v.Node ?? 0),

                               Th_Soxe = s.Key == null ? 0 : 1,
                               Th_Ts_Ghe = ((v.Seats + v.Beds) - 1) * (s.Th_Lx_Xuatben == null ? 0 : s.Th_Lx_Xuatben),
                               Th_Lx_Xuatben = s.Th_Lx_Xuatben == null ? 0 : s.Th_Lx_Xuatben,
                               Th_Lk_Di = s.Th_Lk_Di == null ? 0 : s.Th_Lk_Di,

                               Tile_Nottai = (decimal)(s.Th_Lx_Xuatben == null ? 0 : s.Th_Lx_Xuatben) / (v.Node < 1 ? 1 : v.Node) * 100,
                               Nottai_Hoatdong = (decimal)(s.Th_Lx_Xuatben == null ? 0 : s.Th_Lx_Xuatben) / 30
                           };
                if (hideActive) res2 = res2.Where(p => p.Th_Soxe > 0);
                return res2.ToDataTable();
            }
            catch { return null; }
        }

        /// <summary>
        /// Report for debt month vehicle fixed
        /// </summary>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        /// <param name="hideActive">Hide vehicle active</param>
        /// <returns></returns>
        public DataTable DebtMonthFixed(DateTime fr, DateTime to, bool hideActive)
        {
            try
            {
                #region Cumulative
                DateTime frx, tox;
                Session.CutShiftJanuary(to, out frx, out tox);
                var m = to.Month;

                var res = from s in _db.Tra_Details
                          where s.UserOutId != null
                          && s.Vehicle.Fixed == true
                          && s.Repair == false
                          && s.DateOut >= frx && s.DateOut <= tox
                          && s.Parked != s.Money
                          group s by s.VehicleId into g
                          select new
                          {
                              g.Key,
                              Th = g.Count(),
                              Tt = g.Sum(p => p.Arrears ?? 0),
                              Mg = g.Sum(p => p.Discount ?? 0)
                          };
                #endregion

                var res1 = from s in _db.Tra_Details
                           where s.UserOutId != null
                           && s.Vehicle.Fixed == true
                           && s.Repair == false
                           && s.DateOut >= fr && s.DateOut <= to
                           && s.Parked != s.Money
                           group s by s.VehicleId into g
                           select new
                           {
                               g.Key,
                               Th = g.Count(),
                               Tt = g.Sum(p => p.Arrears ?? 0),
                               Mg = g.Sum(p => p.Discount ?? 0)
                           };

                var res2 =
                           from v in _db.Tra_Vehicles
                           join r in res1 on v.Id equals r.Key into l
                           from s in l.DefaultIfEmpty()
                           join rx in res on v.Id equals rx.Key into lx
                           from sx in lx.DefaultIfEmpty()
                           where v.Fixed == true
                           orderby v.Tariff.Group.Parent.Parent.Code descending,
                           v.Tariff.Group.Parent.Code descending, v.Tariff.Group.Code,
                           v.Tariff.Code, v.Transport.Code, v.Code
                           select new
                           {
                               Region = v.Tariff.Group.Parent.Parent.Text,
                               Area = v.Tariff.Group.Parent.Text,
                               Province = v.Tariff.Group.Text,
                               Tariff = v.Tariff.Text,
                               Transport = v.Transport.Text,

                               RegionCode = v.Tariff.Group.Parent.Parent.Code,
                               AreaCode = v.Tariff.Group.Parent.Code,
                               ProvinceCode = v.Tariff.Group.Code,
                               TariffCode = v.Tariff.Code,
                               TransportCode = v.Transport.Code,

                               v.Code,
                               v.Node,

                               Th = s.Th == null ? 0 : s.Th,
                               Tt = s.Tt == null ? 0 : s.Tt,
                               Mg = s.Mg == null ? 0 : s.Mg,

                               Nn = ((s.Th == null ? 0 : s.Th) < v.Node) ? (v.Node - (s.Th == null ? 0 : s.Th) - (s.Tt == null ? 0 : s.Tt) - (s.Mg == null ? 0 : s.Mg)) : 0,
                               Dt = (((s.Th == null ? 0 : s.Th) < v.Node) ? (v.Node - (s.Th == null ? 0 : s.Th) - (s.Tt == null ? 0 : s.Tt) - (s.Mg == null ? 0 : s.Mg)) : 0)
                               * ((v.Tariff.Price1 * (v.Seats ?? 0) + v.Tariff.Price2 * (v.Beds ?? 0)) + (v.Tariff.Rose1 * ((v.Seats ?? 0) < 1 ? 1 : (v.Seats ?? 0) - 1) + v.Tariff.Rose2 * (v.Beds ?? 0))),

                               Lk_Th = sx.Th == null ? 0 : sx.Th,
                               Lk_Tt = sx.Tt == null ? 0 : sx.Tt,
                               Lk_Mg = sx.Mg == null ? 0 : sx.Mg,

                               Lk_Nn = ((sx.Th == null ? 0 : sx.Th) < v.Node * m) ? (v.Node * m - (sx.Th == null ? 0 : sx.Th) - (sx.Tt == null ? 0 : sx.Tt) - (sx.Mg == null ? 0 : sx.Mg)) : 0,
                               Lk_Dt = (((sx.Th == null ? 0 : sx.Th) < v.Node * m) ? (v.Node * m - (sx.Th == null ? 0 : sx.Th) - (sx.Tt == null ? 0 : sx.Tt) - (sx.Mg == null ? 0 : sx.Mg)) : 0)
                               * ((v.Tariff.Price1 * (v.Seats ?? 0) + v.Tariff.Price2 * (v.Beds ?? 0)) + (v.Tariff.Rose1 * ((v.Seats ?? 0) < 1 ? 1 : (v.Seats ?? 0) - 1) + v.Tariff.Rose2 * (v.Beds ?? 0))),

                               v.Note
                           };
                if (hideActive) res2 = res2.Where(p => p.Lk_Th > 0);
                return res2.ToDataTable();
            }
            catch { return null; }
        }

        /// <summary>
        /// Audit day vehicle fixed
        /// </summary>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        /// <param name="hideActive">Hide vehicle active</param>
        /// <returns></returns>
        public DataTable AuditDayFixed(DateTime fr, DateTime to, bool hideActive)
        {
            try
            {
                var res1 = from s in _db.Tra_Details
                           where s.UserOutId != null
                           && s.Vehicle.Fixed == true
                           && s.Repair == false
                           && s.DateOut >= fr && s.DateOut <= to
                           && s.Parked != s.Money
                           group s by s.VehicleId into g
                           select new
                           {
                               g.Key,
                               Th_Lxe = g.Count(),

                               Th_Arrears = g.Sum(p => p.Arrears ?? 0),
                               Th_Discount = g.Sum(p => p.Discount ?? 0),
                               Th_Guest = g.Sum(p => p.Guest ?? 0),

                               Th_Cost = g.Sum(p => p.Cost),
                               Th_Rose = g.Sum(p => p.Rose),
                               Th_Parked = g.Sum(p => p.Parked),
                               Th_Money = g.Sum(p => p.Money)
                           };

                var res2 =
                           from v in _db.Tra_Vehicles
                           join r in res1 on v.Id equals r.Key into l
                           from s in l.DefaultIfEmpty()
                           where v.Fixed == true
                           orderby v.Tariff.Group.Parent.Parent.Code descending,
                           v.Tariff.Group.Parent.Code descending, v.Tariff.Group.Code,
                           v.Tariff.Code, v.Transport.Code, v.Code
                           select new
                           {
                               Region = v.Tariff.Group.Parent.Parent.Text,
                               Area = v.Tariff.Group.Parent.Text,
                               Province = v.Tariff.Group.Text,
                               Station = v.Tariff.Text,
                               Transport = v.Transport.Text,

                               RegionCode = v.Tariff.Group.Parent.Parent.Code,
                               AreaCode = v.Tariff.Group.Parent.Code,
                               ProvinceCode = v.Tariff.Group.Code,
                               StationCode = v.Tariff.Code,
                               TransportCode = v.Transport.Code,

                               Th_Lxe = s.Th_Lxe == null ? 0 : s.Th_Lxe,
                               Th_Hk = ((v.Seats ?? 0 + v.Beds ?? 0) - 1) * (s.Th_Lxe == null ? 0 : s.Th_Lxe),
                               Th_Cost = s.Th_Cost == null ? 0 : s.Th_Cost,
                               Th_Rose = s.Th_Rose == null ? 0 : s.Th_Rose,
                               Th_Parked = s.Th_Parked == null ? 0 : s.Th_Parked,
                               Th_Money = s.Th_Money == null ? 0 : s.Th_Money,

                               Tr_Lxe = s.Th_Arrears == null ? 0 : s.Th_Arrears,
                               Tr_Hk = (s.Th_Arrears == null ? 0 : s.Th_Arrears) * ((v.Seats ?? 0 + v.Beds ?? 0) - 1),
                               Tr_Cost = (s.Th_Arrears == null ? 0 : s.Th_Arrears) * (v.Tariff.Price1 * (v.Seats ?? 0) + v.Tariff.Price2 * (v.Beds ?? 0)),
                               Tr_Rose = (s.Th_Arrears == null ? 0 : s.Th_Arrears) * (v.Tariff.Rose1 * ((v.Seats ?? 0) < 1 ? 1 : (v.Seats ?? 0) - 1) + v.Tariff.Rose2 * (v.Beds ?? 0)),
                               Tr_Money = (s.Th_Arrears == null ? 0 : s.Th_Arrears) * (v.Tariff.Price1 * (v.Seats ?? 0) + v.Tariff.Price2 * (v.Beds ?? 0))
                               + (s.Th_Arrears == null ? 0 : s.Th_Arrears) * (v.Tariff.Rose1 * ((v.Seats ?? 0) < 1 ? 1 : (v.Seats ?? 0) - 1) + v.Tariff.Rose2 * (v.Beds ?? 0)),

                               v.Code,
                               Guest = s.Th_Guest
                           };
                if (hideActive) res2 = res2.Where(p => p.Th_Lxe > 0);
                return res2.ToDataTable();
            }
            catch { return null; }
        }

        /// <summary>
        /// Update number of guest, discount and arrears
        /// </summary>
        /// <param name="obj">Detail</param>
        /// <returns></returns>
        public object UpdateMore(object obj)
        {
            try
            {
                var o = (Tra_Detail)obj;
                var res = _db.Tra_Details.SingleOrDefault(s => s.Id == o.Id);

                res.Guest = o.Guest;
                res.Discount = o.Discount;
                res.Arrears = o.Arrears;

                return _db.SaveChanges();
            }
            catch { return null; }
        }
        #endregion

        #region Vehicle normal
        /// <summary>
        /// Sum of vehicle normal in depot
        /// </summary>
        /// <returns></returns>
        public int SumInDepotNormal
        {
            get
            {
                return _db.Tra_Details.Count(k => k.UserOutId == null && k.Vehicle.Fixed == false);
            }
        }

        /// <summary>
        /// Revenue of vehicle normal
        /// </summary>
        /// <param name="sum">Sum of money</param>
        /// <param name="nhom">Group of vehicle</param>
        /// <returns></returns>
        public DataTable GetRevenueNormal(out decimal sum, DateTime fr, DateTime to, Group nhom = Group.N)
        {
            sum = 0;
            try
            {
                var res = from s in _db.Tra_Details
                          where s.UserOutId != null
                           && s.DateOut >= fr && s.DateOut <= to
                          && s.Vehicle.Fixed == false
                          orderby s.Order
                          select new
                          {
                              s.Id,
                              No_ = s.Order,

                              s.More,
                              s.Text,

                              UserIn = s.UserIn.Name,
                              s.UserIn.Phone,

                              UserOut = s.UserOut.Name,
                              s.Vehicle.Code,

                              s.DateIn,
                              s.DateOut,

                              s.FullDay,
                              s.HalfDay,
                              TotalDays = s.FullDay + (s.HalfDay == 1 ? 0.5 : 0),

                              s.Price1,
                              s.Price2,
                              s.Money,

                              Group = s.Vehicle.Tariff.Group.Text,
                              GroupCode = s.Vehicle.Tariff.Group.Code,
                              Tariff = s.Vehicle.Tariff.Text
                          };
                if (nhom == Group.A) res = res.Where(p => p.GroupCode == "GROUP_0");
                else if (nhom == Group.B) res = res.Where(p => p.GroupCode == "GROUP_1");

                sum = res.Sum(k => k.Money);
                return res.ToDataTable(false);
            }
            catch
            {
                sum = 0;
                return null;
            }
        }

        /// <summary>
        /// List of 20 lastest vehicles normal
        /// </summary>
        public DataTable GetLatestNormal
        {
            get
            {
                try
                {
                    var res = from s in _db.Tra_Details
                              where s.UserOutId == null
                              && s.Vehicle.Fixed == false
                              orderby s.DateIn descending
                              select new
                              {
                                  s.Id,
                                  UserInName = s.UserIn.Name,
                                  UserInPhone = s.UserIn.Phone,
                                  s.DateIn,

                                  KindId = s.Vehicle.TransportId,
                                  GroupName = s.Vehicle.Tariff.Group.Text,
                                  KindName = s.Vehicle.Tariff.Text,

                                  s.Vehicle.Code,
                                  s.Vehicle.Seats,
                                  s.Vehicle.Beds,

                                  Descript = s.Vehicle.Note,
                                  s.Vehicle.Driver,
                                  s.Vehicle.Birth,
                                  s.Vehicle.Address,
                                  s.Vehicle.Phone
                              };

                    return res.Take(20).ToDataTable();
                }
                catch { return null; }
            }
        }

        /// <summary>
        /// List all of vehicles fixed in depot
        /// </summary>
        /// <param name="number">Number of vehicle</param>
        /// <returns></returns>
        public DataTable GetInDepotNormal(string number = null)
        {
            return FindInDepot(Group.N, number).ToDataTable();
        }

        /// <summary>
        /// Sumary vehicle normal
        /// </summary>
        /// <param name="sum">Total money</param>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        /// <returns></returns>
        public DataTable SumaryNormal(out decimal sum, DateTime fr, DateTime to)
        {
            sum = 0;
            try
            {
                var res = from s in _db.Tra_Details
                          where s.UserOutId != null
                          && s.DateOut >= fr && s.DateOut <= to
                          && s.Vehicle.Fixed == false
                          orderby s.Vehicle.Tariff.Group.Code, s.DateOut descending
                          select new
                          {
                              s.Id,
                              s.More,
                              s.Text,

                              UserIn = s.UserIn.Name,
                              Phone = s.UserIn.Phone,

                              UserOut = s.UserOut.Name,
                              s.Vehicle.Code,

                              s.DateIn,
                              s.DateOut,

                              s.FullDay,
                              s.HalfDay,
                              TotalDays = s.FullDay + (s.HalfDay == 1 ? 0.5 : 0),
                              s.Money,

                              s.Price1,
                              s.Price2,

                              Group = s.Vehicle.Tariff.Group.Text,
                              Tariff = s.Vehicle.Tariff.Text,
                              s.UserOutId
                          };
                var ql = Global.Session.User.CheckOperator() || Global.Session.User.CheckAdmin();
                if (!ql) res = res.Where(p => p.UserOutId == Global.Session.User.Id);

                sum = res.Sum(k => k.Money);
                return res.ToDataTable();
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}