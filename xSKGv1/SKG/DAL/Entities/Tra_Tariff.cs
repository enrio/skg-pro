using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Vận tải - Bảng giá theo loại xe của xe vãng lai; miền, hoa hồng của xe cố định
    /// </summary>
    public class Tra_Tariff : Zinfors
    {
        #region Khoá ngoại
        /// <summary>
        /// Thuộc nhóm (khoá ngoại tham chiếu tới Pol_Dictionary)
        /// </summary>
        [ForeignKey("Group")]
        public Guid? GroupId { set; get; }

        /// <summary>
        /// Thuộc nhóm (miền)
        /// </summary>
        public virtual Pol_Dictionary Group { get; set; }
        #endregion

        /// <summary>
        /// Hoa hồng vé của xe cố định
        /// </summary>
        public bool Commission { set; get; }

        /// <summary>
        /// Đơn giá nửa ngày (ghế), hoa hồng ghế
        /// </summary>
        public int Price1 { set; get; }

        /// <summary>
        /// Đơn giá một ngày (giường), hoa hồng giường
        /// </summary>
        public int Price2 { set; get; }
    }
}