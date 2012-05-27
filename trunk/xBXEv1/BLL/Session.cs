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
        /// Danh sách các quyền của người dùng
        /// </summary>
        public List<ZAction> Rights { set; get; }

        /// <summary>
        /// Quyền hiện tại sau cùng
        /// </summary>
        public ZAction LastRight { set; get; }

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
    }
}