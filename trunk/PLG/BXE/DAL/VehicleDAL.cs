using System;
using System.Linq;
using System.Data;

namespace BXE.DAL
{
    class VehicleDAL : CsoDAL, UTL.DAL.ItfDAL
    {
        #region Implement method
        public int Count()
        {
            throw new NotImplementedException();
        }

        public DataTable GetData()
        {
            throw new NotImplementedException();
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
            Vehicle o = (Vehicle)obj;

            try
            {
                var res = from s in _mdb.Vehicles
                          where s.Number == o.Number
                          select s;
                return res.Single();
            }
            catch { return null; }
        }

        public bool Insert(object obj)
        {
            Vehicle o = (Vehicle)obj;

            try
            {
                _mdb.Vehicles.Single(k => k.Id == o.Id);

                return false;
            }
            catch
            {
                _mdb.Vehicles.InsertOnSubmit(o);
                _mdb.SubmitChanges();

                return true;
            }
        }

        public bool Update(object obj)
        {
            Vehicle o = (Vehicle)obj;

            try
            {
                var res = _mdb.Vehicles.Single(k => k.Id == o.Id);
                res.Number = o.Number;
                res.Name = o.Name;

                _mdb.SubmitChanges();
                return true;

            }
            catch { return false; }
        }

        public bool Delete(object obj)
        {
            long id = ((Vehicle)obj).Id;

            try
            {
                var res = from s in _mdb.Vehicles
                          where s.Id == id
                          select s;
                if (res != null)
                {
                    var et = new Vehicle { Id = id };
                    _mdb.Vehicles.Attach(et);
                    _mdb.Vehicles.DeleteOnSubmit(et);
                    _mdb.SubmitChanges();
                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool CheckExist(object obj)
        {
            try
            {
                if ((string)obj == "BG") return false; // không kiểm tra xe ba bánh
                var res = _mdb.Vehicles.Single(k => k.Number == (string)obj);
                return res == null ? false : true;
            }
            catch { return false; }
        }

        public UTL.CsoInf GetInf()
        {
            throw new NotImplementedException();
        }
        #endregion

        public DataTable Vehicles_In()
        {
            return UTL.DAL.MorUkxYlm.ToDataTable(_mdb.Vehicles_In());
        }

        public DataTable Vehicles_Out()
        {
            return UTL.DAL.MorUkxYlm.ToDataTable(_mdb.Vehicles_Out());
        }
    }
}