#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 09/08/2013 20:32
 * Update: 12/06/2013 12:32
 * Status: OK
 */
#endregion

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace SKG.DAL
{
    /// <summary>
    /// All of standard methods for DAL
    /// </summary>
    public interface IBase
    {
        /// <summary>
        /// Auto generate code
        /// </summary>
        /// <param name="format">Format code</param>
        /// <returns></returns>
        string GenerateCode(string format);

        /// <summary>
        /// Count number of records
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// Select object of entity by primary key handmade
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