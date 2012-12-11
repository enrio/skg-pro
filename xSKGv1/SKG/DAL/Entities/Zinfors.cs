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
    /// Base - Information
    /// </summary>
    public class Zinfors
    {
        #region Primary key
        /// <summary>
        /// Primary key auto generated
        /// </summary>
        [Key, Column(Order = 0)]
        public Guid Id { set; get; }

        /// <summary>
        /// Primary key made by hand
        /// </summary>
        [StringLength(256)]
        public string Code { set; get; }
        #endregion
        /*
        #region Foreign key
        /// <summary>
        /// Creator (refercence to Pol_User)
        /// </summary>
        [Column(Order = 3), ForeignKey("Creator")]
        public Guid? CreatorId { set; get; }
        /// <summary>
        /// Creator
        /// </summary>
        public virtual Pol_User Creator { get; set; }

        /// <summary>
        /// Modifier (refercence to Pol_User)
        /// </summary>
        [Column(Order = 3), ForeignKey("Modifier")]
        public Guid? ModifierId { set; get; }
        /// <summary>
        /// Creator
        /// </summary>
        public virtual Pol_User Modifier { get; set; }

        /// <summary>
        /// Deleter (refercence to Pol_User)
        /// </summary>
        [Column(Order = 3), ForeignKey("Deleter")]
        public Guid? DeleterId { set; get; }
        /// <summary>
        /// Creator
        /// </summary>
        public virtual Pol_User Deleter { get; set; }
        #endregion

        #region Date action
        /// <summary>
        /// Created date
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Modified date
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Deleted date
        /// </summary>
        public DateTime? DeletedDate { get; set; }
        #endregion
        */
        #region Default language
        /// <summary>
        /// Content is shown of default language
        /// </summary>
        public string Text { set; get; }

        /// <summary>
        /// Descriptive detailing of default language
        /// </summary>
        public string Note { set; get; }

        /// <summary>
        /// More information of default language
        /// </summary>
        public string More { set; get; }
        #endregion

        /// <summary>
        /// Sort order
        /// </summary>
        public int Order { set; get; }

        /// <summary>
        /// Show data, set false is deleted
        /// </summary>
        public bool Show { set; get; }

        /// <summary>
        /// Default is shown
        /// </summary>
        public Zinfors() { Show = true; }
    }
}