using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    using System.Data;

    /// <summary>
    /// Base interface to DAL
    /// </summary>
    public interface IBase
    {
        /// <summary>
        /// Count all of records
        /// </summary>
        /// <returns>Number of records</returns>
        int Count();

        /// <summary>
        /// Select all data from table in database
        /// </summary>
        /// <returns>Data</returns>
        DataTable Select();

        /// <summary>
        /// Select data by object from table in database
        /// </summary>
        /// <param name="obj">Condition</param>
        /// <returns>Data</returns>
        DataTable Select(object obj);

        /// <summary>
        /// Insert object to table in database
        /// </summary>
        /// <param name="obj">Object need to insert</param>
        /// <returns>Enum's perform status of DAL</returns>
        BaseDAL.State Insert(object obj);

        /// <summary>
        /// Update object to table in database
        /// </summary>
        /// <param name="obj">Object need to update</param>
        /// <returns>Enum's perform status of DAL</returns>
        BaseDAL.State Update(object obj);

        /// <summary>
        /// Delete object to table in database
        /// </summary>
        /// <param name="obj">Object need to delete</param>
        /// <returns>Enum's perform status of DAL</returns>
        BaseDAL.State Delete(object obj);
    }
}