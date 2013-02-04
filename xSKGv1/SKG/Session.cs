using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG
{
    using BLL;
    using Extend;
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

        /// <summary>
        /// Work of shift (2 shifts: 07:00 - 16:00 today [shift 1]; 16:00 - 07:00 tomorrow [shift 2])
        /// </summary>
        /// <param name="dt">Date of shift</param>
        /// <returns></returns>
        public static int Shift(out DateTime dt, DateTime? date = null)
        {
            DateTime cur, log;
            if (date == null)
            {
                cur = Global.Session.Current;
                log = Global.Session.Login.Value;
            }
            else cur = log = date.Value;

            var t = cur - log;
            var tick = t.Ticks / 2;
            var shift = cur.Subtract(new TimeSpan(tick));

            var start = cur.Date.AddHours(7); // start of shift 1
            var end = cur.Date.AddHours(16); // end of shift 1

            if (shift >= start && shift <= end)
            {
                dt = shift.Date;
                return 1;
            }
            else
            {
                if (shift > start)
                    dt = shift.Date.AddDays(1);
                else dt = shift.Date;
                return 2;
            }
        }

        /// <summary>
        /// Cut shift day: from 13:00:01 the day before to 13:00:00 today
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        public static void CutShiftDay(DateTime date, out DateTime fr, out DateTime to)
        {
            fr = date.Date.AddDays(-1).AddHours(13).AddSeconds(1);
            to = date.Date.AddHours(13);
        }

        /// <summary>
        /// Cut shift month: from 13:00:01 end of month before to 13:00:00 end of month current
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        public static void CutShiftMonth(DateTime date, out DateTime fr, out DateTime to)
        {
            var start = date.ToStartOfMonth();
            var end = date.ToEndOfMonth().Date;

            fr = start.AddDays(-1).AddHours(13).AddSeconds(1);
            to = end.AddHours(13);
        }

        /// <summary>
        /// Cut shift january: from 31/12 at 13:00:01 of year before to 13:00:00 end of month current
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        public static void CutShiftJanuary(DateTime date, out DateTime fr, out DateTime to)
        {
            var start = date.ToStartOfYear();
            var end = date.ToEndOfMonth().Date;

            fr = start.AddDays(-1).AddHours(13).AddSeconds(1);
            to = end.AddHours(13);
        }

        /// <summary>
        /// Cut shift normal: from 14:00:01 before - 05:00:00 today; 05:00:01 - 14:00:00 today
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        public static void CutShiftNormal(DateTime date, out DateTime fr, out DateTime to)
        {
            fr = date.Date.AddHours(5).AddSeconds(1); // 05:00:01 today
            to = date.Date.AddHours(14); // 14:00:00 today

            if (fr <= date && date <= to)
            {
                fr = to.AddDays(-1).AddSeconds(1); // 14:00:01 before
                to = date.Date.AddHours(5); // 05:00:00 today
            }
        }
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

        public Session()
        {
            Current = DateTime.Now;
        }

        public void Dispose()
        {
            _bll.Dispose();
            _bll = null;
        }

        private Pol_UserBLL _bll = BaseBLL._bll.Pol_User;
    }
}