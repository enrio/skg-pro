using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL
{
    using SKG.UTL;
    using System.Data;

    /// <summary>
    /// Các phương thức mở rộng
    /// </summary>
    public static class Ext_Method
    {
        /// <summary>
        /// Chuyển từ IEnumerable (LINQ) sang DataTable
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu LINQ</typeparam>
        /// <param name="data">Dữ liệu LINQ cần chuyển</param>
        /// <param name="numbered">Đánh số thứ tự</param>
        /// <param name="tableName">Tên bảng</param>
        /// <returns>Dữ liệu</returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> data, bool numbered = true, string tableName = "Tmp")
        {
            var res = BaseUTL.Linq2Table((IEnumerable<T>)data, tableName);
            res.Numbered(numbered);
            return res;
        }

        /// <summary>
        /// Đánh số thứ tự
        /// </summary>
        /// <param name="dtb">DataTable</param>
        /// <param name="numbered">Đánh số</param>
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