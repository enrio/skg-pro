using System;
using System.Collections.Generic;
using System.Linq;

namespace UTL
{
    using System.Data;
    using System.Reflection;

    /// <summary>
    /// Base class utility
    /// </summary>
    public class BaseUTL
    {
        /// <summary>
        /// Convert from IEnumerable (LINQ object) to DataTable
        /// </summary>
        /// <typeparam name="T">Type of data need to convert</typeparam>
        /// <param name="list">Data need to convert</param>
        /// <param name="tableName">Table name</param>
        /// <returns>Data</returns>
        public static DataTable Linq2Table<T>(IEnumerable<T> list, string tableName)
        {
            try
            {
                var tb = new DataTable(tableName);
                PropertyInfo[] pro = null;
                if (list == null) return tb;

                foreach (T rec in list)
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
                return tb;
            }
            catch { return null; }
        }
    }
}