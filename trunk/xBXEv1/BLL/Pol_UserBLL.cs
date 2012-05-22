using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    using DAL.Entities;

    public sealed class Pol_UserBLL : DAL.Pol_UserDAL
    {
        public Session CheckLogin(string id, string pass)
        {
            var sss = new Session() { Pol_User = GetPass(id), Current = DateTime.Now };
            return sss;
        }
    }
}