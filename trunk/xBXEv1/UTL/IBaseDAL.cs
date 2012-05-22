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
        DataTable Select(Guid id, bool isFkey = false);
        DataTable Select(object obj);
        DataTable Select(int skip, int take);
        DataTable Select(int skip, int take, object obj);
        object Insert(object obj);
        object Update(Guid id);
        object Delete(Guid id);
    }
}