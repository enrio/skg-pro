﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:33
 * Update: 12/06/2013 06:24
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
    /// Transport - Tra_Vehicle accessing
    /// </summary>
    public sealed class Tra_VehicleBLL : DAL.Tra_VehicleDAL
    {
        /// <summary>
        /// Check exist number
        /// </summary>
        /// <param name="num">Number</param>
        /// <returns></returns>
        public Guid CheckExist(string num)
        {
            try
            {
                var res = Select(num);
                return res == null ? new Guid() : ((Tra_Vehicle)res).Id;
            }
            catch { return new Guid(); }
        }

        /// <summary>
        /// Print list vehicle fixed
        /// </summary>
        /// <param name="t">Filter</param>
        /// <returns></returns>
        public new DataTable SelectForPrint(TermForFixed t)
        {
            var tb = base.SelectForPrint(t);
            return Xuli(tb);
        }

        /// <summary>
        /// List vehicle fixed
        /// </summary>
        /// <param name="t">Filter</param>
        /// <returns></returns>
        public new DataTable SelectForFixed(TermForFixed t)
        {
            var tb = base.SelectForFixed(t);
            return Xuli(tb);
        }

        /// <summary>
        /// Thêm cột Price và Ghichu
        /// </summary>
        /// <param name="tb">Dữ liệu</param>
        /// <returns></returns>
        DataTable Xuli(DataTable tb)
        {
            if (tb == null || tb.Rows.Count == 0) return tb;
            tb.Columns.Add("Price", typeof(decimal));
            tb.Columns.Add("Ghichu", typeof(string));

            foreach (DataRow r in tb.Rows)
            {
                var text = r["Text"] + "";
                var x = text.Split(new string[] { ";!;" }, StringSplitOptions.None);

                if (x.Length > 0) r["Price"] = x[0].ToDecimal();
                if (x.Length > 1) r["Ghichu"] = x[1];
            }

            tb.AcceptChanges();
            return tb;
        }
    }
}