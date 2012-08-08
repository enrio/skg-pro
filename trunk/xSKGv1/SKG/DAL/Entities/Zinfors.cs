﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2013 21:05
 * Update: 24/07/2013 21:05
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
        /// Primary key auto generated
        /// </summary>
        [Key, Column(Order = 0)]
        public Guid Id { set; get; }

        /// <summary>
        /// Primary key made by hand
        /// </summary>
        [StringLength(256)]
        public string Code { set; get; }

        #region Base
        /// <summary>
        /// Content is shown
        /// </summary>
        public string Text { set; get; }

        /// <summary>
        /// Descriptive detailing
        /// </summary>
        public string Descript { set; get; }

        /// <summary>
        /// Sort order
        /// </summary>
        public int Order { set; get; }

        /// <summary>
        /// Show data, set false is deleted
        /// </summary>
        public bool Show { set; get; }
        #endregion

        #region Log
        /// <summary>
        /// Created date
        /// </summary>
        public DateTime? CreatedDate { set; get; }

        /// <summary>
        /// Modifed date
        /// </summary>
        public DateTime? ModifedDate { set; get; }

        /// <summary>
        /// Created by
        /// </summary>
        public Guid? CreatedBy { set; get; }

        /// <summary>
        /// Modified by
        /// </summary>
        public Guid? ModifiedBy { set; get; }
        #endregion

        /// <summary>
        /// Default is shown
        /// </summary>
        public Zinfors() { Show = true; }
    }
}