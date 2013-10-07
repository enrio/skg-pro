#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:33
 * Update: 02/06/2013 22:02
 * Status: OK
 */
#endregion

using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;

namespace SKG.BLL
{
    using DAL;
    using SKG.Extend;
    using DAL.Entities;

    /// <summary>
    /// Policy - Pol_Dictionary accessing
    /// </summary>
    public sealed class Pol_DictionaryBLL : Pol_DictionaryDAL
    {
        #region Select
        /// <summary>
        /// Select all kind of data
        /// </summary>
        /// <returns></returns>
        public DataTable SelectRoot()
        {
            return Select((object)Global.STR_ROOT);
        }

        /// <summary>
        /// Select all languages
        /// </summary>
        /// <returns></returns>
        public DataTable SelectLangs()
        {
            return Select((object)Global.STR_LANG);
        }

        /// <summary>
        /// Select all buttons
        /// </summary>
        /// <returns></returns>
        public DataTable SelectButtons()
        {
            return Select((object)Global.STR_BUTTON);
        }

        /// <summary>
        /// Select all roles
        /// </summary>
        /// <returns></returns>
        public DataTable SelectRoles()
        {
            return Select((object)Global.STR_ROLE);
        }

        /// <summary>
        /// Select all rights
        /// </summary>
        /// <returns></returns>
        public DataTable SelectRights()
        {
            return Select((object)Global.STR_RIGHT);
        }

        /// <summary>
        /// Select all region
        /// </summary>
        /// <returns></returns>
        public DataTable SelectRegion()
        {
            return Select((object)Global.STR_REGION);
        }

        /// <summary>
        /// Select all area
        /// </summary>
        /// <returns></returns>
        public DataTable SelectArea()
        {
            return Select((object)Global.STR_AREA);
        }

        /// <summary>
        /// Select all province
        /// </summary>
        /// <returns></returns>
        public DataTable SelectProvince()
        {
            return Select((object)Global.STR_PROVINCE);
        }

        /// <summary>
        /// Select all station
        /// </summary>
        /// <returns></returns>
        public DataTable SelectStation()
        {
            return Select((object)Global.STR_STATION);
        }

        /// <summary>
        /// Select all transport
        /// </summary>
        /// <returns></returns>
        public DataTable SelectTransport()
        {
            return Select((object)Global.STR_TRANSPORT);
        }
        #endregion

        #region Insert
        /// <summary>
        /// Insert kind of data
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object InsertRoot(Pol_Dictionary o)
        {
            o.Type = Global.STR_ROOT;
            return Insert(o);
        }

        /// <summary>
        /// Insert language
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object InsertLang(Pol_Dictionary o)
        {
            o.Type = Global.STR_LANG;
            return Insert(o);
        }

        /// <summary>
        /// Insert button
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object InsertButton(Pol_Dictionary o)
        {
            o.Type = Global.STR_BUTTON;
            return Insert(o);
        }

        /// <summary>
        /// Insert role
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object InsertRole(Pol_Dictionary o)
        {
            o.Type = Global.STR_ROLE;
            return Insert(o);
        }

        /// <summary>
        /// Insert right
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object InsertRight(Pol_Dictionary o)
        {
            o.Type = Global.STR_RIGHT;
            return Insert(o);
        }

        /// <summary>
        /// Insert region
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object InsertRegion(Pol_Dictionary o)
        {
            o.Type = Global.STR_REGION;
            return Insert(o);
        }

        /// <summary>
        /// Insert area
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object InsertArea(Pol_Dictionary o)
        {
            o.Type = Global.STR_AREA;
            return Insert(o);
        }

        /// <summary>
        /// Insert province
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object InsertProvince(Pol_Dictionary o)
        {
            o.Type = Global.STR_PROVINCE;
            return Insert(o);
        }

        /// <summary>
        /// Insert station
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object InsertStation(Pol_Dictionary o)
        {
            o.Type = Global.STR_STATION;
            return Insert(o);
        }

        /// <summary>
        /// Insert transport
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object InsertTransport(Pol_Dictionary o)
        {
            o.Type = Global.STR_TRANSPORT;
            return Insert(o);
        }
        #endregion

        #region Update
        /// <summary>
        /// Update kind of data
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object UpdateRoot(Pol_Dictionary o)
        {
            o.Type = Global.STR_ROOT;
            return Update(o);
        }

        /// <summary>
        /// Update language
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object UpdateLang(Pol_Dictionary o)
        {
            o.Type = Global.STR_LANG;
            return Update(o);
        }

        /// <summary>
        /// Update button
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object UpdateButton(Pol_Dictionary o)
        {
            o.Type = Global.STR_BUTTON;
            return Update(o);
        }

        /// <summary>
        /// Update role
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object UpdateRole(Pol_Dictionary o)
        {
            o.Type = Global.STR_ROLE;
            return Update(o);
        }

        /// <summary>
        /// Update right
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object UpdateRight(Pol_Dictionary o)
        {
            o.Type = Global.STR_RIGHT;
            return Update(o);
        }
        #endregion

        /// <summary>
        /// SplitTime
        /// </summary>
        /// <param name="t">Time</param>
        /// <returns></returns>
        DateTime SplitTime(string t)
        {
            try
            {
                var r = t.Split(new char[] { ':' });

                var h = Convert.ToInt32(r[0]);
                var m = Convert.ToInt32(r[1]);
                var s = Convert.ToInt32(r[2]);

                return new DateTime(1, 1, 1, h, m, s);
            }
            catch { return new DateTime(); }
        }

        #region Shifts
        /// <summary>
        /// Get cut shift from
        /// </summary>
        /// <returns></returns>
        public DateTime GetCutsFr()
        {
            var r = (Pol_Dictionary)Select("CUTS");
            return SplitTime(r.More);
        }

        /// <summary>
        /// Get peak from
        /// </summary>
        /// <returns></returns>
        public DateTime GetPeakFr()
        {
            var r = (Pol_Dictionary)Select("PEAK");
            return SplitTime(r.More);
        }

        /// <summary>
        /// Get peak to
        /// </summary>
        /// <returns></returns>
        public DateTime GetPeakTo()
        {
            var r = (Pol_Dictionary)Select("PEAK");
            return SplitTime(r.More1).AddDays(1);
        }

        /// <summary>
        /// Get shift 1 from
        /// </summary>
        /// <returns></returns>
        public DateTime GetShift1Fr()
        {
            var r = (Pol_Dictionary)Select("SHIFT1");
            return SplitTime(r.More);
        }

        /// <summary>
        /// Get shift 1 to
        /// </summary>
        /// <returns></returns>
        public DateTime GetShift1To()
        {
            var r = (Pol_Dictionary)Select("SHIFT1");
            return SplitTime(r.More1);
        }

        /// <summary>
        /// Get shift 2 from
        /// </summary>
        /// <returns></returns>
        public DateTime GetShift2Fr()
        {
            var r = (Pol_Dictionary)Select("SHIFT2");
            return SplitTime(r.More);
        }

        /// <summary>
        /// Get shift 2 to
        /// </summary>
        /// <returns></returns>
        public DateTime GetShift2To()
        {
            var r = (Pol_Dictionary)Select("SHIFT2");
            return SplitTime(r.More1).AddDays(1);
        }
        #endregion

        #region Coefficient
        /// <summary>
        /// Get delay
        /// </summary>
        /// <returns></returns>
        public int GetDelay()
        {
            try
            {
                var r = (Pol_Dictionary)Select("DELAY");
                return Convert.ToInt32(r.More2);
            }
            catch { return 0; }
        }

        /// <summary>
        /// Get park from
        /// </summary>
        /// <returns></returns>
        public DateTime GetParkFr()
        {
            var r = (Pol_Dictionary)Select("PARK");
            return SplitTime(r.More);
        }

        /// <summary>
        /// Get unit cost of night parking
        /// </summary>
        /// <returns></returns>
        public int GetPark()
        {
            try
            {
                var r = (Pol_Dictionary)Select("PARK");
                return r.More2.ToInt32();
            }
            catch { return 0; }
        }

        /// <summary>
        /// Get unit cost of night parking 1
        /// </summary>
        /// <returns></returns>
        public int GetPark1()
        {
            try
            {
                var r = (Pol_Dictionary)Select("PARK1");
                return r.More2.ToInt32();
            }
            catch { return 0; }
        }

        /// <summary>
        /// Get weight of night parking (seats or beds)
        /// </summary>
        /// <returns></returns>
        public int GetWeight()
        {
            try
            {
                var r = (Pol_Dictionary)Select("WEIGHT");
                return r.More2.ToInt32();
            }
            catch { return 0; }
        }
        #endregion

        #region System
        /// <summary>
        /// Default database name
        /// </summary>
        /// <returns></returns>
        public string GetDbName()
        {
            var r = (Pol_Dictionary)Select("DBN");
            return r == null ? "xSKGv1" : r.Note;
        }

        /// <summary>
        /// Default URL update
        /// </summary>
        /// <returns></returns>
        public string GetURL()
        {
            var r = (Pol_Dictionary)Select("URL");
            return r.Note;
        }
        #endregion

        #region Bonus
        /// <summary>
        /// Rose per seat for north region
        /// </summary>
        /// <returns></returns>
        public int GetRoseNorth()
        {
            try
            {
                var r = (Pol_Dictionary)Select("ROSEB");
                return r.More2.ToInt32();
            }
            catch { return 0; }
        }

        /// <summary>
        /// Rose per seat for south region
        /// </summary>
        /// <returns></returns>
        public int GetRoseSouth()
        {
            try
            {
                var r = (Pol_Dictionary)Select("ROSEN");
                return r.More2.ToInt32();
            }
            catch { return 0; }
        }
        #endregion

        #region Title
        /// <summary>
        /// Address
        /// </summary>
        /// <returns></returns>
        public string GetAddress()
        {
            var r = (Pol_Dictionary)Select("ADDRESS");
            return r.Note;
        }

        /// <summary>
        /// Taxcode
        /// </summary>
        /// <returns></returns>
        public string GetTaxcode()
        {
            var r = (Pol_Dictionary)Select("TAXCODE");
            return r.Note;
        }

        /// <summary>
        /// Title 1
        /// </summary>
        /// <returns></returns>
        public string GetTitle1()
        {
            var r = (Pol_Dictionary)Select("TITLE1");
            return r.Note;
        }

        /// <summary>
        /// Title 2
        /// </summary>
        /// <returns></returns>
        public string GetTitle2()
        {
            var r = (Pol_Dictionary)Select("TITLE2");
            return r.Note;
        }

        /// <summary>
        /// Title 3
        /// </summary>
        /// <returns></returns>
        public string GetTitle3()
        {
            var r = (Pol_Dictionary)Select("TITLE3");
            return r.Note;
        }

        /// <summary>
        /// Audit number
        /// </summary>
        /// <returns></returns>
        public string GetAuditNumber()
        {
            var r = (Pol_Dictionary)Select("NUM");
            return r.Note;
        }
        #endregion
    }
}