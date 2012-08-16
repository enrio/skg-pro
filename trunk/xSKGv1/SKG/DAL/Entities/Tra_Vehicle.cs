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
        /// Khoá ngoại tham chiếu tới Pol_Dictionary
        /// </summary>
        [ForeignKey("Transport")]
        public Guid? TransportId { set; get; }
        public virtual Pol_Dictionary Transport { get; set; }
        #endregion

        /// <summary>
        /// Biển số xe
        /// </summary>
        public string Number { set; get; }

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
        /// Hạn đăng kiểm
        /// </summary>
        public string LimitedRegistration { set; get; }

        /// <summary>
        /// Năm sản xuất
        /// </summary>
        public string ProductionYear { set; get; }

        /// <summary>
        /// Hạn bảo hiểm
        /// </summary>
        public string TermInsurance { set; get; }

        /// <summary>
        /// Hạn tuyến cố định
        /// </summary>
        public string TermFixedRoutes { set; get; }

        /// <summary>
        /// Hạn giấy phép lái xe
        /// </summary>
        public string TermDriverLicense { set; get; }
        #endregion

        #region Thông tin xe
        /// <summary>
        /// Xe thường
        /// </summary>
        public bool Normal { set; get; }

        /// <summary>
        /// Xe chất lượng cao
        /// </summary>
        public bool High { set; get; }

        /// <summary>
        /// Xe thành phố
        /// </summary>
        public bool City { set; get; }

        /// <summary>
        /// Xe địa phương
        /// </summary>
        public bool Local { set; get; }

        #endregion
        #region Thông tin khác
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