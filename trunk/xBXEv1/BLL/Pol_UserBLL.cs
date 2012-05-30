using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    using UTL.Hasher;

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
                var sss = new Session() { User = GetPass(acc), Current = DateTime.Now };
                pass = Code.Encode(pass);
                //sss.Pol_User.Pass = UTL.Hasher.Code.Decode(sss.Pol_User.Pass);
                if (sss.User.Pass != pass) return null;
                sss.Rights = GetRights(sss.User.Id);
                return sss;
            }
            catch { return null; }
        }
    }
}