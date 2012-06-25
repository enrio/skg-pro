using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Chính sách - Danh sách nhóm người dùng có quyền trên form, menu (chức năng) của hệ thống
    /// </summary>
    public class Pol_RoleRight : SAction
    {
        #region Khoá ngoại
        /// <summary>
        /// Khoá ngoại tham chiếu tới Pol_Role
        /// </summary>
        [Column(Order = 0), ForeignKey("Pol_Role")]
        public Guid? Pol_RoleId { set; get; }
        public virtual Pol_Role Pol_Role { get; set; }

        /// <summary>
        /// Khoá ngoại tham chiếu tới Pol_Right
        /// </summary>
        [Column(Order = 1), ForeignKey("Pol_Right")]
        public Guid? Pol_RightId { set; get; }
        public virtual Pol_Right Pol_Right { get; set; }
        #endregion
    }
}