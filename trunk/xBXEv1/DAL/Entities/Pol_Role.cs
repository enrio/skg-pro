﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Chính sách - Danh sách tên các nhóm quyền (chức năng) của hệ thống
    /// 
    /// Tác giả:    Nguyễn Văn Toàn - LT11780
    /// Điện thoại: 01645 515 010
    /// Hộp thư:    nvt87x@gmail.com
    /// </summary>
    public class Pol_Role : Info
    {
        /// <summary>
        /// Tên các nhóm quyền (chức năng)
        /// </summary>
        public string Name { set; get; }

        #region Khoá ngoại ở các thực thể khác
        /// <summary>
        /// Danh sách nhóm người dùng thuộc nhóm quyền (chức năng)
        /// </summary>
        public virtual ICollection<Pol_UserRole> Pol_UserRoles { get; set; }

        /// <summary>
        /// Danh sách nhóm quyền có các chức năng
        /// </summary>
        public virtual ICollection<Pol_RoleRight> Pol_RoleRights { get; set; }
        #endregion
    }
}