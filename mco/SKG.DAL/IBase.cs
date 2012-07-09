using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL
{
    using System.Data;

    public interface IBase
    {
        int Count();
        object Select(string code);
        DataTable Select(Guid fKey);
        DataTable Select(object obj = null, int skip = 0, int take = 0);
        object Insert(object obj);
        object Update(object obj);
        object Delete(Guid id = new Guid());
    }
}