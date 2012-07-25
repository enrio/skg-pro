#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:33
 * Update: 24/07/2012 21:49
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
    /// Information base
    /// </summary>
    public class Zinfors
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key, Column(Order = 0)]
        public Guid Id { set; get; }

        /// <summary>
        /// Primary key (when to need)
        /// </summary>
        [StringLength(256)]
        public string Code { set; get; }

        /// <summary>
        /// Descriptive detail
        /// </summary>
        public string Descript { set; get; }

        /// <summary>
        /// Order by
        /// </summary>
        public int Order { set; get; }

        /// <summary>
        /// Show data
        /// </summary>
        public bool Show { set; get; }

        /// <summary>
        /// Default is show
        /// </summary>
        public Zinfors() { Show = true; }
    }
}