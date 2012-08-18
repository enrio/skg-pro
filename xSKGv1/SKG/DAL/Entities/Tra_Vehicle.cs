using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Vận tải - Danh sách xe
    /// </summary>
    public class Tra_Vehicle : Zinfors
    {
        #region Khoá ngoại
        /// <summary>
        /// Khoá ngoại tham chiếu tới Pol_Dictionary (đơn vị vận tải)
        /// </summary>
        [ForeignKey("Transport")]
        public Guid? TransportId { set; get; }

        /// <summary>
        /// Thuộc đơn vị vận tải
        /// </summary>
        public virtual Pol_Dictionary Transport { get; set; }
        #endregion

        #region Tải trọng
        /// <summary>
        /// Số ghế ngồi
        /// </summary>
        public int? Seats { set; get; }

        /// <summary>
        /// Số giường nằm
        /// </summary>
        public int? Beds { set; get; }
        #endregion

        #region Thông tin quản lý
        /// <summary>
        /// Năm sản xuất
        /// </summary>
        public int? ProductionYear { set; get; }

        /// <summary>
        /// Hạn đăng kiểm
        /// </summary>
        public DateTime? LimitedRegistration { set; get; }

        /// <summary>
        /// Hạn bảo hiểm
        /// </summary>
        public DateTime? TermInsurance { set; get; }

        /// <summary>
        /// Hạn tuyến cố định
        /// </summary>
        public DateTime? TermFixedRoutes { set; get; }

        /// <summary>
        /// Hạn giấy phép lái xe
        /// </summary>
        public DateTime? TermDriverLicense { set; get; }
        #endregion

        #region Thông tin xe
        /// <summary>
        /// Xe chất lượng cao
        /// </summary>
        public bool High { set; get; }

        /// <summary>
        /// Xe thành phố
        /// </summary>
        public bool City { set; get; }

        /// <summary>
        /// Tuyến cố định
        /// </summary>
        public bool Fixed { set; get; }
        #endregion

        #region Thông tin khác
        /// <summary>
        /// Chất lượng phục vụ
        /// </summary>
        public string ServerQuality { set; get; }

        /// <summary>
        /// Họ tên của tài xế
        /// </summary>
        public string Driver { set; get; }

        /// <summary>
        /// Ngày tháng năm sinh của tài xế
        /// </summary>
        public DateTime? Birth { set; get; }

        /// <summary>
        /// Địa chỉ liên lạc của tài xế
        /// </summary>
        public string Address { set; get; }

        /// <summary>
        /// Điện thoại liên lạc của tài xế
        /// </summary>
        public string Phone { set; get; }
        #endregion

        #region Khoá ngoại ở các thực thể khác
        /// <summary>
        /// Chi tiết xe ra, vào bến
        /// </summary>
        public virtual ICollection<Tra_Detail> Tra_Details { get; set; }
        #endregion
    }
}