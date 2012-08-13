using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG
{
    using BLL;
    using DAL.Entities;

    public sealed class Session : IDisposable
    {
        public Pol_User User { set; get; }
        public DateTime? Login { set; get; }
        public DateTime Current { set; get; }

        public List<Zaction> ZActions
        {
            get { return _bll.GetRights(User.Id); }
        }

        public List<Zaction> Default
        {
            get
            {
                var res = ZActions.Where(s => s.Default);
                return res.ToList();
            }
        }

        public Zaction GetZAction(string c)
        {
            var res = from s in ZActions
                      where s.Code == c
                      select s;
            return res.FirstOrDefault();
        }

        public Pol_Dictionary GetUserRole(string c)
        {
            var tmp = _bll.GetRoles(User.Id);
            var res = from s in tmp
                      where s.Code == c
                      select s;
            return res.FirstOrDefault();
        }

        public void Dispose()
        {
            _bll.Dispose();
            _bll = null;
        }

        private Pol_UserBLL _bll = BaseBLL._bll.Pol_User;
    }
}