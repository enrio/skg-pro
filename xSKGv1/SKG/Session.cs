#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 16/06/2013 08:32
 * Status: OK
 */
#endregion

using System;
using System.Linq;
using System.Collections.Generic;

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
        /// Cut shift day: from 15:00:01 the day before to 15:00:00 today
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        public static void CutShiftDay(DateTime date, out DateTime fr, out DateTime to)
        {
            fr = date.Date.AddDays(-1).AddTicks(Global.CutsFr.Ticks).AddSeconds(1);
            to = date.Date.AddTicks(Global.CutsFr.Ticks);
        }

        /// <summary>
        /// Cut shift month: from 15:00:01 end of month before to 15:00:00 end of month current
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        public static void CutShiftMonth(DateTime date, out DateTime fr, out DateTime to)
        {
            var start = date.ToStartOfMonth();
            var end = date.ToEndOfMonth().Date;

            fr = start.AddDays(-1).AddTicks(Global.CutsFr.Ticks).AddSeconds(1);
            to = end.AddTicks(Global.CutsFr.Ticks);
        }

        /// <summary>
        /// Cut shift january: from 31/12 at 15:00:01 of year before to 15:00:00 end of month current
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        public static void CutShiftJanuary(DateTime date, out DateTime fr, out DateTime to)
        {
            var start = date.ToStartOfYear();
            var end = date.ToEndOfMonth().Date;

            fr = start.AddDays(-1).AddTicks(Global.CutsFr.Ticks).AddSeconds(1);
            to = end.AddTicks(Global.CutsFr.Ticks);
        }

        /// <summary>
        /// Cut shift normal: from 14:00:01 before - 06:00:00 today; 06:00:01 - 14:00:00 today
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        public static void CutShiftNormal(DateTime date, out DateTime fr, out DateTime to)
        {
            var tmp = date.Date;
            fr = tmp.AddTicks(Global.Shift1Fr.Ticks); // 06:00:01 today
            to = tmp.AddTicks(Global.Shift1To.Ticks); // 14:00:00 today

            if (date < fr)
            {

                fr = tmp.AddDays(-1).AddTicks(Global.Shift1Fr.Ticks); // 06:00:01 before
                to = tmp.AddDays(-1).AddTicks(Global.Shift1To.Ticks); // 14:00:00 before
            }

            if (fr <= date && date <= to)
            {
                fr = to.AddDays(-1).AddSeconds(1); // 14:00:01 before
                to = tmp.AddSeconds(-1).AddTicks(Global.Shift1Fr.Ticks); // 06:00:00 today
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

        public Session() { Current = DateTime.Now; }

        public void Dispose()
        {
            _bll.Dispose();
            _bll = null;
        }

        private Pol_UserBLL _bll = BaseBLL._bll.Pol_User;
    }
}