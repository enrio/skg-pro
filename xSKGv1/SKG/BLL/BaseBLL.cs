#region Information
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
        /// Truy cập cơ sở dữ liệu bảng Tra_Registries: đăng kí giá.
        /// </summary>
        public Tra_RegistryBLL Tra_Registry { set; get; }

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
            Tra_Registry = new Tra_RegistryBLL();
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
            var svr = new SKG.Data.SqlServer();
            return svr.CheckDbExists("xSKGv1");
        }
        #endregion
    }
}