using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.DAL
{
    using UTL.Extension;
    using Entities;

    public static class ZExtend
    {
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
        /// Returns a role
        /// </summary>
        /// <param name="u">User</param>
        /// <returns></returns>
        public static Pol_Role ToRole(this Pol_User u, string c)
        {
            try
            {
                return u.ToRoles().
                    Where(s => s.Code == c)
                    .FirstOrDefault();
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
        /// Returns a right
        /// </summary>
        /// <param name="u">User</param>
        /// <returns></returns>
        public static Pol_Right ToRight(this Pol_User u, string c)
        {
            try
            {
                return u.ToRights().
                   Where(s => s.Code == c)
                   .FirstOrDefault();
            }
            catch { return null; }
        }

        /// <summary>
        /// Returns all actions
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
                return u.ToZActions()
                    .Where(s => s.Default)
                 .ToList();
            }
            catch { return null; }
        }

        /// <summary>
        /// Returns a action
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