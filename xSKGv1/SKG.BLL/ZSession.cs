using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    using DAL;
    using DAL.Entities;

    /// <summary>
    /// Phiên đăng nhập hiện tại của người dùng
    /// </summary>
    public sealed class ZSession
    {
        /// <summary>
        /// Người dùng đăng nhập hiện tại
        /// </summary>
        public Pol_User User { set; get; }

        /// <summary>
        /// Thời gian lúc đăng nhập
        /// </summary>
        public DateTime? Login { set; get; }

        /// <summary>
        /// Thời gian hiện tại
        /// </summary>
        public DateTime Current { set; get; }

        /// <summary>
        /// Danh sách các quyền của người dùng
        /// </summary>
        public List<ZAction> ZActions
        {
            get { return User.ToZActions(); }
        }

        /// <summary>
        /// Hiện form mặc định sau khi đăng nhập
        /// </summary>
        public List<ZAction> Default
        {
            get { return User.ToDefaults(); }
        }

        /// <summary>
        /// Lấy quyền hiện tại của chức năng (form)
        /// </summary>
        /// <param name="c">Mã chức năng (tên form)</param>
        /// <returns>Quyền truy cập</returns>
        public ZAction GetZAction(string c)
        {
            return User.ToZAction(c);
        }

        /// <summary>
        /// Get a user's role
        /// </summary>
        /// <param name="c">Code's role</param>
        /// <returns></returns>
        public Pol_Role GetUserRole(string c)
        {
            return User.ToRole(c);
        }
    }
}