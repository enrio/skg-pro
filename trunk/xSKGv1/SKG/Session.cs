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

        #region Shift
        /// <summary>
        /// Begin of shift
        /// </summary>
        public DateTime Start { set; get; }

        /// <summary>
        /// End of shift
        /// </summary>
        public DateTime End { set; get; }
        #endregion

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

        /// <summary>
        /// Work of shift (2 shifts: 07:00 - 16:00 today [shift 2]; 16:00 - 07:00 tomorrow [shift 1])
        /// </summary>
        /// <param name="dt">Date of shift</param>
        /// <returns></returns>
        public int Shift(out DateTime dt)
        {
            var cur = Global.Session.Current;
            var log = Global.Session.Login.Value;

            var t = cur - log;
            var tick = t.Ticks / 2;
            var shift = cur.Subtract(new TimeSpan(tick));

            var start = cur.Date.AddHours(7); // start of shift 2
            var end = cur.Date.AddHours(16); // end of shift 2

            if (shift >= start && shift <= end)
            {
                dt = shift.Date;
                return 2;
            }
            else
            {
                if (shift > start)
                    dt = shift.Date.AddDays(1);
                else dt = shift.Date;
                return 1;
            }
        }

        public Session()
        {
            //Current = _bll.GetDate();
        }

        public void Dispose()
        {
            _bll.Dispose();
            _bll = null;
        }

        private Pol_UserBLL _bll = BaseBLL._bll.Pol_User;
    }
}