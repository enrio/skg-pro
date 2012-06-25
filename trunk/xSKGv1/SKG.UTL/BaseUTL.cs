using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.UTL
{
    using System.Data;
    using System.Reflection;

    /// <summary>
    /// Tiện ích hỗ trợ cơ bản
    /// </summary>
    public class BaseUTL
    {
        /// <summary>
        /// Chuyển từ IEnumerable (LINQ) sang DataTable
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu LINQ</typeparam>
        /// <param name="list">Dữ liệu LINQ cần chuyển</param>
        /// <param name="tableName">Tên bảng</param>
        /// <returns>Dữ liệu</returns>
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