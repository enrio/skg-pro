using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    using System.Data;

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
        public static DataTable ToDataTable<T>(this IEnumerable<T> data, bool numbered = true, string tableName = "Tmp")
        {
            var res = UTL.BaseUTL.Linq2Table((IEnumerable<T>)data, tableName);
            res.Numbered(numbered);
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