using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Chính sách - nhóm quyền (chức năng) có các quyền (chức năng) của hệ thống
    /// </summary>
    public class Pol_RoleRight : ZAction
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