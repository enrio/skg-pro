﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Chính sách - Danh sách tên các quyền (chức năng) của hệ thống
    /// </summary>
    public class Pol_Right : ZInfor
    {
        /// <summary>
        /// Tên các quyền (chức năng)
        /// </summary>
        public string Name { set; get; }

        #region Khoá ngoại ở các thực thể khác
        /// <summary>
        /// Danh sách nhóm quyền có các chức năng
        /// </summary>
        public virtual ICollection<Pol_RoleRight> Pol_RoleRights { get; set; }

        /// <summary>
        /// Danh sách nhóm người dùng có các chức năng
        /// </summary>
        public virtual ICollection<Pol_UserRight> Pol_UserRights { get; set; }
        #endregion
    }
}