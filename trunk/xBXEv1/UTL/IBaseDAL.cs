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
        object Select(string code);
        DataTable Select(object obj = null, int skip = 0, int take = 0);
        object Insert(object obj);
        object Update(object obj);
        object Delete(Guid id = new Guid());
    }
}