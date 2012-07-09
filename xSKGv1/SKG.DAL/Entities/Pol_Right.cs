using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    /// <summary>
    /// Chính sách - Danh sách tên các form, menu (chức năng) của hệ thống
    /// </summary>
    public class Pol_Right : Base
    {
        /// <summary>
        /// Tên form, menu
        /// </summary>
        public string Name { set; get; }

        #region Khoá ngoại ở các thực thể khác
        /// <summary>
        /// Danh sách nhóm người dùng có quyền trên form, menu (chức năng) của hệ thống
        /// </summary>
        public virtual ICollection<Pol_RoleRight> Pol_RoleRights { get; set; }

        /// <summary>
        /// Danh sách người dùng có quyền trên form, menu (chức năng) của hệ thống
        /// </summary>
        public virtual ICollection<Pol_UserRight> Pol_UserRights { get; set; }
        #endregion
    }
}