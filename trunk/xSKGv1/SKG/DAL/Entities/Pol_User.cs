#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 09/08/2013 20:32
 * Update: 09/08/2013 20:32
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    /// <summary>
    /// Policy - User's information
    /// </summary>
    public class Pol_User : Zinfors
    {
        #region Foreign key
        /// <summary>
        /// User's list has permission
        /// </summary>
        public virtual ICollection<Pol_UserRight> UserRights { get; set; }

        /// <summary>
        /// List of user belong group
        /// </summary>
        public virtual ICollection<Pol_UserRole> UserRoles { get; set; }

        /// <summary>
        /// List of user's language choice
        /// </summary>
        public virtual ICollection<Pol_Selection> Selections { get; set; }
        #endregion

        /// <summary>
        /// Account login
        /// </summary>
        public string Acc { set; get; }

        /// <summary>
        /// Password login
        /// </summary>
        public string Pass { set; get; }

        /// <summary>
        /// User's full name
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// User's birthday
        /// </summary>
        public DateTime Birth { set; get; }

        /// <summary>
        /// User's address
        /// </summary>
        public string Address { set; get; }

        /// <summary>
        /// User's phone
        /// </summary>
        public string Phone { set; get; }

        /// <summary>
        /// Check user's role
        /// </summary>
        /// <param name="roleCode">Role of code</param>
        /// <returns></returns>
        public bool CheckRole(string roleCode)
        {
            try
            {
                var role = UserRoles.Where(k => k.Role.Code == roleCode);
                return (role.Count() > 0);
            }
            catch { return false; }
        }

        /// <summary>
        /// Check role administrator
        /// </summary>
        /// <returns></returns>
        public bool CheckAdmin()
        {
            return CheckRole("QT");
        }

        /// <summary>
        /// Check role operator teams
        /// </summary>
        /// <returns></returns>
        public bool CheckOperator()
        {
            return CheckRole("QL");
        }
    }
}