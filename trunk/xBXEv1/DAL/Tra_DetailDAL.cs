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
        public int Count()
        {
            return _db.Tra_Details.Count();
        }

        public DataTable Select(Guid fKey)
        {
            throw new NotImplementedException();
        }

        public object Select(string code)
        {
            throw new NotImplementedException();
        }

        public DataTable Select(object obj = null, int skip = 0, int take = 0)
        {
            try
            {
                var res = from s in _db.Tra_Details
                          select new
                          {
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
                    res = res.Where(s => s.Tra_VehicleId == o.Tra_VehicleId && s.Pol_UserInId == o.Pol_UserInId && s.Pol_UserOutId == o.Pol_UserOutId);
                }

                if (take > 0) res = res.Skip(skip).Take(take);

                return res.ToDataTable();
            }
            catch { return _tb; }
        }

        public object Insert(object obj)
        {
            try
            {
                var o = (Tra_Detail)obj;
                o.Id = Guid.NewGuid();
                var oki = _db.Tra_Details.Add(o);

                _db.SaveChanges();
                return oki;
            }
            catch { return null; }
        }

        public object Update(object obj)
        {
            throw new NotImplementedException();
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
                var res = from s in _db.Tra_Details

                          join k in _db.Tra_Vehicles on s.Tra_VehicleId equals k.Id
                          where s.DateOut == null && s.DateIn.AddMinutes(1) >= GetDate()

                          orderby s.DateIn
                          select new
                          {
                              s.Id,
                              UserInName = s.Pol_UserIn.Name,
                              Phone = s.Pol_UserIn.Phone,
                              s.DateIn,

                              GroupId = k.Tra_Kind.Tra_GroupId,
                              KindId = k.Tra_KindId,
                              GroupName = k.Tra_Kind.Tra_Group.Name,
                              KindName = k.Tra_Kind.Name,
                              k.Chair,
                              k.Number
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