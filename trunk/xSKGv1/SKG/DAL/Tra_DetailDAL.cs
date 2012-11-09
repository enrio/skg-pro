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
                              s.Tra_VehicleId,
                              s.Pol_UserInId,
                              s.Pol_UserOutId,
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
                          where s.Pol_UserOutId == null && s.Tra_VehicleId == o.Tra_VehicleId
                          select s;
                if (res.Count() > 0) return null; // xe này còn ở trong bến

                o.Id = Guid.NewGuid();
                o.Pol_UserInId = Global.Session.User.Id;

                // Cập nhật mã nhóm xe vãng lai/mã vùng xe cố định
                var ve = _db.Tra_Vehicles.SingleOrDefault(p => p.Id == o.Tra_VehicleId);
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

        /// <summary>
        /// Danh sách xe vào bến trong vòng 01 phút
        /// </summary>
        /// <returns>Danh sách</returns>
        public DataTable GetDataInMinute()
        {
            try
            {
                var d = GetDate().AddMinutes(-1);

                var res = from s in _db.Tra_Details

                          join k in _db.Tra_Vehicles on s.Tra_VehicleId equals k.Id
                          where s.Pol_UserOutId == null && s.DateIn >= d

                          orderby s.DateIn descending
                          select new
                          {
                              s.Id,
                              UserInName = s.Pol_UserIn.Name,
                              UserInPhone = s.Pol_UserIn.Phone,
                              s.DateIn,

                              //GroupId = k.Transport.GroupId,
                              KindId = k.TransportId,
                              GroupName = k.Tariff.Group.Text,
                              KindName = k.Tariff.Text,

                              k.Code,
                              Chair = k.Seats,
                              Descript = k.Note,
                              k.Driver,
                              k.Birth,
                              k.Address,
                              k.Phone
                          };

                return res.ToDataTable();

            }
            catch { return null; }
        }

        /// <summary>
        /// Danh sách 20 xe vào bến sau cùng XE VÃNG LAI
        /// </summary>
        /// <returns></returns>
        public DataTable Get20LatestForNormal()
        {
            try
            {
                var res = from s in _db.Tra_Details

                          join k in _db.Tra_Vehicles on s.Tra_VehicleId equals k.Id
                          where s.Pol_UserOutId == null && k.Fixed == false

                          orderby s.DateIn descending
                          select new
                          {
                              s.Id,
                              UserInName = s.Pol_UserIn.Name,
                              UserInPhone = s.Pol_UserIn.Phone,
                              s.DateIn,

                              //GroupId = k.Transport.GroupId,
                              KindId = k.TransportId,
                              GroupName = k.Tariff.Group.Text,
                              KindName = k.Tariff.Text,

                              k.Code,
                              k.Seats,
                              k.Beds,
                              Descript = k.Note,
                              k.Driver,
                              k.Birth,
                              k.Address,
                              k.Phone
                          };

                return res.Take(20).ToDataTable();

            }
            catch { return null; }
        }

        /// <summary>
        /// Danh sách 20 xe vào bến sau cùng cố định
        /// </summary>
        /// <returns></returns>
        public DataTable Get20LatestForFixed()
        {
            try
            {
                var res = from s in _db.Tra_Details

                          join k in _db.Tra_Vehicles on s.Tra_VehicleId equals k.Id
                          where s.Pol_UserOutId == null && k.Fixed == true

                          orderby s.DateIn descending
                          select new
                          {
                              s.Id,
                              UserInName = s.Pol_UserIn.Name,
                              UserInPhone = s.Pol_UserIn.Phone,
                              s.DateIn,

                              KindId = k.TransportId,
                              Transport = k.Transport.Text,
                              Route = k.Tariff.Text,

                              k.Code,
                              k.Seats,
                              k.Beds,
                              Descript = k.Note,
                              k.Driver,
                              k.Birth,
                              k.Address,
                              k.Phone
                          };

                return res.Take(20).ToDataTable();

            }
            catch { return null; }
        }

        /// <summary>
        /// Danh sách xe vãng lai trong bến
        /// </summary>        
        /// <param name="number">Biển số xe</param>
        /// <returns></returns>
        public DataTable GetInDepotFixed(string number = null)
        {

            try
            {
                var res = from s in _db.Tra_Details
                          where s.Pol_UserOutId == null
                          && s.Tra_Vehicle.Fixed == true
                          orderby s.DateIn descending, s.Tra_Vehicle.Code
                          select new
                          {
                              s.Id,
                              UserInName = s.Pol_UserIn.Name,
                              Phone = s.Pol_UserIn.Phone,
                              s.DateIn,
                              s.Guest,
                              Route = s.Tra_Vehicle.Tariff.Text,
                              s.Tra_Vehicle.Node,

                              s.Tra_Vehicle.Code,
                              s.Tra_Vehicle.Seats,
                              s.Tra_Vehicle.Beds,
                              Transport = s.Tra_Vehicle.Transport.Text,
                          };

                if (number != null)
                    res = res.Where(p => p.Code == number);
                return res.ToDataTable();
            }
            catch { return null; }
        }

        /// <summary>
        /// Danh sách xe vãng lai trong bến
        /// </summary>        
        /// <param name="number">Biển số xe</param>
        /// <returns></returns>
        public DataTable GetInDepotNormal(string number = null)
        {

            try
            {
                var res = from s in _db.Tra_Details

                          join v in _db.Tra_Vehicles on s.Tra_VehicleId equals v.Id
                          join k in _db.Tra_Tariffs on v.TariffId equals k.Id

                          where s.Pol_UserOutId == null && v.Fixed == false
                          orderby s.DateIn descending, v.Code

                          select new
                          {
                              s.Id,
                              UserInName = s.Pol_UserIn.Name,
                              Phone = s.Pol_UserIn.Phone,
                              s.DateIn,

                              v.Code,
                              v.Seats,
                              v.Beds,

                              KindName = k.Text,
                              GroupName = k.Group.Text,
                          };

                if (number != null)
                    res = res.Where(p => p.Code == number);
                return res.ToDataTable();
            }
            catch { return null; }
        }

        /// <summary>
        /// Danh sách xe trong bến
        /// </summary>        
        /// <param name="number">Biển số xe</param>
        /// <returns></returns>
        public DataTable GetInDepot(string number = null)
        {

            try
            {
                var res = from s in _db.Tra_Details

                          join v in _db.Tra_Vehicles on s.Tra_VehicleId equals v.Id
                          join k in _db.Tra_Tariffs on v.TariffId equals k.Id

                          where s.Pol_UserOutId == null
                          orderby s.DateIn descending, v.Code

                          select new
                          {
                              s.Id,
                              UserInName = s.Pol_UserIn.Name,
                              Phone = s.Pol_UserIn.Phone,
                              s.DateIn,
                              s.Guest,

                              v.Code,
                              v.Seats,
                              v.Beds,

                              KindName = k.Text,
                              GroupName = k.Group.Text,
                          };

                if (number != null)
                    res = res.Where(p => p.Code == number);
                return res.ToDataTable();
            }
            catch { return null; }
        }

        /// <summary>
        /// Danh sách xe đã ra bến
        /// </summary>
        /// <param name="total">Tổng số tiền</param>
        /// <param name="staIn">Xe trong bến</param>
        /// <param name="number">Biển số xe</param>
        /// <returns></returns>
        public DataTable GetOutDepot(out int total, string number = null)
        {
            total = 0;

            try
            {
                var res = from s in _db.Tra_Details
                          where s.Pol_UserOutId != null && !_db.Tra_Details.Any(p => p.Tra_VehicleId == s.Tra_VehicleId && p.Pol_UserOutId == null)
                          && s.DateOut == (from y in _db.Tra_Details where y.Tra_VehicleId == s.Tra_VehicleId select (DateTime?)y.DateOut).Max()
                          orderby s.Pol_UserOut.Name, s.Tra_Vehicle.Code
                          select new
                          {
                              UserInName = s.Pol_UserIn.Name,
                              UserOutName = s.Pol_UserOut.Name,
                              s.DateIn,
                              s.DateOut,

                              Number = s.Code,

                              s.Price1,
                              s.Price2,

                              s.Rose1,
                              s.Rose2,

                              s.Money
                          };

                var tmp = res.Sum(k => k.Money);
                total = Convert.ToInt32(tmp);

                if (number != null) res.Where(p => p.Number == number).ToDataTable();
                return res.ToDataTable();
            }
            catch { return null; }
        }

        /// <summary>
        /// Tính tiền và cho xe ra bến (cho xe cố định và vãng lai)
        /// </summary>
        /// <param name="number">Biển số xe</param>
        /// <param name="isOut">Cho xe ra bến</param>
        /// <returns></returns>
        public Tra_Detail InvoiceOut(string number, bool isOut)
        {
            try
            {
                var a = _db.Tra_Details.SingleOrDefault(k => k.Tra_Vehicle.Code == number && k.Pol_UserOutId == null);
                a.DateOut = Global.Session.Current;

                var ql = Global.Session.User.CheckOperator() || Global.Session.User.CheckAdmin();
                if (ql && a.Tra_Vehicle.Fixed)
                {
                    a.Repair = true; // cho ra ngoài để sửa chữa (không tính tiền lúc ra bến)
                    a.Note = String.Format("ĐỘI ĐIỀU HÀNH TẠM CHO RA BẾN\n\r ({0})", Global.Session.User.Name);
                }

                if (isOut && !ql) // cho ra
                {
                    // Người cho ra
                    a.Pol_UserOutId = Global.Session.User.Id;

                    if (a.Tra_Vehicle.Fixed)
                    {
                        // Đánh số phiếu thu theo tháng, năm
                        var dt = _db.Tra_Details.Where(p => p.Code == a.Code
                            && p.DateOut.Value.Month == Global.Session.Current.Month
                            && p.DateOut.Value.Year == Global.Session.Current.Year);

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
                    int i = Global.Session.Shift(out shift);
                    a.More = String.Format("Ca {0} {1:dd/MM/yyyy}", i, shift);
                    a.Text = i == 1 ? "07:00-16:00" : "16:00-07:00";
                }

                a.Seats = a.Tra_Vehicle.Seats;
                a.Beds = a.Tra_Vehicle.Beds;

                a.Price1 = a.Tra_Vehicle.Tariff.Price1;
                a.Rose1 = a.Tra_Vehicle.Tariff.Rose1;

                a.Price2 = a.Tra_Vehicle.Tariff.Price2;
                a.Rose2 = a.Tra_Vehicle.Tariff.Rose2;

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

                a.Money = a.Tra_Vehicle.Fixed ? a.ChargeForFixed() : a.ChargeForNormal();

                // Tính tiền lưu đậu đêm lần trước (ra do xin ra ngoài sửa xe)
                var b = _db.Tra_Details.FirstOrDefault(k => k.Tra_Vehicle.Code == number && k.Repair == true && k.Id != a.Id);
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
        /// Tổng số xe tuyến cố định trong bến
        /// </summary>
        /// <returns></returns>
        public int SumOfFixed()
        {
            return _db.Tra_Details.Count(k => k.Pol_UserOutId == null && k.Tra_Vehicle.Fixed == true);
        }

        /// <summary>
        /// Doanh thu xe cố định
        /// </summary>
        /// <param name="sum"></param>
        /// <returns></returns>
        public DataTable SumaryFixed(out decimal sum, DateTime fr, DateTime to)
        {
            try
            {
                var res1 = from s in _db.Tra_Details
                           where s.Pol_UserOutId != null
                           && s.Tra_Vehicle.Fixed == true
                           && s.Repair == false
                           && s.DateOut >= fr && s.DateOut <= to
                           group s by s.Tra_Vehicle.Tariff.Code into g
                           select new
                           {
                               g.Key,
                               Count = g.Count(),

                               Seats = g.Sum(p => p.Tra_Vehicle.Seats) ?? 0,
                               Beds = g.Sum(p => p.Tra_Vehicle.Beds) ?? 0,

                               Cost = g.Sum(p => p.Cost),
                               Rose = g.Sum(p => p.Rose),
                               Parked = g.Sum(p => p.Parked),

                               //Money = g.Sum(p => p.Money),
                           };

                var res2 = from s in res1
                           join t in _db.Tra_Tariffs on s.Key equals t.Code
                           select new
                           {
                               s.Key,
                               s.Count,

                               s.Seats,
                               s.Beds,

                               s.Cost,
                               s.Rose,
                               s.Parked,

                               //s.Money,
                               Totals = s.Parked + s.Cost + s.Rose,

                               Station = t.Text,
                               Province = t.Group.Text,
                               Area = t.Group.Parent.Text,
                               Region = t.Group.Parent.Parent.Text,

                               t.Rose1,
                               t.Rose2,
                               t.Price1,
                               t.Price2
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
                sum = 0;
                sum = res3.Sum(k => k.Totals);
                return res3.ToDataTable();
            }
            catch
            {
                sum = 0;
                return null;
            }
        }
        #endregion

        #region Vihicle normal
        /// <summary>
        /// Tổng số xe vãng lai trong bến
        /// </summary>
        /// <returns></returns>
        public int SumOfNormal()
        {
            return _db.Tra_Details.Count(k => k.Pol_UserOutId == null && k.Tra_Vehicle.Fixed == false);
        }

        /// <summary>
        /// Bảng kê xe vãng lai
        /// </summary>
        /// <param name="nhom">Nhóm xe</param>
        /// <returns></returns>
        public DataTable SumaryNormal(out decimal sum, Group nhom = Group.Z)
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
                          where s.More.Contains(more)
                          && s.Tra_Vehicle.Fixed == false
                          && s.Pol_UserOutId == Global.Session.User.Id
                          orderby s.Order
                          select new
                          {
                              s.Id,
                              No_ = s.Order,
                              s.More,
                              s.Text,

                              UserInName = s.Pol_UserIn.Name,
                              UserInPhone = s.Pol_UserIn.Phone,

                              UserOutName = s.Pol_UserOut.Name,
                              Number = s.Tra_Vehicle.Code,

                              s.DateIn,
                              s.DateOut,

                              s.FullDay,
                              s.HalfDay,
                              TotalDays = s.FullDay + (s.HalfDay == 1 ? 0.5 : 0),
                              s.Money,

                              s.Price1,
                              s.Price2,

                              GroupName = s.Tra_Vehicle.Tariff.Group.Text,
                              GroupCode = s.Tra_Vehicle.Tariff.Group.Code,
                              KindName = s.Tra_Vehicle.Tariff.Text
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
                           where s.Pol_UserOutId != null
                           && s.Tra_Vehicle.Fixed == true
                           && s.Repair == false
                           && s.DateOut >= fr && s.DateOut <= to
                           && s.Parked != s.Money
                           group s by s.Tra_VehicleId into g
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

                               Th_Soxe = 1,
                               Th_Ts_Ghe = 0,
                               Th_Lx_Xuatben = s.Th_Lx_Xuatben == null ? 0 : s.Th_Lx_Xuatben,
                               Th_Lk_Di = s.Th_Lk_Di == null ? 0 : s.Th_Lk_Di,
                               Tile_Nottai = (s.Th_Lx_Xuatben == null ? 0 : s.Th_Lx_Xuatben) / v.Node * 100,
                               Nottai_Hoatdong = (s.Th_Lx_Xuatben == null ? 0 : s.Th_Lx_Xuatben) / 30
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
                          where (s.DateOut >= fr && s.DateOut <= to || s.Pol_UserOutId == null)
                          && s.Tra_Vehicle.Fixed == true
                          orderby s.DateOut descending, s.DateIn descending, s.Tra_Vehicle.Code
                          select new
                          {
                              s.Id,
                              UserInName = s.Pol_UserIn.Name,
                              Phone = s.Pol_UserIn.Phone,
                              s.DateIn,
                              s.Guest,
                              Route = s.Tra_Vehicle.Tariff.Text,
                              s.Tra_Vehicle.Node,

                              s.Tra_Vehicle.Code,
                              s.Tra_Vehicle.Seats,
                              s.Tra_Vehicle.Beds,
                              Transport = s.Tra_Vehicle.Transport.Text,

                              UserOutName = s.Pol_UserOut.Name,
                              s.DateOut
                          };
                return res.ToDataTable();
            }
            catch { return null; }
        }
    }
}