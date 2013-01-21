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
        public new DataTable GetRevenueFixed(out decimal sum, out string receipt, DateTime fr, DateTime to)
        {
            var tb = base.GetRevenueFixed(out sum, out receipt, fr, to);
            foreach (DataRow r in tb.Rows)
            {
                var Arrears = Text.ToInt32(r["Arrears"] + "");
                var Count = Text.ToInt32(r["Count"] + "");
                var Seats = Text.ToInt32(r["Seats"] + "");
                var Beds = Text.ToInt32(r["Beds"] + "");
                var ASB = Text.ToInt32(r["ASB"] + "");
                var Totals = Text.ToDecimal(r["Totals"] + "");

                var a = Count + Arrears;
                var b = Seats + Beds + ASB;

                r["Count"] = a;
                r["Seats"] = b;
                r["Beds"] = b - a;

                r["Vat"] = Totals / 11;
                r["Sales"] = Totals * 10 / 11;
            }
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
            catch
            {
                return null;
            }
        }
    }
}