using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    using System.Data;

    /// <summary>
    /// Xử lí bảng Tra_Group
    /// </summary>
    public abstract class Tra_GroupDAL : BaseDAL, UTL.IBaseDAL
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public DataTable Select()
        {
            throw new NotImplementedException();
        }

        public DataTable Select(object obj)
        {
            throw new NotImplementedException();
        }

        public DataTable Select(int take, int skip)
        {
            throw new NotImplementedException();
        }

        public DataTable Select(int take, int skip, object obj)
        {
            throw new NotImplementedException();
        }

        public object Insert(object obj)
        {
            throw new NotImplementedException();
        }

        public object Update(object obj)
        {
            throw new NotImplementedException();
        }

        public object Delete(object obj)
        {
            throw new NotImplementedException();
        }
    }
}