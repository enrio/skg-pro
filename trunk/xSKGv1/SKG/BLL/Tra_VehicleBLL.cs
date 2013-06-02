#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:33
 * Update: 02/06/2013 22:02
 * Status: OK
 */
#endregion

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace SKG.BLL
{
    using SKG.Extend;

    using DAL.Entities;

    /// <summary>
    /// Truy cập cơ sở dữ liệu bảng Tra_Vehicle: danh sách xe cộ.
    /// </summary>
    public sealed class Tra_VehicleBLL : DAL.Tra_VehicleDAL
    {
        /// <summary>
        /// Kiểm tra biển số xe
        /// </summary>
        /// <param name="number">Biển số</param>
        /// <returns>Id xe</returns>
        public Guid CheckExist(string number)
        {
            try
            {
                var res = Select(number);
                return res == null ? new Guid() : ((Tra_Vehicle)res).Id;
            }
            catch { return new Guid(); }
        }

        /// <summary>
        /// In danh sách xe tuyến cố định
        /// </summary>
        /// <returns></returns>
        public new DataTable SelectForPrint()
        {
            var tb = base.SelectForPrint();
            if (tb == null || tb.Rows.Count == 0) return tb;
            tb.Columns.Add("Price", typeof(decimal));

            foreach (DataRow r in tb.Rows)
                r["Price"] = r["Text"].ToDecimal();

            tb.AcceptChanges();
            return tb;
        }

        /// <summary>
        /// Danh sách xe tuyến cố định
        /// </summary>
        /// <returns></returns>
        public new DataTable SelectForFixed()
        {
            var tb = base.SelectForFixed();
            if (tb == null || tb.Rows.Count == 0) return tb;
            tb.Columns.Add("Price", typeof(decimal));

            foreach (DataRow r in tb.Rows)
                r["Price"] = r["Text"].ToDecimal();

            tb.AcceptChanges();
            return tb;
        }
    }
}