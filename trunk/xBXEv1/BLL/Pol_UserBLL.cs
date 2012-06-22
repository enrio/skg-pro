using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    using DAL;
    using DAL.Entities;
    using UTL.Hasher;

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
        public ZSession CheckLogin(string acc, string pass)
        {
            try
            {
                var sss = new ZSession() { User = (Pol_User)Select(acc), Current = GetDate() };
                pass = Code.Encode(pass);
                //sss.Pol_User.Pass = UTL.Hasher.Code.Decode(sss.Pol_User.Pass);
                if (sss.User.Pass != pass) return null;
                //sss.Rights = GetRights(sss.User.Id);
                sss.Rights = sss.User.ToRights();
                return sss;
            }
            catch { return null; }
        }
    }
}