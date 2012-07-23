using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    public class Pol_Menu : ZBase
    {
        /// <summary>
        /// Menu of level
        /// </summary>
        public int Level { set; get; }

        /// <summary>
        /// Default language
        /// </summary>
        public string Caption { set; get; }

        /// <summary>
        /// Namespace or type name
        /// </summary>
        public string Type { set; get; }

        /// <summary>
        /// Picture for icon
        /// </summary>
        public string Picture { set; get; }

        #region Foreign key on another entity
        /// <summary>
        /// List of role has permission
        /// </summary>
        public virtual ICollection<Pol_RoleRight> Pol_RoleRights { get; set; }

        /// <summary>
        /// User's list has permission
        /// </summary>
        public virtual ICollection<Pol_UserRight> Pol_UserRights { get; set; }

        /// <summary>
        /// Language of menuz
        /// </summary>
        public virtual Pol_Lang Pol_Langs { get; set; }
        #endregion
    }
}