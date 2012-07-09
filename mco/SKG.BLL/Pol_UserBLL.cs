using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.BLL
{
    using SKG.Hasher;
    using DAL.Entities;

    /// <summary>
    /// Truy cập cơ sở dữ liệu bảng Pol_User: danh sách người dùng.
    /// </summary>
    public sealed class Pol_UserBLL : DAL.Pol_UserDAL
    {
        /// <summary>
        /// Kiểm tra tài khoản đăng nhập
        /// </summary>
        /// <param name="acc">Tên tài khoản</param>
        /// <param name="pass">Mật khẩu</param>
        /// <returns>Phiên đăng nhập</returns>
        public Session CheckLogin(string acc, string pass)
        {
            try
            {
                var sss = new Session() { User = (Pol_User)Select(acc), Login = GetDate() };
                sss.Current = sss.Login.Value;
                pass = Coder.Encode(pass);
                if (sss.User.Pass != pass) return null;
                return sss;
            }
            catch { return null; }
        }
    }
}