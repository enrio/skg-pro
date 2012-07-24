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
    /// <summary>
    /// All of actions: Add, Edit, Delete, Print, ... on menuz or form
    /// </summary>
    public class ZAction : ZBase
    {
        /// <summary>
        /// Allow add
        /// </summary>
        public bool Add { set; get; }

        /// <summary>
        /// Allow edit
        /// </summary>
        public bool Edit { set; get; }

        /// <summary>
        /// Allow delete
        /// </summary>
        public bool Delete { set; get; }

        /// <summary>
        /// Allow query
        /// </summary>
        public bool Query { set; get; }

        /// <summary>
        /// Allow print
        /// </summary>
        public bool Print { set; get; }

        /// <summary>
        /// Allow access menuz or form
        /// </summary>
        public bool Access { set; get; }

        /// <summary>
        /// Default show after logon
        /// </summary>
        public bool Default { set; get; }

        private bool _full;
        /// <summary>
        /// Allow all
        /// </summary>
        public bool Full
        {
            set
            {
                _full = value;

                if (value)
                {
                    Add = value;
                    Edit = value;
                    Delete = value;
                    Query = value;
                    Print = value;
                    Access = value;
                    None = !value;
                }
            }
            get { return _full; }
        }

        private bool _none;
        /// <summary>
        /// Deny all
        /// </summary>
        public bool None
        {
            set
            {
                _none = value;

                if (value)
                {
                    Add = !value;
                    Edit = !value;
                    Delete = !value;
                    Query = !value;
                    Print = !value;
                    Access = !value;
                    Full = !value;
                }
            }
            get { return _none; }
        }
    }
}