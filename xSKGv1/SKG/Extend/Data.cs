#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 16/06/2013 08:45
 * Status: OK
 */
#endregion

using System;
using System.Linq;
using System.Data;
using System.Reflection;
using System.Collections.Generic;

namespace SKG.Extend
{
    /// <summary>
    /// Data processing
    /// </summary>
    public static class Data
    {
        /// <summary>
        /// Convert from IEnumerable (LINQ object) to DataTable
        /// </summary>
        /// <typeparam name="T">Type of data</typeparam>
        /// <param name="l">Data</param>
        /// <param name="s">Table name</param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> l, string s = "Tmp")
        {
            try
            {
                var tb = new DataTable(s);
                PropertyInfo[] pro = null;
                if (l == null) return tb;

                foreach (T rec in l)
                {
                    if (pro == null)
                    {
                        pro = ((Type)rec.GetType()).GetProperties();
                        foreach (var pi in pro)
                        {
                            Type colType = pi.PropertyType;
                            if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                                colType = colType.GetGenericArguments()[0];
                            tb.Columns.Add(new DataColumn(pi.Name, colType));
                        }
                    }

                    DataRow dr = tb.NewRow();
                    foreach (var pi in pro) dr[pi.Name] = pi.GetValue(rec, null) ?? DBNull.Value;
                    tb.Rows.Add(dr);
                }

                tb.AcceptChanges();
                return tb;
            }
            catch { return null; }
        }

        /// <summary>
        /// Make numbered
        /// </summary>
        /// <param name="t">Data</param>
        /// <param name="n">Numbered</param>
        public static void Numbered(this DataTable t, bool n = true)
        {
            if (t == null) return;

            if (n)
            {
                t.Columns.Add("No_");
                for (int i = 0; i < t.Rows.Count; i++)
                    t.Rows[i].SetField("No_", i + 1); // numbered
                t.AcceptChanges();
            }
        }
    }
}