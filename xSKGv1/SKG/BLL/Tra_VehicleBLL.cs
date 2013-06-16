#region Information
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
        /// <returns></returns>
        public new DataTable SelectForPrint()
        {
            var tb = base.SelectForPrint();
            if (tb == null || tb.Rows.Count == 0)
                return tb;

            tb.Columns.Add("Price", typeof(decimal));
            foreach (DataRow r in tb.Rows)
                r["Price"] = r["Text"].ToDecimal();
            tb.AcceptChanges();

            return tb;
        }

        /// <summary>
        /// List vehicle fixed
        /// </summary>
        /// <returns></returns>
        public new DataTable SelectForFixed()
        {
            var tb = base.SelectForFixed();
            if (tb == null || tb.Rows.Count == 0)
                return tb;

            tb.Columns.Add("Price", typeof(decimal));
            foreach (DataRow r in tb.Rows)
                r["Price"] = r["Text"].ToDecimal();
            tb.AcceptChanges();

            return tb;
        }
    }
}