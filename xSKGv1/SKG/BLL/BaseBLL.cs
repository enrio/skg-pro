#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:33
 * Update: 02/06/2013 22:02
 * Status: OK
 */
#endregion

using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.BLL
{
    using SKG.Datax;
    using SKG.Extend;

    /// <summary>
    /// Data sample, all of flow processing
    /// </summary>
    public class BaseBLL
    {
        #region Properties access database
        /// <summary>
        /// Policy - Pol_Dictionary accessing
        /// </summary>
        public Pol_DictionaryBLL Pol_Dictionary { set; get; }

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

        /// <summary>
        /// Truy cập cơ sở dữ liệu bảng Tra_Kind: danh mục loại xe.
        /// </summary>
        public Tra_TariffBLL Tra_Tariff { set; get; }

        /// <summary>
        /// Truy cập cơ sở dữ liệu bảng Tra_Vehicle: danh sách xe cộ.
        /// </summary>
        public Tra_VehicleBLL Tra_Vehicle { set; get; }

        /// <summary>
        /// Truy cập cơ sở dữ liệu bảng Tra_Detail: chi tiết xe ra vào, bến.
        /// </summary>
        public Tra_DetailBLL Tra_Detail { set; get; }
        #endregion

        /// <summary>
        /// Constructor access database
        /// </summary>
        public BaseBLL()
        {
            Pol_Dictionary = new Pol_DictionaryBLL();
            Pol_User = new Pol_UserBLL();
            Pol_UserRight = new Pol_UserRightBLL();
            Pol_UserRole = new Pol_UserRoleBLL();
            Pol_RoleRight = new Pol_RoleRightBLL();
            Tra_Tariff = new Tra_TariffBLL();
            Tra_Vehicle = new Tra_VehicleBLL();
            Tra_Detail = new Tra_DetailBLL();
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
            var a = Global.Connection.ConnectionString;

            var ok = a.SplitIndex(';', 1);
            if (ok == null)
            {
                a = a.SplitIndex('\\', 1);
                a = String.Format(@"{0}\{1}", Application.StartupPath, a);
                return a.CheckSqlCeConnect();
            }

            var svr = new Server(a);
            return svr.CheckDbExists(Global.Connection.Database);
        }
        #endregion
    }
}