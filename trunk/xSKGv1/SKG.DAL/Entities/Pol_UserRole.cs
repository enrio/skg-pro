using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Danh sách người dùng thuộc nhóm người dùng của hệ thống
    /// </summary>
    public class Pol_UserRole : ZBase
    {
        #region Khoá ngoại
        /// <summary>
        /// Khoá ngoại tham chiếu tới Pol_User
        /// </summary>
        [Column(Order = 0), ForeignKey("Pol_User")]
        public Guid? Pol_UserId { set; get; }
        public virtual Pol_User Pol_User { get; set; }

        /// <summary>
        /// Khoá ngoại tham chiếu tới Pol_Role
        /// </summary>
        [Column(Order = 1), ForeignKey("Pol_Role")]
        public Guid? Pol_RoleId { set; get; }
        public virtual Pol_Role Pol_Role { get; set; }
        #endregion
    }
}