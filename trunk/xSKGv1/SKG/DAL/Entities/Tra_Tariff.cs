﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    using SKG.DAL.Entities;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Vận tải - Loại xe
    /// </summary>
    public class Tra_Tariff : Zinfors
    {
        #region Khoá ngoại
        /// <summary>
        /// Khoá ngoại tham chiếu tới Tra_Group
        /// </summary>
        [ForeignKey("Group")]
        public Guid? GroupId { set; get; }
        public virtual Pol_Dictionary Group { get; set; }
        #endregion

        /// <summary>
        /// Đơn giá nửa ngày
        /// </summary>
        public int Price1 { set; get; }

        /// <summary>
        /// Đơn giá một ngày
        /// </summary>
        public int Price2 { set; get; }
    }
}