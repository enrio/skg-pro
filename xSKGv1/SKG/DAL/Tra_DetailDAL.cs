using System;
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

        /// <summary>
        /// Cập nhật số hành khách đi xe
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public object UpdateGuest(object obj)
        {
            try
            {
                var o = (Tra_Detail)obj;
                var res = _db.Tra_Details.SingleOrDefault(s => s.Id == o.Id);

                res.Guest = o.Guest;
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
        #endregion

        #region Private methods
        /// <summary>
        /// Find vihicle in depot
        /// </summary>
        /// <param name="group">Group of vihicle</param>
        /// <param name="number">Number of vihicle</param>
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
                if (number != null) res = res.Where(p => p.Code == number);
                return res;
            }
            catch { return null; }
        }

        /// <summary>
        /// Find vihicle out depot
        /// </summary>
        /// <param name="group">Group of vihicel</param>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        /// <param name="number">Number of vihicle</param>
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
                if (number != null) res = res.Where(p => p.Code == number);
                return res;
            }
            catch { return null; }
        }
        #endregion

        /// <summary>
        /// List of all vihicle in depot
        /// </summary>
        /// <param name="number">Number of vihicle</param>
        /// <returns></returns>
        public DataTable GetInDepot(string number = null)
        {
            return FindInDepot(Group.Z, number).ToDataTable();
        }

        /// <summary>
        /// List of all vihicle in depot
        /// </summary>
        /// <param name="fix">Number of vihicle fixed</param>
        /// <param name="nor">Number of vihicle normal</param>
        /// <param name="number">Number of vihicle</param>
        /// <returns></returns>
        public DataTable GetInDepot(out int fix, out int nor, string number = null)
        {
            var a = FindInDepot(Group.F, number);
            var b = FindInDepot(Group.N, number);
            fix = a.Count();
            nor = b.Count();
            return a.Union(b).ToDataTable();
        }

        /// <summary>
        /// List of all vihicle out depot
        /// </summary>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        /// <param name="number">Number of vihicle</param>
        /// <returns></returns>
        public DataTable GetOutDepot(DateTime fr, DateTime to, string number = null)
        {
            return FindOutDepot(Group.Z, fr, to, number).ToDataTable();
        }

        /// <summary>
        /// Charge money and exit vihicle out gate
        /// </summary>
        /// <param name="number">Number of vihicle</param>
        /// <param name="isOut">True allow out gate else charge money</param>
        /// <param name="dateOut">Out gate date time</param>
        /// <returns></returns>
        public Tra_Detail InvoiceOut(string number, bool isOut, DateTime? dateOut = null)
        {
            try
            {
                int m, y;
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
                    a.Repair = true; // cho ra ngoài để sửa chữa (không tính tiền lúc ra bến)
                    a.Note = String.Format("ĐỘI ĐIỀU HÀNH TẠM CHO RA BẾN\n\r ({0})", Global.Session.User.Name);
                }

                if (isOut && !ql) // cho ra
                {
                    // Người cho ra
                    a.UserOutId = Global.Session.User.Id;

                    if (a.Vehicle.Fixed)
                    {
                        // Đánh số phiếu thu theo tháng, năm (xe cố định)
                        var dt = _db.Tra_Details.Where(p => p.Code == a.Code
                            && p.DateOut.Value.Month == m
                            && p.DateOut.Value.Year == y);
                        a.Order = dt.Max(p => p.Order) + 1;
                    }
                    else
                    {
                        // Đánh số thứ tự từng nhóm xe (tải lưu đậu, sang hàng)
                        var dt = _db.Tra_Details.Where(p => p.Code == a.Code);
                        a.Order = dt.Max(p => p.Order) + 1;
                    }

                    // Ca làm việc
                    DateTime shift;
                    int i = Global.Session.Shift(out shift, dateOut);
                    a.More = String.Format("Ca {0} {1:dd/MM/yyyy}", i, shift);
                    a.Text = i == 1 ? "07:00-16:00" : "16:00-07:00";
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

        #region Vihicle fixed
        /// <summary>
        /// Sum of vihicle fixed in depot
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
        /// Revenue of vihicle fixed from 13:00 yesterday ago to 13:00 today
        /// </summary>
        /// <param name="sum">Sum of money</param>
        /// <returns></returns>
        public DataTable GetRevenueToday(out decimal sum)
        {
            try
            {
                sum = 0;
                var to = Global.Session.Current.Date.AddHours(13);
                var fr = to.AddDays(-1);

                var res1 = from s in _db.Tra_Details
                           where s.UserOutId != null
                           && s.Vehicle.Fixed == true
                           && s.Repair == false
                           && s.DateOut >= fr && s.DateOut <= to
                           group s by s.Vehicle.Tariff.Code into g
                           select new
                           {
                               g.Key,
                               Count = g.Count(),

                               Seats = g.Sum(p => p.Vehicle.Seats) ?? 0,
                               Beds = g.Sum(p => p.Vehicle.Beds) ?? 0,

                               Cost = g.Sum(p => p.Cost),
                               Rose = g.Sum(p => p.Rose),
                               Parked = g.Sum(p => p.Parked)
                           };

                var res2 = from s in res1
                           join t in _db.Tra_Tariffs on s.Key equals t.Code
                           select new
                           {
                               s.Key,
                               s.Count,

                               s.Seats,
                               s.Beds,

                               t.Rose1,
                               t.Rose2,
                               t.Price1,
                               t.Price2,

                               s.Cost,
                               s.Rose,
                               s.Parked,
                               Totals = s.Parked + s.Cost + s.Rose,

                               Station = t.Text,
                               Province = t.Group.Text,
                               Area = t.Group.Parent.Text,
                               Region = t.Group.Parent.Parent.Text
                           };

                var res3 = from s in res2
                           group s by new
                           {
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
                               Totals = g.Sum(p => p.Totals),

                               Vat = g.Sum(p => p.Totals) * 10 / 100,
                               Sales = g.Sum(p => p.Totals) * 90 / 100
                           };
                sum = res3.Sum(k => k.Totals);
                return res3.ToDataTable();
            }
            catch
            {
                sum = 0;
                return null;
            }
        }

        /// <summary>
        /// List of 20 lastest vihicles normal
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
        /// List all of vihicles fixed in depot
        /// </summary>
        /// <param name="number">Number of vihicle</param>
        /// <returns></returns>
        public DataTable GetInDepotFixed(string number = null)
        {
            return FindInDepot(Group.F, number).ToDataTable();
        }
        #endregion

        #region Vihicle normal
        /// <summary>
        /// Sum of vihicle normal in depot
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
        /// Revenue of vihicle normal in a shift
        /// </summary>
        /// <param name="sum">Sum of money</param>
        /// <param name="nhom">Group of vihicle</param>
        /// <returns></returns>
        public DataTable GetRevenueShift(out decimal sum, Group nhom = Group.N)
        {
            try
            {
                sum = 0;
                DateTime shift;

                int i = Global.Session.Shift(out shift);
                var more = String.Format("Ca {0} {1:dd/MM/yyyy}", i, shift);

                /*var s1 = _db.Tra_Details.Where(p => p.Pol_UserOutId != Global.Session.User.Id);
                var min = s1.Max(p => p.DateOut);

                var s2 = _db.Tra_Details.Where(p => p.Pol_UserOutId == Global.Session.User.Id);
                if (min == null) min = s2.Min(p => p.DateOut);
                var max = s2.Max(p => p.DateOut);*/

                var res = from s in _db.Tra_Details
                          //where s.DateOut >= min && s.DateOut <= max
                          where s.More.Contains(more)
                          && s.Vehicle.Fixed == false
                          && s.UserOutId == Global.Session.User.Id
                          orderby s.Order
                          select new
                          {
                              s.Id,
                              No_ = s.Order,

                              s.More,
                              s.Text,

                              UserInName = s.UserIn.Name,
                              UserInPhone = s.UserIn.Phone,

                              UserOutName = s.UserOut.Name,
                              Number = s.Vehicle.Code,

                              s.DateIn,
                              s.DateOut,

                              s.FullDay,
                              s.HalfDay,
                              TotalDays = s.FullDay + (s.HalfDay == 1 ? 0.5 : 0),

                              s.Price1,
                              s.Price2,
                              s.Money,

                              GroupName = s.Vehicle.Tariff.Group.Text,
                              GroupCode = s.Vehicle.Tariff.Group.Code,
                              KindName = s.Vehicle.Tariff.Text
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
        /// List of 20 lastest vihicles normal
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
        /// List all of vihicles fixed in depot
        /// </summary>
        /// <param name="number">Number of vihicle</param>
        /// <returns></returns>
        public DataTable GetInDepotNormal(string number = null)
        {
            return FindInDepot(Group.N, number).ToDataTable();
        }
        #endregion

        /// <summary>
        /// Theo dõi tháng xe cố định
        /// </summary>
        /// <returns></returns>
        public DataTable AuditMonthFixed(DateTime fr, DateTime to)
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
                               Th_Lk_Di = g.Sum(p => p.Guest) ?? 0
                           };

                var res2 =
                           from v in _db.Tra_Vehicles
                           join r in res1 on v.Id equals r.Key into l
                           from s in l.DefaultIfEmpty()
                           where v.Fixed == true
                           orderby v.Tariff.Group.Parent.Parent.Text,
                           v.Tariff.Group.Parent.Text, v.Tariff.Text,
                           v.Transport.Text, v.Code
                           select new
                           {
                               Region = v.Tariff.Group.Parent.Parent.Text,
                               Area = v.Tariff.Group.Parent.Text,
                               Province = v.Tariff.Group.Text,
                               Station = v.Tariff.Text,
                               Transport = v.Transport.Text,
                               Number = v.Code,

                               Kh_Soxe = 1,
                               Kh_Ts_Ghe = (v.Seats + v.Beds) - 1,
                               Kh_Lx_Xuatben = v.Node,

                               Th_Soxe = s.Key == null ? 0 : 1,
                               Th_Ts_Ghe = ((v.Seats + v.Beds) - 1) * (s.Th_Lx_Xuatben == null ? 0 : s.Th_Lx_Xuatben),
                               Th_Lx_Xuatben = s.Th_Lx_Xuatben == null ? 0 : s.Th_Lx_Xuatben,
                               Th_Lk_Di = s.Th_Lk_Di == null ? 0 : s.Th_Lk_Di,

                               Tile_Nottai = (decimal)(s.Th_Lx_Xuatben == null ? 0 : s.Th_Lx_Xuatben) / v.Node * 100,
                               Nottai_Hoatdong = (decimal)(s.Th_Lx_Xuatben == null ? 0 : s.Th_Lx_Xuatben) / 30
                           };
                return res2.ToDataTable();
            }
            catch { return null; }
        }

        /// <summary>
        /// Danh sách các xe cố định đã xuất bến để theo dõi
        /// </summary>
        /// <param name="fr">Từ ngày</param>
        /// <param name="to">Đến ngày</param>
        /// <returns></returns>
        public DataTable GetForAuditFixed(DateTime fr, DateTime to)
        {
            try
            {
                var res = from s in _db.Tra_Details
                          where (s.DateOut >= fr && s.DateOut <= to || s.UserOutId == null)
                          && s.Vehicle.Fixed == true
                          orderby s.DateOut descending, s.DateIn descending, s.Vehicle.Code
                          select new
                          {
                              s.Id,
                              UserInName = s.UserIn.Name,
                              Phone = s.UserIn.Phone,
                              s.DateIn,
                              s.Guest,
                              Route = s.Vehicle.Tariff.Text,
                              s.Vehicle.Node,

                              s.Vehicle.Code,
                              s.Vehicle.Seats,
                              s.Vehicle.Beds,
                              Transport = s.Vehicle.Transport.Text,

                              UserOutName = s.UserOut.Name,
                              s.DateOut
                          };
                return res.ToDataTable();
            }
            catch { return null; }
        }

        public DataTable SumaryCodinh(out decimal sum)
        {
            try
            {
                sum = 0;

                /*var s1 = _db.Tra_Details.Where(p => p.Pol_UserOutId != Global.Session.User.Id);
                var min = s1.Max(p => p.DateOut);

                var s2 = _db.Tra_Details.Where(p => p.Pol_UserOutId == Global.Session.User.Id);
                if (min == null) min = s2.Min(p => p.DateOut);
                var max = s2.Max(p => p.DateOut);*/

                // Ca làm việc
                DateTime shift;
                int i = Global.Session.Shift(out shift);
                var more = String.Format("Ca {0} {1:dd/MM/yyyy}", i, shift);

                var res = from s in _db.Tra_Details
                          //where s.DateOut >= min && s.DateOut <= max
                          where s.Vehicle.Fixed == true
                          && s.UserOutId == Global.Session.User.Id
                          orderby s.Order
                          select new
                          {
                              s.Id,
                              //No_ = s.Order,
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

                              Region = s.Vehicle.Tariff.Group.Parent.Parent.Text,
                              Area = s.Vehicle.Tariff.Group.Parent.Text,
                              Province = s.Vehicle.Tariff.Group.Text,
                              Tariff = s.Vehicle.Tariff.Text,
                              Transport = s.Vehicle.Transport.Text,

                              s.Parked,
                              s.Cost,
                              s.Rose
                          };
                sum = res.Sum(k => k.Money);
                return res.ToDataTable();
            }
            catch
            {
                sum = 0;
                return null;
            }
        }
    }
}