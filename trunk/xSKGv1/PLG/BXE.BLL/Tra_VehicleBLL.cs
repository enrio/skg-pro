using System;
using System.Collections.Generic;
using System.Linq;

namespace BXE.BLL
{
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
    }
}