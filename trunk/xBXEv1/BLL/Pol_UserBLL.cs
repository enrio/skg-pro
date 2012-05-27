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
                var sss = new Session() { User = GetPass(acc), Current = DateTime.Now };
                pass = UTL.Hasher.Code.Encode(pass);
                //sss.Pol_User.Pass = UTL.Hasher.Code.Decode(sss.Pol_User.Pass);
                if (sss.User.Pass != pass) return null;
                sss.Rights = GetRights(sss.User.Id);
                return sss;
            }
            catch { return null; }
        }
    }
}