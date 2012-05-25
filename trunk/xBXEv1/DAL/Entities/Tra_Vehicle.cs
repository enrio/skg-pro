using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Vận tải - Danh sách xe
    /// </summary>
    public class Tra_Vehicle : ZInfor
    {
        #region Khoá ngoại
        /// <summary>
        /// Khoá ngoại tham chiếu tới Tra_Kind
        /// </summary>
        [ForeignKey("Tra_Kind")]
        public Guid? Tra_KindId { set; get; }
        public virtual Tra_Kind Tra_Kind { get; set; }
        #endregion

        /// <summary>
        /// Biển số xe
        /// </summary>
        public string Number { set; get; }

        /// <summary>
        /// Họ tên tài xế
        /// </summary>
        public string Driver { set; get; }

        /// <summary>
        /// Ngày tháng năm sinh
        /// </summary>
        public DateTime Birth { set; get; }

        /// <summary>
        /// Địa chỉ liên lạc
        /// </summary>
        public string Address { set; get; }

        /// <summary>
        /// Điện thoại liên lạc
        /// </summary>
        public string Phone { set; get; }

        #region Khoá ngoại ở các thực thể khác
        /// <summary>
        /// Chi tiết xe ra, vào bến
        /// </summary>
        public virtual ICollection<Tra_Detail> Tra_Details { get; set; }
        #endregion
    }
}