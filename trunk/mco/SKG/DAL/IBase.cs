#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:33
 * Update: 24/07/2012 22:14
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

        /// <summary>
        /// Select object of entity by secondary primary key (when need to)
        /// </summary>
        /// <param name="code">Primary key (when need to)</param>
        /// <returns></returns>
        object Select(string code);

        /// <summary>
        /// Return data by foreign key
        /// </summary>
        /// <param name="fKey">Foreign key on this table</param>
        /// <returns></returns>
        DataTable Select(Guid fKey);

        /// <summary>
        /// Return data
        /// </summary>
        /// <param name="obj">Object of entity</param>
        /// <param name="skip">Skip number of records</param>
        /// <param name="take">Take number of records</param>
        /// <returns></returns>
        DataTable Select(object obj = null, int skip = 0, int take = 0);

        /// <summary>
        /// Insert data
        /// </summary>
        /// <param name="obj">Object of entity</param>
        /// <returns></returns>
        object Insert(object obj);

        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="obj">Object of entity</param>
        /// <returns></returns>
        object Update(object obj);

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns></returns>
        object Delete(Guid id = new Guid());
    }
}