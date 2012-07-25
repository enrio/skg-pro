#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:33
 * Update: 24/07/2012 21:44
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

        #region Foreign key on another entity
        /// <summary>
        /// User's list has permission
        /// </summary>
        public virtual ICollection<Pol_UserRight> Pol_UserRights { get; set; }

        /// <summary>
        /// List of user belong group
        /// </summary>
        public virtual ICollection<Pol_UserRole> Pol_UserRoles { get; set; }
        #endregion
    }
}