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
                o.Pol_UserInId = Global.Session.User.Id;

                // Cập nhật mã nhóm xe vãng lai/mã vùng xe cố định
                var ve = _db.Tra_Vehicles.SingleOrDefault(p => p.Id == o.Tra_VehicleId);
                o.Code = ve.Tariff.Group.Code;

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
        /// Danh sách 20 xe vào bến sau cùng XE VÃNG LAI
        /// </summary>
        /// <returns></returns>
        public DataTable Get20LatestForNormal()
        {
            try
            {
                var res = from s in _db.Tra_Details

                          join k in _db.Tra_Vehicles on s.Tra_VehicleId equals k.Id
                          where s.DateOut == null && k.Fixed == false

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
                          where s.DateOut == null && k.Fixed == true

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

                          join v in _db.Tra_Vehicles on s.Tra_VehicleId equals v.Id
                          join k in _db.Tra_Tariffs on v.TariffId equals k.Id

                          where s.Pol_UserOutId == null && v.Fixed == true
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

                              Route = k.Text,
                              Transport = v.Transport.Text,
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
        /// Tính tiền và cho xe ra bến (cho xe cố định và vãng lai)
        /// </summary>
        /// <param name="number">Biển số xe</param>
        /// <param name="isOut">Cho xe ra bến</param>
        /// <returns></returns>
        public Tra_Detail InvoiceOut(string number, bool isOut)
        {
            try
            {
                var a = _db.Tra_Details.SingleOrDefault(k => k.Tra_Vehicle.Code == number && k.DateOut == null);

                a.Pol_UserOutId = Global.Session.User.Id;
                a.DateOut = Global.Session.Current;

                a.Seats = a.Tra_Vehicle.Seats;
                a.Beds = a.Tra_Vehicle.Beds;

                a.Price1 = a.Tra_Vehicle.Tariff.Price1;
                a.Rose1 = a.Tra_Vehicle.Tariff.Rose1;

                a.Price2 = a.Tra_Vehicle.Tariff.Price2;
                a.Rose2 = a.Tra_Vehicle.Tariff.Rose2;

                a.Money = a.Tra_Vehicle.Fixed ? a.ChargeForFixed() : a.ChargeForNormal();

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

                if (isOut)
                {
                    // Đánh số thứ tự từng nhóm xe (tải lưu đậu, sang hàng, xe cố định
                    var dt = _db.Tra_Details.Where(p => p.Code == a.Code);
                    a.Order = dt.Max(p => p.Order) + 1;

                    _db.SaveChanges();
                }
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
            return _db.Tra_Details.Count(k => k.DateOut == null && k.Tra_Vehicle.Fixed == true);
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
                sum = 0;

                var res = from s in _db.Tra_Details
                          where s.DateOut != null
                          && s.Tra_Vehicle.Fixed == true
                          && s.DateOut >= fr && s.DateOut <= to
                          orderby s.Pol_UserOutId, s.Tra_Vehicle.Code
                          select new
                          {
                              UserInName = s.Pol_UserIn.Name,
                              UserInPhone = s.Pol_UserIn.Phone,

                              UserOutName = s.Pol_UserOut.Name,
                              Number = s.Tra_Vehicle.Code,

                              s.DateIn,
                              s.DateOut,

                              s.Money,

                              s.Price1,
                              s.Price2,

                              s.Rose1,
                              s.Rose2,

                              Region = s.Tra_Vehicle.Tariff.Group.Parent.Text,
                              Area = s.Tra_Vehicle.Tariff.Group.Text,
                              Route = s.Tra_Vehicle.Tariff.Text
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
        #endregion

        #region Vihicle normal
        /// <summary>
        /// Tổng số xe vãng lai trong bến
        /// </summary>
        /// <returns></returns>
        public int SumOfNormal()
        {
            return _db.Tra_Details.Count(k => k.DateOut == null && k.Tra_Vehicle.Fixed == false);
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

                var res = from s in _db.Tra_Details
                          where s.DateOut != null
                          && s.Tra_Vehicle.Fixed == false
                          && s.Pol_UserOutId == Global.Session.User.Id
                          //&& s.Order > min && s.Order <= max
                          orderby s.Order
                          select new
                          {
                              No_ = s.Order,

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
                              KindName = s.Tra_Vehicle.Tariff.Text,
                              s.Order
                          };


                if (nhom == Group.A)
                {
                    const string grp = "GROUP_0";
                    var s1 = _db.Tra_Details.Where(p => p.Pol_UserOutId != Global.Session.User.Id);
                    s1 = s1.Where(p => p.Code == grp);

                    var s2 = _db.Tra_Details.Where(p => p.Pol_UserOutId == Global.Session.User.Id);
                    s2 = s2.Where(p => p.Code == grp);

                    int min = s1.Count() == 0 ? 0 : s1.Max(p => p.Order);
                    int max = s2.Count() == 0 ? 0 : s2.Max(p => p.Order);

                    res = res.Where(p => p.GroupCode == grp);
                    res = res.Where(p => p.Order > min && p.Order <= max);
                }
                else if (nhom == Group.B)
                {
                    const string grp = "GROUP_1";
                    var s1 = _db.Tra_Details.Where(p => p.Pol_UserOutId != Global.Session.User.Id);
                    s1 = s1.Where(p => p.Code == grp);

                    var s2 = _db.Tra_Details.Where(p => p.Pol_UserOutId == Global.Session.User.Id);
                    s2 = s2.Where(p => p.Code == grp);

                    int min = s1.Count() == 0 ? 0 : s1.Max(p => p.Order);
                    int max = s2.Count() == 0 ? 0 : s2.Max(p => p.Order);

                    res = res.Where(p => p.GroupCode == grp);
                    res = res.Where(p => p.Order > min && p.Order <= max);
                }

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
    }
}