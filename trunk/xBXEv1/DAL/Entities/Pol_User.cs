using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    /// <summary>
    /// Chính sách - Thông tin người dùng hệ thống
    /// </summary>
    public class Pol_User : ZInfor
    {
        /// <summary>
        /// Tên tài khoản đăng nhập hệ thống
        /// </summary>
        public string Acc { set; get; }

        /// <summary>
        /// Mật khẩu đăng nhập
        /// </summary>
        public string Pass { set; get; }

        /// <summary>
        /// Họ tên của người dùng
        /// </summary>
        public string Name { set; get; }

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
        /// Danh sách người dùng có các quyền (chức năng)
        /// </summary>
        public virtual ICollection<Pol_UserRight> Pol_UserRights { get; set; }

        /// <summary>
        /// Danh sách người dùng thuộc nhóm quyền (chức năng)
        /// </summary>
        public virtual ICollection<Pol_UserRole> Pol_UserRoles { get; set; }
        #endregion
    }
}