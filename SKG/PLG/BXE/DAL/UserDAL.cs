using System;
using System.Linq;
using System.Data;

namespace BXE.DAL
{
    public class UserDAL : CsoDAL, UTL.DAL.ItfDAL
    {
        #region Implement method
        public int Count() { return _mdb.Users.Count(); }

        public DataTable GetData()
        {
            try
            {
                var res = from s in _mdb.Users
                          orderby s.Name
                          select new
                          {
                              s.Id,
                              s.Acc,
                              s.Pass,
                              s.Name,
                              s.Birth,
                              s.Address,
                              s.Phone,
                              s.Role
                          };

                return UTL.DAL.MorUkxYlm.ToDataTable(res);
            }
            catch { return null; }
        }

        public DataTable GetData(int skip, int take)
        {
            try
            {
                var res = from s in _mdb.Users
                          orderby s.Name
                          select new
                          {
                              Stt = "",
                              s.Id,
                              s.Acc,
                              s.Pass,
                              s.Name,
                              s.Birth,
                              s.Address,
                              s.Phone,
                              s.Role
                          };

                return UTL.DAL.MorUkxYlm.ToDataTable(res.Skip(skip).Take(take));
            }
            catch { return null; }
        }

        public DataTable GetData(object key, bool pkey = true)
        {
            long id;

            if (pkey) { id = ((User)key).Id; }
            else { return null; }

            try
            {
                var res = from s in _mdb.Users
                          where s.Id == id
                          orderby s.Name
                          select new
                          {
                              Stt = "",
                              s.Id,
                              s.Acc,
                              s.Pass,
                              s.Name,
                              s.Birth,
                              s.Address,
                              s.Phone,
                              s.Role
                          };

                return UTL.DAL.MorUkxYlm.ToDataTable(res);
            }
            catch { return null; }
        }

        public DataTable Search(object obj)
        {
            User o = (User)obj;

            try
            {
                var res = from s in _mdb.Users
                          where s.Name == o.Name
                          orderby s.Name
                          select new
                          {
                              Stt = "",
                              s.Id,
                              s.Acc,
                              s.Pass,
                              s.Name,
                              s.Birth,
                              s.Address,
                              s.Phone,
                              s.Role
                          };

                return UTL.DAL.MorUkxYlm.ToDataTable(res);
            }
            catch { return null; }
        }

        public object GetData(object obj) { return null; }

        public bool Insert(object obj)
        {
            User o = (User)obj;
            if (o.Acc + "" == "") return false;

            try
            {
                _mdb.Users.Single(k => k.Acc == o.Acc);

                return false;
            }
            catch
            {
                try
                {
                    _mdb.Users.InsertOnSubmit(o);
                    _mdb.SubmitChanges();

                    return true;
                }
                catch { return false; }
            }
        }

        public bool Update(object obj)
        {
            User o = (User)obj;
            if (o.Acc + "" == "") return false;

            try
            {
                var res = _mdb.Users.Single(k => k.Id == o.Id || k.Acc == o.Acc);
                res.Acc = o.Acc;
                res.Pass = o.Pass;
                res.Name = o.Name;
                res.Birth = o.Birth;
                res.Address = o.Address;
                res.Phone = o.Phone;
                res.Role = o.Role;

                _mdb.SubmitChanges();

                return true;
            }
            catch { return false; }
        }

        public bool Delete(object obj)
        {
            long id = ((User)obj).Id;

            try
            {
                var res = from s in _mdb.Users
                          where s.Id == id
                          select s;
                if (res != null)
                {
                    var et = res.Single();
                    _mdb.Users.DeleteOnSubmit(et);
                    _mdb.SubmitChanges();

                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool CheckExist(object obj) { return false; }
        public UTL.CsoInf GetInf() { return null; }
        #endregion

        public User GetPass(string acc)
        {
            try
            {
                return _mdb.Users.Single(k => k.Acc == acc);
            }
            catch { return null; }
        }

        public DataSet GetDataSet()
        {
            var res = new DataSet();
            res.Tables.Add(GetData());
            return res;
        }
    }
}