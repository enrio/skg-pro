﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:33
 * Update: 12/06/2013 06:21
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

    /// <summary>
    /// Transport - Tra_Detail accessing
    /// </summary>
    public sealed class Tra_DetailBLL : DAL.Tra_DetailDAL
    {
        /// <summary>
        /// Revenue of vehicle fixed
        /// </summary>
        /// <param name="sum">Totals money</param>
        /// <param name="receipt">Range of receipt</param>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        /// <returns></returns>
        public DataTable GetRevenueFixed(out decimal sum, out string receipt, DateTime fr, DateTime to)
        {
            sum = 0;
            var tb = base.GetRevenueFixed(out receipt, fr, to);
            if (tb == null || tb.Rows.Count == 0) return tb;

            tb.Columns.Add("GSeats", typeof(decimal));
            tb.Columns.Add("GBeds", typeof(decimal));

            foreach (DataRow r in tb.Rows)
            {
                var arrears = r["Arrears"].ToInt32();
                var count = r["Count"].ToInt32();

                var aseats = r["ASeats"].ToInt32();
                var abeds = r["ABeds"].ToInt32();

                var seats = r["Seats"].ToInt32();
                var beds = r["Beds"].ToInt32();

                var Totals = r["Totals"].ToDecimal();
                sum += Totals;

                var a = count + arrears;
                var b = seats + beds + aseats + abeds;
                var c = b - a;

                r["Count"] = a;
                r["Load"] = b;
                r["Guest"] = c;

                r["Seats"] = seats + aseats;
                r["Beds"] = beds + abeds;

                r["GSeats"] = seats + aseats - a;
                r["GBeds"] = beds + abeds;

                r["Vat"] = Totals / 11;
                r["Sales"] = Totals * 10 / 11;
            }

            tb.AcceptChanges();
            return tb;
        }

        /// <summary>
        /// Audit day vehicle fixed
        /// </summary>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        /// <param name="hideActive">Hide vehicle active</param>
        /// <param name="infomation">Finish infomation</param>
        /// <returns></returns>
        public DataTable AuditDayFixed(DateTime fr, DateTime to, bool hideActive, out string infomation)
        {
            var format = "Ghi chú: Lượt xe: {0}, lượt khách: {1}, đậu đêm: {2}, doanh thu: {3}";
            var tb = base.AuditDayFixed(fr, to, hideActive);

            if (tb == null || tb.Rows.Count == 0)
            {
                infomation = String.Format(format, 0, 0, 0, 0);
                return tb;
            }

            foreach (DataRow r in tb.Rows)
            {
                var Weight = Text.ToInt32(r["Weight"] + "") - 1;
                var Th_Lxe = Text.ToInt32(r["Th_Lxe"] + "");
                var Tr_Lxe = Text.ToInt32(r["Tr_Lxe"] + "");

                r["Th_Hk"] = Weight * Th_Lxe;
                r["Tr_Hk"] = Weight * Tr_Lxe;
            }

            var a = Convert.ToInt32(tb.Compute("Sum(Th_Lxe)", ""));
            var b = Convert.ToInt32(tb.Compute("Sum(Tr_Lxe)", ""));
            var count = a + b;

            var c = Convert.ToInt32(tb.Compute("Sum(Th_Hk)", ""));
            var d = Convert.ToInt32(tb.Compute("Sum(Tr_Hk)", ""));
            var guest = c + d;

            var e = Convert.ToDecimal(tb.Compute("Sum(Th_Money)", ""));
            var f = Convert.ToDecimal(tb.Compute("Sum(Tr_Money)", ""));
            var money = e + f;

            var p = Convert.ToDecimal(tb.Compute("Sum(Th_Parked)", ""));
            infomation = String.Format(format, count.ToString("#,0"),
                guest.ToString("#,0"), p.ToString("#,0"), money.ToString("#,0"));

            tb.AcceptChanges();
            return tb;
        }

        /// <summary>
        /// Sumary sales day of vehicle by
        /// </summary>
        /// <param name="sum">Total money</param>
        /// <param name="by">Sumary by</param>
        /// <param name="dt">Date time</param>
        /// <returns></returns>
        public DataTable SumarySalesDay(out decimal sum, Summary by, DateTime dt)
        {
            sum = 0;
            dt = dt.Date;

            try
            {
                var to = dt.AddTicks(Global.CutsFr.Ticks);
                var fr = to.AddDays(-1).AddSeconds(1);
                var tb = base.SumarySales(by, fr, to);

                if (tb != null && tb.Rows.Count > 0)
                    sum = (decimal)tb.Compute("Sum(Money)", "");

                return tb;
            }
            catch { return null; }
        }

        /// <summary>
        /// Sumary sales month of vehicle by
        /// </summary>
        /// <param name="sum">Total money</param>
        /// <param name="by">Sumary by</param>
        /// <param name="dt">Date time</param>
        /// <returns></returns>
        public DataTable SumarySalesMonth(out decimal sum, Summary by, DateTime dt)
        {
            sum = 0;

            try
            {
                var a = dt.ToStartOfMonth().Date;
                var b = dt.ToEndOfMonth().Date;

                var to = b.AddTicks(Global.CutsFr.Ticks);
                var fr = a.AddDays(-1).AddSeconds(1);
                var tb = base.SumarySales(by, fr, to);

                if (tb != null && tb.Rows.Count > 0)
                    sum = (decimal)tb.Compute("Sum(Money)", "");

                return tb;
            }
            catch { return null; }
        }

        /// <summary>
        /// Sumary sales year of vehicle by
        /// </summary>
        /// <param name="sum">Total money</param>
        /// <param name="by">Sumary by</param>
        /// <param name="dt">Date time</param>
        /// <returns></returns>
        public DataTable SumarySalesYear(out decimal sum, Summary by, DateTime dt)
        {
            sum = 0;

            try
            {
                var a = dt.ToStartOfYear().Date;
                var b = dt.ToEndOfYear().Date;

                var to = b.AddTicks(Global.CutsFr.Ticks);
                var fr = a.AddDays(-1).AddSeconds(1);
                var tb = base.SumarySales(by, fr, to);

                if (tb != null && tb.Rows.Count > 0)
                    sum = (decimal)tb.Compute("Sum(Money)", "");

                return tb;
            }
            catch { return null; }
        }

        /// <summary>
        /// Sumary for sales DayInMonth or MonthInYear
        /// </summary>
        /// <param name="sum">Total money</param>
        /// <param name="by">Kind of summary</param>
        /// <param name="dt">DateTime</param>
        /// <returns></returns>
        public DataSet Sumary4Sales(out decimal sum, Summary by, DateTime dt)
        {
            sum = 0;
            var ds = new DataSet();

            try
            {
                switch (by)
                {
                    case Summary.DayInMonth:
                        var a = dt.ToStartOfMonth().Date;
                        var b = dt.ToEndOfMonth().Date;

                        var to = b.AddTicks(Global.CutsFr.Ticks);
                        var fr = a.AddDays(-1).AddSeconds(1);
                        ds = base.Sumary4Sales(by, fr, to);
                        break;

                    case Summary.MonthInYear:
                        a = dt.ToStartOfYear().Date;
                        b = dt.ToEndOfYear().Date;

                        to = b.AddTicks(Global.CutsFr.Ticks);
                        fr = a.AddDays(-1).AddSeconds(1);
                        ds = base.Sumary4Sales(by, fr, to);
                        break;

                    default:
                        break;
                }

                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    sum = (decimal)ds.Tables[0].Compute("Sum(Money)", "");

                if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                    sum += (decimal)ds.Tables[1].Compute("Sum(Money)", "");

                var tb = ds.Tables[0];
                if (tb.Rows.Count > 2)
                {
                    var xx = tb.Rows[0]["Money"].ToDecimal();
                    xx += tb.Rows[1]["Money"].ToDecimal();
                    tb.Rows[1]["Money"] = xx;

                    tb.Rows[0].Delete();
                    tb.AcceptChanges();
                }

                tb = ds.Tables[1];
                if (tb.Rows.Count > 2)
                {
                    var xx = tb.Rows[0]["Money"].ToDecimal();
                    xx += tb.Rows[1]["Money"].ToDecimal();
                    tb.Rows[1]["Money"] = xx;

                    tb.Rows[0].Delete();
                    tb.AcceptChanges();
                }

                return ds;
            }
            catch { return null; }
        }
    }
}