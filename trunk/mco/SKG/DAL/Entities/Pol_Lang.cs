#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:26
 * Update: 26/07/2012 14:22
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    /// <summary>
    /// Policy - Language for system (include all form, menuz and more)
    /// </summary>
    public class Pol_Lang : Zinfors
    {
        /// <summary>
        /// Default language (Vietnamese)
        /// </summary>
        public string Caption { set; get; }

        /// <summary>
        /// First language (ZnG ioz)
        /// </summary>
        public string Lang1 { get; set; }

        /// <summary>
        /// Second language (English)
        /// </summary>
        public string Lang2 { get; set; }

        /// <summary>
        /// Third language (and more)
        /// </summary>
        public string Lang3 { get; set; }
    }
}