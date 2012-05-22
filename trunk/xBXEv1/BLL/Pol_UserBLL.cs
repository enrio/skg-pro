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
            var tbl = Select(id);
            var sss = new Session();
            if (tbl != null && tbl.Rows.Count > 0)
            {
                sss.Pol_User = new Pol_User() { };
            }
            return sss;
        }
    }
}