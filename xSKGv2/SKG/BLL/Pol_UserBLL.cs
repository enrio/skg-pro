#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:33
 * Update: 24/07/2012 22:02
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.BLL
{
    using SKG.Hasher;
    using DAL.Entities;

    /// <summary>
    /// Policy - Pol_User accessing
    /// </summary>
    public sealed class Pol_UserBLL : DAL.Pol_UserDAL
    {
        /// <summary>
        /// Check login
        /// </summary>
        /// <param name="acc">User's acount</param>
        /// <param name="pass">User's password</param>
        /// <returns></returns>
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

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="pass">New password need to change</param>
        /// <returns></returns>
        public bool ChangePass(string pass)
        {
            object ok;
            if (Global.Session.User != null)
            {
                Global.Session.User.Pass = pass;
                ok = Update(Global.Session.User);
                if (ok != null) return true;
                else return false;
            }
            else return false;
        }
    }
}