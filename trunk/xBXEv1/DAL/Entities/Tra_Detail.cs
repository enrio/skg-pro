﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Vận tải - Chi tiết xe ra vào bến
    /// </summary>
    public class Tra_Detail : ZInfor
    {
        #region Khoá ngoại
        /// <summary>
        /// Khoá ngoại tham chiếu tới Tra_Vehicle
        /// </summary>
        [Column(Order = 0), ForeignKey("Tra_Vehicle")]
        public Guid? Tra_VehicleId { set; get; }
        public virtual Tra_Vehicle Tra_Vehicle { get; set; }

        /// <summary>
        /// Khoá ngoại tham chiếu tới Pol_User
        /// </summary>
        [Column(Order = 1), ForeignKey("Pol_UserIn")]
        public Guid? Pol_UserInId { set; get; }
        public virtual Pol_User Pol_UserIn { get; set; }

        /// <summary>
        /// Khoá ngoại tham chiếu tới Pol_User
        /// </summary>
        [Column(Order = 2), ForeignKey("Pol_UserOut")]
        public Guid? Pol_UserOutId { set; get; }
        public virtual Pol_User Pol_UserOut { get; set; }
        #endregion

        /// <summary>
        /// Thời gian cho xe vào bến
        /// </summary>
        public DateTime DateIn { set; get; }

        /// <summary>
        /// Thời gian cho xe ra bến
        /// </summary>
        public DateTime DateOut { set; get; }
    }
}