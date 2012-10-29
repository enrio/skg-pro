﻿#region Information
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