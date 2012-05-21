using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public abstract class VehicleDAL : BaseDAL, IBase
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable Select()
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable Select(object obj)
        {
            throw new NotImplementedException();
        }

        public BaseDAL.State Insert(object obj)
        {
            throw new NotImplementedException();
        }

        public BaseDAL.State Update(object obj)
        {
            throw new NotImplementedException();
        }

        public BaseDAL.State Delete(object obj)
        {
            throw new NotImplementedException();
        }
    }
}