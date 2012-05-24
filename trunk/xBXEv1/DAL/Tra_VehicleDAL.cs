using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    using System.Data;
    using Entities;

    /// <summary>
    /// Vận tải - Xử lí bảng Tra_Vehicle
    /// </summary>
    public abstract class Tra_VehicleDAL : BaseDAL, UTL.IBaseDAL
    {
        #region Implement
        public int Count()
        {
            return _db.Tra_Vehicles.Count();
        }

        public object Select(string code)
        {
            throw new NotImplementedException();
        }

        public DataTable Select(object obj = null, int skip = 0, int take = 0)
        {
            try
            {
                var res = from s in _db.Tra_Vehicles
                          select new
                          {
                              s.Id,
                              s.Number,
                              s.Descript,
                              s.Driver,
                              s.Birth,
                              s.Address,
                              s.Phone,

                              s.Code,
                              s.Order,
                              s.Show
                          };

                if (obj != null) res = res.Where(s => s.Number == obj + "");
                if (take > 0) res = res.Skip(skip).Take(take);

                return res.ToDataTable();
            }
            catch { return _tb; }
        }

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

        public object Update(object obj)
        {
            throw new NotImplementedException();
        }

        public object Delete(object obj = null)
        {
            try
            {
                if (obj != null)
                {
                    var res = _db.Tra_Vehicles.SingleOrDefault(s => s.Id == (Guid)obj);
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