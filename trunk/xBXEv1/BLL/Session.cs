using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    using DAL.Entities;

    /// <summary>
    /// Phiên đăng nhập hiện tại của người dùng
    /// </summary>
    public sealed class Session
    {
        /// <summary>
        /// Người dùng đăng nhập hiện tại
        /// </summary>
        public Pol_User User { set; get; }

        /// <summary>
        /// Thời gian lúc đăng nhập
        /// </summary>
        public DateTime? Current { set; get; }

        /// <summary>
        /// Lấy quyền truy cập của người dùng
        /// </summary>
        /// <param name="codeRight">Mã quyền (tên form)</param>
        /// <returns>Quyền truy cập</returns>
        public ZAction GetRight(string codeRight)
        {
            if (User != null)
            {
                return BaseBLL._pol_UserBLL.GetRights(User.Id, codeRight);
            }
            else return null;
        }
    }
}