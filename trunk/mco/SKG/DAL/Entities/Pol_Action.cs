#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:26
 * Update: 24/07/2012 21:31
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    /// <summary>
    /// Policy - List all of actions: Add, Edit, Delete, Print, ... on menuz or form
    /// </summary>
    public class Pol_Action : ZBase
    {
        /// <summary>
        /// Name of action
        /// </summary>
        public string Name { set; get; }
    }
}