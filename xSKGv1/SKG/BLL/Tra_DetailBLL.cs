using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.BLL
{
    using SKG.Extend;
    using System.Data;

    /// <summary>
    /// Truy cập cơ sở dữ liệu bảng Tra_Detail: chi tiết xe ra vào, bến.
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

            foreach (DataRow r in tb.Rows)
            {
                var Arrears = Text.ToInt32(r["Arrears"] + "");
                var Count = Text.ToInt32(r["Count"] + "");
                var Seats = Text.ToInt32(r["Seats"] + "");
                var Beds = Text.ToInt32(r["Beds"] + "");
                var ASB = Text.ToInt32(r["ASB"] + "");

                var Totals = Text.ToDecimal(r["Totals"] + "");
                sum += Totals;

                var a = Count + Arrears;
                var b = Seats + Beds + ASB;

                r["Count"] = a;
                r["Seats"] = b;
                r["Beds"] = b - a;

                r["Totals"] = Totals;
                r["Vat"] = Totals / 11;
                r["Sales"] = Totals * 10 / 11;
            }
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
            infomation = String.Format(format, count.ToString("#,0"), guest.ToString("#,0"), p.ToString("#,0"), money.ToString("#,0"));
            return tb;
        }

        /// <summary>
        /// Revenue of vehicle fixed from 13:00:01 yesterday ago to 13:00:00 today
        /// </summary>
        /// <param name="sum">Sum of money</param>
        /// <returns></returns>
        public DataTable GetRevenueToday(out decimal sum, out string receipt)
        {
            sum = 0;
            receipt = "";
            try
            {
                var to = Global.Session.Current.Date.AddHours(13);
                var fr = to.AddDays(-1).AddSeconds(1);
                return GetRevenueFixed(out sum, out receipt, fr, to);
            }
            catch { return null; }
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
            try
            {
                var to = dt.AddHours(13);
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
                var a = dt.ToStartOfMonth();
                var b = dt.ToEndOfMonth();

                var to = b.AddHours(13);
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
                var a = dt.ToStartOfYear();
                var b = dt.ToEndOfYear();

                var to = b.AddHours(13);
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
        /// <param name="sum"></param>
        /// <param name="by"></param>
        /// <param name="dt"></param>
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
                        var a = dt.ToStartOfMonth();
                        var b = dt.ToEndOfMonth();
                        var to = b.AddHours(13);
                        var fr = a.AddDays(-1).AddSeconds(1);
                        ds = base.Sumary4Sales(by, fr, to);
                        break;

                    case Summary.MonthInYear:
                        a = dt.ToStartOfYear();
                        b = dt.ToEndOfYear();
                        to = b.AddHours(13);
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

                return ds;
            }
            catch { return null; }
        }
    }
}