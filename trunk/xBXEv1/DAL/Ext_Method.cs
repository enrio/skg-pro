using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    using UTL;
    using Entities;
    using System.Data;

    /// <summary>
    /// Extend methods
    /// </summary>
    public static class Ext_Method
    {
        #region LINQ
        /// <summary>
        /// Convert from IEnumerable (LINQ object) to DataTable
        /// </summary>
        /// <typeparam name="T">Type of data need to convert</typeparam>
        /// <param name="data">Data need to convert</param>
        /// <param name="numbered">Numbered if true else not numbered</param>
        /// <param name="tableName">Table name</param>
        /// <returns>Data</returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> data, string tableName = "Tmp", bool numbered = true)
        {
            var res = BaseUTL.Linq2Table((IEnumerable<T>)data, tableName);
            if (res.Rows.Count > 0) res.Numbered(numbered);
            else res = null;
            return res;
        }

        /// <summary>
        /// Numbered
        /// </summary>
        /// <param name="dtb">DataTable</param>
        /// <param name="numbered">Numbered if true else not numbered</param>
        public static void Numbered(this DataTable dtb, bool numbered = true)
        {
            if (numbered)
            {
                dtb.Columns.Add("No_");
                for (int i = 0; i < dtb.Rows.Count; i++)
                    dtb.Rows[i].SetField("No_", i + 1); // numbered
            }

            dtb.AcceptChanges();
        }
        #endregion

        #region User
        /// <summary>
        /// Returns all list roles
        /// </summary>
        /// <param name="u">User</param>
        /// <returns></returns>
        public static List<Pol_Role> ToListRoles(this Pol_User u)
        {
            try
            {
                var r = from s in u.Pol_UserRoles
                        select s.Pol_Role;
                return r.ToList();
            }
            catch { return null; }
        }

        /// <summary>
        /// Returns all list rights
        /// </summary>
        /// <param name="u">User</param>
        /// <returns></returns>
        public static List<Pol_Right> ToListRights(this Pol_User u)
        {
            try
            {
                var r = from s in u.Pol_UserRights
                        select s.Pol_Right;
                return r.ToList();
            }
            catch { return null; }
        }

        /// <summary>
        /// Returns all rights
        /// </summary>
        /// <param name="u">User</param>
        /// <returns></returns>
        public static List<ZAction> ToZActions(this Pol_User u)
        {
            try
            {
                var a = u.ToUserRights()
                    .ToList<ZAction>();
                var b = u.ToRoleRights()
                    .ToList<ZAction>();
                return a.Union(b).ToList();
            }
            catch { return null; }
        }

        /// <summary>
        /// Returns all defaults
        /// </summary>
        /// <param name="u">User</param>
        /// <returns></returns>
        public static List<ZAction> ToDefaults(this Pol_User u)
        {
            try
            {
                var res = u.ToZActions()
                    .Where(s => s.Default);
                return res.ToList();
            }
            catch { return null; }
        }

        /// <summary>
        /// Returns a right
        /// </summary>
        /// <param name="u">User</param>
        /// <param name="c">Code's right</param>
        /// <returns></returns>
        public static ZAction ToZAction(this Pol_User u, string c)
        {
            try
            {
                var res = u.ToZActions()
                    .Where(s => s.Code == c);
                var zac = res.FirstOrDefault();

                if (res.Count() < 2) return zac;
                if (zac.Full || zac.None) return zac;

                foreach (var i in res)
                {
                    zac.Add |= i.Add;
                    zac.Edit |= i.Edit;
                    zac.Delete |= i.Delete;
                    zac.Default |= i.Default;
                    zac.Print |= i.Print;
                    zac.Access |= i.Access;
                }
                return zac;
            }
            catch { return null; }
        }
        #endregion

        #region User's rights
        /// <summary>
        /// Returns all user's rights
        /// </summary>
        /// <param name="u">User</param>
        /// <returns></returns>
        public static List<Pol_UserRight> ToUserRights(this Pol_User u)
        {
            try
            {
                return u.Pol_UserRights.ToList();
            }
            catch { return null; }
        }

        /// <summary>
        /// Returns all user's right
        /// </summary>
        /// <param name="u">User</param>
        /// <param name="c">Code's right</param>
        /// <returns></returns>
        public static Pol_UserRight ToUserRight(this Pol_User u, string c)
        {
            try
            {
                var a = u.ToUserRights()
                    .Where(s => s.Code == c);
                var b = a.FirstOrDefault();

                if (a.Count() < 2) return b;
                if (b.Full || b.None) return b;

                foreach (var i in a)
                {
                    b.Add |= i.Add;
                    b.Edit |= i.Edit;
                    b.Delete |= i.Delete;
                    b.Default |= i.Default;
                    b.Print |= i.Print;
                    b.Access |= i.Access;
                }
                return b;
            }
            catch { return null; }
        }
        #endregion

        #region Role's rights
        /// <summary>
        /// Returns all role's rights
        /// </summary>
        /// <param name="u">User</param>
        /// <returns></returns>
        public static List<Pol_RoleRight> ToRoleRights(this Pol_User u)
        {
            try
            {
                var a = from s in u.Pol_UserRoles
                        select s.Pol_Role.Pol_RoleRights;
                var b = new List<Pol_RoleRight>();

                foreach (var i in a)
                    foreach (var j in i)
                        b.Add(j);
                return b;
            }
            catch { return null; }
        }

        /// <summary>
        /// Returns role's right
        /// </summary>
        /// <param name="u">User</param>
        /// <param name="c">Code's right</param>
        /// <returns></returns>
        public static Pol_RoleRight ToRoleRight(this Pol_User u, string c)
        {
            try
            {
                var a = u.ToRoleRights()
                    .Where(s => s.Code == c);
                var b = a.FirstOrDefault();

                if (a.Count() < 2) return b;
                if (b.Full || b.None) return b;

                foreach (var i in a)
                {
                    b.Add |= i.Add;
                    b.Edit |= i.Edit;
                    b.Delete |= i.Delete;
                    b.Default |= i.Default;
                    b.Print |= i.Print;
                    b.Access |= i.Access;
                }
                return b;
            }
            catch { return null; }
        }
        #endregion
    }
}