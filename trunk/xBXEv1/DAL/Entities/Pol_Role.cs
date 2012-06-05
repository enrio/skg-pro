using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    /// <summary>
    /// Chính sách - Danh sách tên các nhóm quyền (chức năng) của hệ thống
    /// </summary>
    public class Pol_Role : ZInfor
    {
        /// <summary>
        /// Tên các nhóm quyền (chức năng)
        /// </summary>
        public string Name { set; get; }

        #region Khoá ngoại ở các thực thể khác
        /// <summary>
        /// Danh sách người dùng thuộc nhóm quyền của hệ thống
        /// </summary>
        public virtual ICollection<Pol_UserRole> Pol_UserRoles { get; set; }

        /// <summary>
        /// Danh sách nhóm người dùng có các quyền của hệ thống
        /// </summary>
        public virtual ICollection<Pol_RoleRight> Pol_RoleRights { get; set; }
        #endregion
    }
}