using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// System - All menu, form of system is called menuz
    /// </summary>
    public class Sys_Menuz : Zinfors
    {
        #region Foreign key
        /// <summary>
        /// Reference to Sys_Dictionary
        /// </summary>
        [Column(Order = 0), Key, ForeignKey("Dictionary")]
        public new Guid Id { set; get; }
        public virtual Sys_Dictionary Dictionary { get; set; }

        /// <summary>
        /// Reference to itself
        /// </summary>
        [Column(Order = 0), ForeignKey("Parent")]
        public Guid? ParentId { get; set; }
        public virtual Pol_Common Parent { get; set; }
        #endregion

        #region Foreign key on another entity
        /// <summary>
        /// List of user right on menuz
        /// </summary>
        public virtual ICollection<Pol_RoleRight> Pol_RoleRights { get; set; }

        /// <summary>
        /// User's list has permission
        /// </summary>
        public virtual ICollection<Pol_UserRight> Pol_UserRights { get; set; }

        /// <summary>
        /// List of children
        /// </summary>
        public virtual ICollection<Pol_Common> Children { get; set; }
        #endregion

        public string Picture { set; get; }
    }
}