using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    using System.Data;
    using Entities;

    /// <summary>
    /// Vận tải - Xử lí bảng Tra_Detail
    /// </summary>
    public abstract class Tra_DetailDAL : BaseDAL, UTL.IBaseDAL
    {
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

                res.Tra_VehicleId = o.Tra_VehicleId;
                res.Pol_UserInId = o.Pol_UserInId;
                res.Pol_UserOutId = o.Pol_UserOutId;
                res.DateIn = o.DateIn;
                res.DateOut = o.DateOut;

                res.Code = o.Code;
                res.Descript = o.Descript;
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

                              GroupId = k.Tra_Kind.Tra_GroupId,
                              KindId = k.Tra_KindId,
                              GroupName = k.Tra_Kind.Tra_Group.Name,
                              KindName = k.Tra_Kind.Name,
                              k.Chair,
                              k.Number,
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
        /// Danh sách xe trong bến (ngoài bến)
        /// </summary>
        /// <param name="total">Số lượng xe</param>
        /// <param name="staIn">Xe trong bến</param>
        /// <returns>Danh sách xe</returns>
        public DataTable GetInDepot(out decimal total, bool staIn = true)
        {
            total = 0;

            try
            {
                if (staIn)
                {
                    var res = from s in _db.Tra_Details

                              join v in _db.Tra_Vehicles on s.Tra_VehicleId equals v.Id
                              join k in _db.Tra_Kinds on v.Tra_KindId equals k.Id

                              where s.Pol_UserOutId == null
                              orderby v.Number

                              select new
                              {
                                  s.Id,
                                  UserInName = s.Pol_UserIn.Name,
                                  Phone = s.Pol_UserIn.Phone,
                                  s.DateIn,

                                  v.Number,
                                  v.Chair,

                                  KindName = k.Name,
                                  GroupName = k.Tra_Group.Name,
                              };

                    total = res.Count();

                    return res.ToDataTable();
                }
                else
                {
                    var res = from s in _db.Tra_Details
                              where s.DateOut != null && !_db.Tra_Details.Any(p => p.Tra_VehicleId == s.Tra_VehicleId && p.DateOut == null)
                              && s.DateOut == (from y in _db.Tra_Details where y.Tra_VehicleId == s.Tra_VehicleId select (DateTime?)y.DateOut).Max()
                              orderby s.Pol_UserOut.Name, s.Tra_Vehicle.Number
                              select new
                              {
                                  UserInName = s.Pol_UserIn.Name,
                                  UserOutName = s.Pol_UserOut.Name,
                                  s.DateIn,
                                  s.DateOut,

                                  Number = s.Code,
                                  s.Price1,
                                  s.Price2,
                                  s.Money
                              };

                    var tmp = res.Sum(k => k.Money);
                    total = Convert.ToDecimal(tmp);

                    return res.ToDataTable();
                }
            }
            catch { return null; }
        }
    }
}