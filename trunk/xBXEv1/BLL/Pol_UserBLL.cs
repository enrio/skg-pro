using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    using DAL.Entities;

    public sealed class Pol_UserBLL : DAL.Pol_UserDAL
    {
        public Session CheckLogin(string acc, string pass)
        {
            try
            {
                var sss = new Session() { Pol_User = GetPass(acc), Current = DateTime.Now };
                pass = UTL.Hasher.Code.Encode(pass);
                //sss.Pol_User.Pass = UTL.Hasher.Code.Decode(sss.Pol_User.Pass);
                if (sss.Pol_User.Pass != pass) return null;
                return sss;
            }
            catch { return null; }
        }
    }
}