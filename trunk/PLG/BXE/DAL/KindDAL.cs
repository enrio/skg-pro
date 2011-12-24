using System;
using System.Linq;
using System.Data;

namespace BXE.DAL
{
    public class KindDAL : CsoDAL, UTL.DAL.ItfDAL
    {
        #region Implement method
        public int Count()
        {
            throw new NotImplementedException();
        }

        public DataTable GetData()
        {
            try
            {
                var res = from s in _mdb.Kinds
                          orderby s.Name
                          select new
                          {
                              s.Id,
                              s.Name,
                              s.Descript,
                              s.GroupId,
                              s.LengthMax,
                              s.LengthMin,
                              s.WeightMax,
                              s.WeightMin,
                              s.ChairMax,
                              s.ChairMin,
                              s.Money1,
                              s.Money2,
                              s.Type
                          };
                return UTL.DAL.MorUkxYlm.ToDataTable(res);
            }
            catch { return null; }
        }

        public DataTable GetData(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public DataTable GetData(object key, bool pkey = true)
        {
            throw new NotImplementedException();
        }

        public DataTable Search(object obj)
        {
            throw new NotImplementedException();
        }

        public object GetData(object obj)
        {
            try
            {
                var res = from s in _mdb.Kinds
                          where s.GroupId == Convert.ToInt64(obj)
                          orderby s.Name
                          select new
                          {
                              s.Id,
                              s.Name,
                              s.Group,
                              s.Money1,
                              s.Money2,
                              s.Type,
                              s.ChairMin,
                              s.ChairMax,
                              s.LengthMin,
                              s.LengthMax,
                              s.WeightMin,
                              s.WeightMax
                          };
                return UTL.DAL.MorUkxYlm.ToDataTable(res);
            }
            catch { return null; }
        }

        public bool Insert(object obj)
        {
            Kind o = (Kind)obj;

            try
            {
                _mdb.Kinds.Single(k => k.Name == o.Name);

                return false;
            }
            catch
            {
                try
                {
                    _mdb.Kinds.InsertOnSubmit(o);
                    _mdb.SubmitChanges();

                    return true;
                }
                catch { return false; }
            }
        }

        public bool Update(object obj)
        {
            Kind o = (Kind)obj;
            if (o.Name + "" == "") return false;

            try
            {
                var res = _mdb.Kinds.Single(k => k.Id == o.Id);
                res.Name = o.Name;
                res.GroupId = o.GroupId;
                res.WeightMin = o.WeightMin;
                res.WeightMax = o.WeightMax;
                res.LengthMin = o.LengthMin;
                res.LengthMax = o.LengthMax;
                res.ChairMin = o.ChairMin;
                res.ChairMax = o.ChairMax;
                res.Descript = o.Descript;
                res.Money1 = o.Money1;
                res.Money2 = o.Money2;

                _mdb.SubmitChanges();

                return true;
            }
            catch { return false; }
        }

        public bool Delete(object obj)
        {
            long id = ((Kind)obj).Id;

            try
            {
                var res = from s in _mdb.Kinds
                          where s.Id == id
                          select s;
                if (res != null)
                {
                    var et = res.Single();
                    _mdb.Kinds.DeleteOnSubmit(et);
                    _mdb.SubmitChanges();

                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool CheckExist(object obj)
        {
            throw new NotImplementedException();
        }

        public UTL.CsoInf GetInf()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}