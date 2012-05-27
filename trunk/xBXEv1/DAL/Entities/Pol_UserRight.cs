using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Chính sách - người dùng có các quyền của hệ thống
    /// </summary>
    public class Pol_UserRight : ZAction
    {
        #region Khoá ngoại
        /// <summary>
        /// Khoá ngoại tham chiếu tới Pol_User
        /// </summary>
        [Column(Order = 0), ForeignKey("Pol_User")]
        public Guid? Pol_UserId { set; get; }
        public virtual Pol_User Pol_User { get; set; }

        /// <summary>
        /// Khoá ngoại tham chiếu tới Pol_Right
        /// </summary>
        [Column(Order = 1), ForeignKey("Pol_Right")]
        public Guid? Pol_RightId { set; get; }
        public virtual Pol_Right Pol_Right { get; set; }
        #endregion
    }
}