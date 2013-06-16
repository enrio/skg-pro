#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 16/06/2013 08:32
 * Status: OK
 */
#endregion

using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;

namespace SKG.Reader
{
    /// <summary>
    /// Reader processing
    /// </summary>
    public abstract class BaseReader
    {
        protected const string STR_2K7 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";";
        protected const string STR_2K3 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";
        protected const string STR_SEC = "Data Source={0};Initial Catalog={1};User Id={2};Password={3};";
        protected const string STR_TRU = "Data Source={0};Initial Catalog={1};Integrated Security=SSPI;";

        protected string Err;

        public BaseReader()
        {
            Err = null;
        }

        #region abstract method
        /// <summary>
        /// Get all tables/worksheet
        /// </summary>
        /// <param name="name">excel file name</param>
        /// <returns></returns>
        public abstract List<string> GetTable(string name = null);

        /// <summary>
        /// Get all columns
        /// </summary>
        /// <param name="name">table/worksheet name</param>
        /// <returns>data in columns</returns>
        public abstract DataTable GetColumn(string name);

        /// <summary>
        /// Get all data
        /// </summary>
        /// <param name="name">table/worksheet name</param>
        /// <returns>data in table/worksheet</returns>
        public abstract DataTable GetData(string name);

        /// <summary>
        /// Insert data
        /// </summary>
        /// <param name="table">data need to insert</param>
        /// <param name="name">table/worksheet name</param>
        /// <returns></returns>
        public abstract int InsertData(DataTable table, string name);

        /// <summary>
        /// Close connection
        /// </summary>
        public abstract void Close();
        #endregion
    }
}