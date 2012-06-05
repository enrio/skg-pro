using System;
using System.Linq;
using System.Data;

namespace BXE.DAL
{
    class GroupDAL : CsoDAL, UTL.DAL.ItfDAL
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
                var res = from s in _mdb.Groups
                          orderby s.Name
                          select new
                          {
                              s.Id,
                              s.Name
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
            throw new NotImplementedException();
        }

        public bool Insert(object obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(object obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object obj)
        {
            throw new NotImplementedException();
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