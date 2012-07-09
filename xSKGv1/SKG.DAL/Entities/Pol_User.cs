using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    /// <summary>
    /// Chính sách - Thông tin người dùng của hệ thống
    /// </summary>
    public class Pol_User : ZBase
    {
        /// <summary>
        /// Tên tài khoản đăng nhập
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
        /// Ngày tháng năm sinh của người dùng
        /// </summary>
        public DateTime Birth { set; get; }

        /// <summary>
        /// Địa chỉ liên lạc của người dùng
        /// </summary>
        public string Address { set; get; }

        /// <summary>
        /// Điện thoại liên lạc của người dùng
        /// </summary>
        public string Phone { set; get; }

        #region Khoá ngoại ở các thực thể khác
        /// <summary>
        /// Danh sách người dùng có quyền trên form, menu (chức năng) của hệ thống
        /// </summary>
        public virtual ICollection<Pol_UserRight> Pol_UserRights { get; set; }

        /// <summary>
        /// Danh sách người dùng thuộc nhóm người dùng của hệ thống
        /// </summary>
        public virtual ICollection<Pol_UserRole> Pol_UserRoles { get; set; }
        #endregion
    }
}