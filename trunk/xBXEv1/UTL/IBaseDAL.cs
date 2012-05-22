using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTL
{
    using System.Data;

    /// <summary>
    /// Base interface to Data Access Layer (DAL)
    /// </summary>
    public interface IBaseDAL
    {
        int Count();
        DataTable Select();
        DataTable Select(object obj);
        DataTable Select(int take, int skip);
        DataTable Select(int skip, int take, object obj);
        object Insert(object obj);
        object Update(object obj);
        object Delete(object obj);
    }
}