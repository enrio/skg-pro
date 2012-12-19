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
    /// Policy - Dictionary for all data
    /// </summary>
    public class Pol_Dictionary : Zinfors
    {
        #region Foreign key
        /// <summary>
        /// Reference to itself (ID)
        /// </summary>
        [Column(Order = 0), ForeignKey("Parent")]
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Parent
        /// </summary>
        public virtual Pol_Dictionary Parent { get; set; }

        /// <summary>
        /// List of children
        /// </summary>
        public virtual ICollection<Pol_Dictionary> Children { get; set; }
        #endregion

        /// <summary>
        /// Type of data
        /// </summary>
        [StringLength(128)]
        public string Type { set; get; }

        #region Language 1
        /// <summary>
        /// Content is shown of language 1
        /// </summary>
        public string Text1 { set; get; }

        /// <summary>
        /// Descriptive detailing of language 1
        /// </summary>
        public string Note1 { set; get; }

        /// <summary>
        /// More information of language 1
        /// </summary>
        public string More1 { set; get; }
        #endregion

        #region Language 2
        /// <summary>
        /// Content is shown of language 2
        /// </summary>
        public string Text2 { set; get; }

        /// <summary>
        /// Descriptive detailing of language 2
        /// </summary>
        public string Note2 { set; get; }

        /// <summary>
        /// More information of language 2
        /// </summary>
        public string More2 { set; get; }
        #endregion

        #region Language 3
        /// <summary>
        /// Content is shown of language 3
        /// </summary>
        public string Text3 { set; get; }

        /// <summary>
        /// Descriptive detailing of language 3
        /// </summary>
        public string Note3 { set; get; }

        /// <summary>
        /// More information of language 3
        /// </summary>
        public string More3 { set; get; }
        #endregion
    }
}