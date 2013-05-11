using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.BLL
{
    using SKG.Extend;
    using System.Data;
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
                r["Price"] = Text.ToDecimal(r["Text"] + "");

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
                r["Price"] = Text.ToDecimal(r["Text"] + "");

            return tb;
        }
    }
}