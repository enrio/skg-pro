#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:33
 * Update: 24/07/2012 22:02
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.BLL
{
    using DAL.Entities;

    /// <summary>
    /// Policy - Pol_Right accessing
    /// </summary>
    public sealed class Pol_RightBLL : DAL.Pol_RightDAL
    {
        /// <summary>
        /// Add menuz, form
        /// </summary>
        /// <param name="code">Type of form</param>
        /// <param name="name">Caption</param>
        /// <param name="descript">Description</param>
        /// <returns></returns>
        public object Insert(string code, string name, string descript)
        {
            var o = new Pol_Right() { Code = code, Caption = name, Descript = descript };
            return Insert(o);
        }
    }
}