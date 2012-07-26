﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:33
 * Update: 26/07/2012 14:22
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.BLL
{
    /// <summary>
    /// Data sample, all of flow processing
    /// </summary>
    public class BaseBLL
    {
        #region Properties access database
        /// <summary>
        /// Policy - Pol_Lang accessing
        /// </summary>
        public Pol_LangBLL Pol_Lang { set; get; }

        /// <summary>
        /// Policy - Pol_Right accessing
        /// </summary>
        public Pol_RightBLL Pol_Right { set; get; }

        /// <summary>
        /// Policy - Pol_Role accessing
        /// </summary>
        public Pol_RoleBLL Pol_Role { set; get; }

        /// <summary>
        /// Policy - Pol_User accessing
        /// </summary>
        public Pol_UserBLL Pol_User { set; get; }

        /// <summary>
        /// Policy - Pol_UserRight accessing
        /// </summary>
        public Pol_UserRightBLL Pol_UserRight { set; get; }

        /// <summary>
        /// Policy - Pol_UserRole accessing
        /// </summary>
        public Pol_UserRoleBLL Pol_UserRole { set; get; }

        /// <summary>
        /// Policy - Pol_RoleRight accessing
        /// </summary>
        public Pol_RoleRightBLL Pol_RoleRight { set; get; }
        #endregion

        /// <summary>
        /// Constructor access database
        /// </summary>
        public BaseBLL()
        {
            Pol_Lang = new Pol_LangBLL();
            Pol_Right = new Pol_RightBLL();
            Pol_Role = new Pol_RoleBLL();
            Pol_User = new Pol_UserBLL();
            Pol_UserRight = new Pol_UserRightBLL();
            Pol_UserRole = new Pol_UserRoleBLL();
            Pol_RoleRight = new Pol_RoleRightBLL();
        }

        #region Static methods
        /// <summary>
        /// All of flow processing
        /// </summary>
        public static BaseBLL _bll = new BaseBLL();

        /// <summary>
        /// Check database exists
        /// </summary>
        /// <returns></returns>
        public static bool CheckDb()
        {
            return _bll.Pol_User.Count() > 0;
        }
        #endregion
    }
}