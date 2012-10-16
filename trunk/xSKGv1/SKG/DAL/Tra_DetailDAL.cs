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
                          where s.DateOut == null && s.Tra_VehicleId == o.Tra_VehicleId
                          select s;
                if (res.Count() > 0) return null; // xe này còn ở trong bến

                o.Id = Guid.NewGuid();
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
                          where s.DateOut == null && s.DateIn >= d

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
        /// Danh sách 20 xe vào bến sau cùng
        /// </summary>
        /// <returns></returns>
        public DataTable Get20Latest()
        {
            try
            {
                var res = from s in _db.Tra_Details

                          join k in _db.Tra_Vehicles on s.Tra_VehicleId equals k.Id
                          where s.DateOut == null

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
        /// Danh sách xe trong bến
        /// </summary>
        /// <param name="total">Số lượng xe</param>
        /// <param name="staIn">Xe trong bến</param>
        /// <param name="number">Biển số xe</param>
        /// <returns></returns>
        public DataTable GetInDepot(out int total, string number = null)
        {
            total = 0;

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

                              v.Code,
                              v.Seats,
                              v.Beds,

                              KindName = k.Text,
                              GroupName = k.Group.Text,
                          };

                total = res.Count();
                if (number != null) res = res.Where(p => p.Code == number);

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
                          where s.DateOut != null && !_db.Tra_Details.Any(p => p.Tra_VehicleId == s.Tra_VehicleId && p.DateOut == null)
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
        /// Tính tiền, cho xe ra
        /// </summary>
        /// <param name="obj">Đối tượng Tra_Detail</param>
        /// <param name="day">Số ngày đậu tại bến</param>
        /// <param name="hour">Số giờ lẻ đậu tại bến</param>
        /// <param name="money">Thành tiền</param>
        /// <param name="price1">Đơn giá nửa ngày</param>
        /// <param name="price2">Đơn giá một ngày</param>
        /// <param name="isOut">Cho xe ra</param>
        /// <returns></returns>
        public DataTable InvoiceOut(Tra_Detail obj, ref int day, ref int hour, ref decimal money,
            ref int price1, ref int price2, ref int rose1, ref int rose2, bool isOut = false)
        {
            try
            {
                var res = from s in _db.Tra_Details

                          join v in _db.Tra_Vehicles on s.Tra_VehicleId equals v.Id
                          join k in _db.Tra_Tariffs on v.TariffId equals k.Id
                          join l in _db.Tra_Registries on v.Id equals l.VehicleId

                          where s.Tra_VehicleId == obj.Tra_VehicleId
                          orderby v.Code

                          select new
                          {
                              s.Id,
                              UserInName = s.Pol_UserIn.Name,
                              UserInPhone = s.Pol_UserIn.Phone,
                              UserOutName = s.Pol_UserOut.Name,
                              v.Code,
                              v.Fixed,

                              s.DateIn,
                              s.DateOut,
                              s.Days,
                              s.Hours,

                              v.Seats,
                              v.Beds,

                              Tra_GroupId = l.Tariff.GroupId,
                              GroupName = l.Tariff.Group.Text,
                              GroupCode = l.Tariff.Group.Code,
                              KindName = l.Tariff.Text,

                              l.Tariff.Price1,
                              l.Tariff.Price2,
                              l.Tariff.Rose1,
                              l.Tariff.Rose2,

                              s.Money
                          };

                if (res.Count() == 0)
                {
                    res = from s in _db.Tra_Details

                          join v in _db.Tra_Vehicles on s.Tra_VehicleId equals v.Id
                          join k in _db.Tra_Tariffs on v.TariffId equals k.Id

                          where s.Tra_VehicleId == obj.Tra_VehicleId
                          orderby v.Code

                          select new
                          {
                              s.Id,
                              UserInName = s.Pol_UserIn.Name,
                              UserInPhone = s.Pol_UserIn.Phone,
                              UserOutName = s.Pol_UserOut.Name,
                              v.Code,
                              v.Fixed,

                              s.DateIn,
                              s.DateOut,
                              s.Days,
                              s.Hours,

                              v.Seats,
                              v.Beds,

                              Tra_GroupId = k.GroupId,
                              GroupName = k.Group.Text,
                              GroupCode = k.Group.Code,
                              KindName = k.Text,

                              k.Price1,
                              k.Price2,
                              k.Rose1,
                              k.Rose2,

                              s.Money
                          };
                }

                var ok = res.Single(h => h.DateOut == null);

                var d = _db.Tra_Details.Single(k => k.Tra_VehicleId == obj.Tra_VehicleId && k.DateOut == null);
                TimeSpan? dt = obj.DateOut - d.DateIn; // tính số giờ đậu tại bến
                hour = dt.Value.Hours;
                day = dt.Value.Days;

                int dayL = (hour < 12) ? 1 : 0; // nhỏ hơn 12 giờ thì tính nửa ngày
                int dayF = (hour >= 12) ? day + 1 : day; // lớn hơn bằng 12 giờ thì tính một ngày

                price1 = ok.Price1;
                price2 = ok.Price2;

                rose1 = ok.Rose1;
                rose2 = ok.Rose2;

                int seats = ok.Seats ?? 0;
                int beds = ok.Beds ?? 0;

                if (ok.Fixed)
                    money = (price1 + rose1) * (seats > 1 ? seats - 1 : 0) + (price2 + rose2) * beds;
                else
                    money = (price1 + rose1) * dayL + (price2 + rose2) * dayF;

                if (isOut)
                {
                    d.Pol_UserOutId = obj.Pol_UserOutId; // Id user đang đăng nhập
                    d.DateOut = obj.DateOut; // thời gian hiện tại trên server

                    d.Days = dayF;
                    d.Hours = hour;

                    d.Price1 = price1;
                    d.Price2 = price2;

                    d.Rose1 = rose1;
                    d.Rose2 = rose2;

                    d.Money = money;

                    _db.SaveChanges();
                }

                return res.ToDataTable();
            }
            catch { return null; }
        }

        /// <summary>
        /// Thống kê theo thời gian ra bến, nhóm xe khi in, người dùng đăng nhập
        /// </summary>
        /// <param name="total">Tổng số tiền</param>
        /// <param name="fr">Từ ngày</param>
        /// <param name="to">Đến ngày</param>
        /// <param name="group">Nhóm xe khi in</param>
        /// <param name="userId">Id user đăng nhập</param>
        /// <returns>Dữ liệu</returns>
        public DataTable Sumary(out decimal total, DateTime fr, DateTime to, Group group = Group.Z, Guid userId = new Guid())
        {
            total = 0;

            try
            {
                var res = from s in _db.Tra_Details
                          join v in _db.Tra_Vehicles on s.Tra_VehicleId equals v.Id
                          join k in _db.Tra_Tariffs on v.TariffId equals k.Id

                          where s.DateOut != null && !_db.Tra_Details.Any(p => p.Tra_VehicleId == s.Tra_VehicleId && p.DateOut == null)
                              //&& s.DateOut == (from y in _db.Tra_Details where y.Tra_VehicleId == s.Tra_VehicleId select (DateTime?)y.DateOut).Max()
                          && s.DateOut >= fr && s.DateOut <= to
                          orderby s.Pol_UserOutId, s.Tra_Vehicle.Code

                          select new
                          {
                              UserInName = s.Pol_UserIn.Name,
                              UserInPhone = s.Pol_UserIn.Phone,

                              s.Pol_UserOutId,
                              UserOutName = s.Pol_UserOut.Name,

                              Number = s.Tra_Vehicle.Code,
                              s.DateIn,
                              s.DateOut,

                              s.Days,
                              HalfDay = s.Hours < 12 ? 1 : 0,
                              FullDays = s.Days + (s.Hours < 12 ? .5 : 0),

                              s.Price1,
                              s.Price2,
                              s.Rose1,
                              s.Rose2,
                              Price = s.Days == 0 ? s.Price1 : s.Price2,
                              s.Money,

                              GroupName = k.Group.Text,
                              KindName = k.Text,
                              GroupCode = k.Group.Code
                          };

                switch (group)
                {
                    case Group.A:
                        res = res.Where(p => p.GroupCode == "GROUP_1");
                        break;

                    case Group.B:
                        res = res.Where(p => p.GroupCode == "GROUP_2");
                        break;

                    default:
                        break;
                }

                if (userId != new Guid()) res = res.Where(p => p.Pol_UserOutId == userId);

                total = res.Sum(k => k.Money);
                return res.ToDataTable();
            }
            catch { return null; }
        }
    }
}