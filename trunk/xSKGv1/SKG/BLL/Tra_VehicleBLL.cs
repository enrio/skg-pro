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
        public new DataTable SelectForFixedPrint()
        {
            var tb = base.SelectForFixedPrint();
            tb.Columns.Add("Price", typeof(decimal));

            foreach (DataRow r in tb.Rows)
            {
                var Seats = Text.ToInt32(r["Seats"] + "");
                var Beds = Text.ToInt32(r["Beds"] + "");
                var Price1 = Text.ToInt32(r["Price1"] + "");
                var Price2 = Text.ToInt32(r["Price2"] + "");
                var Rose1 = Text.ToInt32(r["Rose1"] + "");
                var Rose2 = Text.ToInt32(r["Rose2"] + "");

                var Cost = Price1 * Seats + Price2 * Beds;
                var Rose = Rose1 * (Seats < 1 ? 1 : Seats - 1) + Rose2 * Beds;

                r["Price"] = Cost + Rose;
            }
            return tb;
        }
    }
}