using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    using System.Data;
    using UTL;
    using SKG.UTL;
    using Entities;

    /// <summary>
    /// Extend methods
    /// </summary>
    public static class Ext_Method
    {
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

        #region User
        /// <summary>
        /// Returns all roles
        /// </summary>
        /// <param name="u">User</param>
        /// <returns></returns>
        public static List<Pol_Role> ToRoles(this Pol_User u)
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
        /// Returns all rights
        /// </summary>
        /// <param name="u">User</param>
        /// <returns></returns>
        public static List<Pol_Right> ToRights(this Pol_User u)
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
        /// Returns all user's rights
        /// </summary>
        /// <param name="u">User</param>
        /// <returns></returns>
        public static List<ZAction> ToUserRights(this Pol_User u)
        {
            try
            {
                return u.Pol_UserRights.ToList<ZAction>();
            }
            catch { return null; }
        }
        #endregion

        #region Role
        /// <summary>
        /// Returns all role's rights
        /// </summary>
        /// <param name="u">User</param>
        /// <returns></returns>
        public static List<ZAction> ToRoleRights(this Pol_User u)
        {
            try
            {
                var res = from s in u.Pol_UserRoles
                          select s.Pol_Role.Pol_RoleRights;
                var zac = new List<ZAction>();

                foreach (var rol in res)
                    foreach (var rig in rol)
                    {
                        var z = new ZAction()
                        {
                            Code = rig.Pol_Right.Code,
                            Add = rig.Add,
                            Edit = rig.Edit,
                            Delete = rig.Delete,
                            Query = rig.Query,
                            Print = rig.Print,
                            Access = rig.Access,
                            Default = rig.Default,
                            Full = rig.Full,
                            None = rig.None
                        };
                        zac.Add(z);
                    }
                return zac;
            }
            catch { return null; }
        }

        /// <summary>
        /// Returns role's right
        /// </summary>
        /// <param name="u">User</param>
        /// <param name="c">Code's right</param>
        /// <returns></returns>
        public static ZAction ToRoleRight(this Pol_User u, string c)
        {
            try
            {
                var res = u.ToRoleRights().Where(p => p.Code == c);

                if (res.Count() > 1)
                {
                }

                return res.SingleOrDefault();
            }
            catch { return null; }
        }
        #endregion
    }
}