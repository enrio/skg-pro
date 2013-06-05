#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 22:50
 * Update: 04/06/2013 11:11
 * Status: OK
 */
#endregion

using System;
using System.Linq;
using System.Collections.Generic;

namespace SKG.DAL.Entities
{
    /// <summary>
    /// All of actions: add, edit, delete, print, access ... on menu or form
    /// </summary>
    public class Zaction : Zinfors
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