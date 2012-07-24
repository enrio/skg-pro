#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:33
 * Update: 24/07/2012 22:04
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL
{
    using System.Data;

    /// <summary>
    /// All of standard methods for DAL
    /// </summary>
    public interface IBase
    {
        /// <summary>
        /// Count number of records
        /// </summary>
        /// <returns></returns>
        int Count();
        object Select(string code);
        DataTable Select(Guid fKey);
        DataTable Select(object obj = null, int skip = 0, int take = 0);
        object Insert(object obj);
        object Update(object obj);
        object Delete(Guid id = new Guid());
    }
}