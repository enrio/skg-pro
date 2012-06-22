﻿using System;
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
        public DateTime? Current { set; get; }

        /// <summary>
        /// Danh sách các quyền của người dùng
        /// </summary>
        public List<ZAction> Rights
        {
            get { return User.ToZActions(); }
        }

        /// <summary>
        /// Quyền hiện tại sau cùng
        /// </summary>
        public ZAction LastRight { set; get; }

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
        public ZAction GetRight(string c)
        {
            return User.ToZAction(c);
        }
    }
}