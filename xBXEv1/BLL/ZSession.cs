using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
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
        public DateTime? Current { set; get; }

        /// <summary>
        /// Danh sách các quyền của người dùng
        /// </summary>
        public List<ZAction> Rights { set; get; }

        /// <summary>
        /// Quyền hiện tại sau cùng
        /// </summary>
        public ZAction LastRight { set; get; }

        /// <summary>
        /// Hiện form mặc định sau khi đăng nhập
        /// </summary>
        public ZAction Default
        {
            get
            {
                foreach (var x in Rights)
                    if (x.Default) return x;
                return null;
            }
        }

        /// <summary>
        /// Lấy quyền hiện tại của chức năng (form)
        /// </summary>
        /// <param name="codeRight">Mã chức năng (tên form)</param>
        /// <returns>Quyền truy cập</returns>
        public ZAction GetRight(string codeRight)
        {
            foreach (var x in Rights)
                if (x.Code == codeRight)
                {
                    LastRight = x;
                    return x;
                };
            return null;
        }

        public Pol_UserRole GetUserRole(string s)
        {
            var a = from b in User.Pol_UserRoles
                    where b.Code == s
                    select b;
            return a.SingleOrDefault();
        }

        public Pol_UserRight GetUserRight(string s)
        {
            var a = from b in User.Pol_UserRights
                    where b.Code == s
                    select b;
            return a.SingleOrDefault();
        }
    }
}