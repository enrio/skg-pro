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

        #region Price
        /// <summary>
        /// Price of a seat or a half day
        /// </summary>
        public int Price1 { set; get; }

        /// <summary>
        /// Price of a bed or a full day
        /// </summary>
        public int Price2 { set; get; }
        #endregion

        #region Commission
        /// <summary>
        /// Commission of a seat
        /// </summary>
        public int Rose1 { set; get; }

        /// <summary>
        /// Commission of a bed
        /// </summary>
        public int Rose2 { set; get; }
        #endregion
    }
}