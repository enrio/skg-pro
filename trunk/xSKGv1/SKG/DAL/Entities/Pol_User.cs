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
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Policy - User's information
    /// </summary>
    public class Pol_User : Zinfors
    {
        #region Foreign key
        /// <summary>
        /// Reference to Pol_Dictionary (ID)
        /// </summary>
        [Column(Order = 0), ForeignKey("Dictionary")]
        public Guid? DictionaryId { set; get; }

        /// <summary>
        /// Reference to Pol_Dictionary (object)
        /// </summary>
        public virtual Pol_Dictionary Dictionary { get; set; }

        /// <summary>
        /// User's list has permission
        /// </summary>
        public virtual ICollection<Pol_UserRight> Pol_UserRights { get; set; }

        /// <summary>
        /// List of user belong group
        /// </summary>
        public virtual ICollection<Pol_UserRole> Pol_UserRoles { get; set; }

        /// <summary>
        /// List of user's language choice
        /// </summary>
        public virtual ICollection<Pol_Selection> Pol_Selections { get; set; }
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
    }
}