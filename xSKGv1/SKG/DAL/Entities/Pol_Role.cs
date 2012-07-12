using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    /// <summary>
    /// Chính sách - Danh sách tên các nhóm người dùng của hệ thống
    /// </summary>
    public class Pol_Role : ZBase
    {
        /// <summary>
        /// Tên nhóm người dùng
        /// </summary>
        public string Name { set; get; }

        #region Khoá ngoại ở các thực thể khác
        /// <summary>
        /// Danh sách người dùng thuộc nhóm người dùng của hệ thống
        /// </summary>
        public virtual ICollection<Pol_UserRole> Pol_UserRoles { get; set; }

        /// <summary>
        /// Danh sách nhóm người dùng có quyền trên form, menu (chức năng) của hệ thống
        /// </summary>
        public virtual ICollection<Pol_RoleRight> Pol_RoleRights { get; set; }
        #endregion
    }
}