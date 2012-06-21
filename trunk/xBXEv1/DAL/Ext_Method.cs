using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    using System.Data;
    using UTL;
    using SKG.UTL;

    /// <summary>
    /// Extend methods
    /// </summary>
    public static class Ext_Method
    {
        /// <summary>
        /// Convert from IEnumerable (LINQ object) to DataTable
        /// </summary>
        /// <typeparam name="T">Type of data need to convert</typeparam>
        /// <param name="data">Data need to convert</param>
        /// <param name="numbered">Numbered if true else not numbered</param>
        /// <param name="tableName">Table name</param>
        /// <returns>Data</returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> data, string tableName = "Tmp", bool numbered = true)
        {
            var res = BaseUTL.Linq2Table((IEnumerable<T>)data, tableName);
            if (res.Rows.Count > 0) res.Numbered(numbered);
            else res = null;
            return res;
        }

        /// <summary>
        /// Numbered
        /// </summary>
        /// <param name="dtb">DataTable</param>
        /// <param name="numbered">Numbered if true else not numbered</param>
        public static void Numbered(this DataTable dtb, bool numbered = true)
        {
            if (numbered)
            {
                dtb.Columns.Add("No_");
                for (int i = 0; i < dtb.Rows.Count; i++)
                    dtb.Rows[i].SetField("No_", i + 1); // numbered
            }

            dtb.AcceptChanges();
        }
    }
}