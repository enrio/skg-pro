#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:33
 * Update: 24/07/2012 23:42
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
    /// Data sample, all of flow processing
    /// </summary>
    public class Sample : BaseBLL
    {
        #region Static methods
        /// <summary>
        /// Auto create data for sample
        /// </summary>
        /// <param name="isDelete">Delete</param>
        public static void CreateData(bool isDelete = false)
        {
            var bll = new Sample();
            if (isDelete) bll.DeleteAll();
            if (bll.Pol_User.Count() > 0) return;
            bll.CreateAll();
        }
        #endregion

        #region Create data sample
        /// <summary>
        /// Pol_Lang table
        /// </summary>
        void CreatePol_Lang()
        {
            if (Pol_Lang.Count() > 0) return;
            #region For Pol_Right
            var a = (Pol_Right)Pol_Right.Select("SKG.DXF.Home.Catalog.FrmPol_Action");
            var o = new Pol_Lang() { Default = "Hành động", Lang1 = "Hbd fhz", Lang2 = "Action", Order = 0 };
            o = (Pol_Lang)Pol_Lang.Insert(o);
            a.Pol_UserLangId = o.Id;
            Pol_Right.Update(a);
            #endregion
        }

        /// <summary>
        /// Pol_Action table
        /// </summary>
        void CreatePol_Action()
        {
            if (Pol_Action.Count() > 0) return;

            var o = new Pol_Action() { Code = "Add", Name = "Thêm", Descript = "Cho phép thêm dữ liệu", Order = 0 };
            Pol_Action.Insert(o);
            o = new Pol_Action() { Code = "Edit", Name = "Sửa", Descript = "Cho phép sửa dữ liệu", Order = 1 };
            Pol_Action.Insert(o);
            o = new Pol_Action() { Code = "Delete", Name = "Xoá", Descript = "Cho phép xoá dữ liệu", Order = 2 };
            Pol_Action.Insert(o);
            o = new Pol_Action() { Code = "Default", Name = "Tự mở", Descript = "Cho phép tự động hiện chức năng (form)", Order = 3 };
            Pol_Action.Insert(o);
            o = new Pol_Action() { Code = "Print", Name = "In ấn", Descript = "Cho phép in ấn dữ liệu", Order = 4 };
            Pol_Action.Insert(o);
            o = new Pol_Action() { Code = "Access", Name = "Truy cập", Descript = "Cho phép hiện form (chức năng) này", Order = 5 };
            Pol_Action.Insert(o);
            o = new Pol_Action() { Code = "Full", Name = "Tất cả", Descript = "Có tất cả quyền", Order = 6 };
            Pol_Action.Insert(o);
            o = new Pol_Action() { Code = "None", Name = "Không có", Descript = "Không có quyền", Order = 7 };
            Pol_Action.Insert(o);
        }

        /// <summary>
        /// Pol_Right table
        /// </summary>
        void CreatePol_Right()
        {
            if (Pol_Right.Count() > 0) return;

            var a = new Services();
            var b = a.GetPlugins();
            var c = Services.GetMenu(b);

            foreach (var i in c)
            {
                var o = new Pol_Right() { Level = i.Level, Caption = i.Caption, Code = i.Code, Picture = i.Picture, Order = i.Order, Show = i.Show };
                Pol_Right.Insert(o);
            }
        }

        /// <summary>
        /// Pol_Role table
        /// </summary>
        void CreatePol_Role()
        {
            if (Pol_Role.Count() > 0) return;

            var o = new Pol_Role() { Code = "CV", Name = "Cổng vào", Descript = "Có vai trò ở cổng vào" };
            Pol_Role.Insert(o);
            o = new Pol_Role() { Code = "CR", Name = "Cổng ra", Descript = "Có vai trò ở cổng ra" };
            Pol_Role.Insert(o);
            o = new Pol_Role() { Code = "ND", Name = "Người dùng", Descript = "Có vai trò ở cổng vào và ra" };
            Pol_Role.Insert(o);
            o = new Pol_Role() { Code = "QL", Name = "Quản lí", Descript = "Có vai trò quản lí người dùng, nhóm, loại, xe" };
            Pol_Role.Insert(o);
            o = new Pol_Role() { Code = "QT", Name = "Quản trị", Descript = "Có tất cả vai trò" };
            Pol_Role.Insert(o);
            o = new Pol_Role() { Code = "TK", Name = "Thống kê", Descript = "Xem và in ấn các báo cáo, thống kê" };
            Pol_Role.Insert(o);
        }

        /// <summary>
        /// Pol_User table
        /// </summary>
        void CreatePol_User()
        {
            if (Pol_User.Count() > 0) return;

            var o = new Pol_User() { Acc = "nvt", Pass = "nvt", Name = "Nguyễn Văn Toàn", Birth = new DateTime(1988, 1, 5), Address = "26A/3 Hoà Tân, Tân Hoà, Lai Vung, Đồng Tháp", Phone = "+841645 515 010" };
            Pol_User.Insert(o);
            o = new Pol_User() { Acc = "ntt", Pass = "ntt", Name = "Nguyễn Thị Thuy Thuỷ", Birth = new DateTime(1991, 1, 5), Address = "26A/3 Hoà Tân, Tân Hoà, Lai Vung, Đồng Tháp", Phone = "+841654 015 046" };
            Pol_User.Insert(o);
            o = new Pol_User() { Acc = "nvl", Pass = "nvl", Name = "Nguyễn Văn Lợi", Birth = new DateTime(1992, 12, 12), Address = "26A/3 Hoà Tân, Tân Hoà, Lai Vung, Đồng Tháp", Phone = "+841645 800 000" };
            Pol_User.Insert(o);
            o = new Pol_User() { Acc = "cr", Pass = "@123456", Name = "Nguyễn Cổng Ra", Birth = new DateTime(1980, 12, 12), Address = "26A/3 Đường 30/4, F. Xuân Khánh, Q. Ninh Kiều, TP. Cần Thơ", Phone = "+841645 888 000" };
            Pol_User.Insert(o);
            o = new Pol_User() { Acc = "cv", Pass = "@123456", Name = "Nguyễn Cổng Vào", Birth = new DateTime(1980, 12, 12), Address = "143 Đường 3/2, F. Xuân Khánh, Q. Ninh Kiều, TP. Cần Thơ", Phone = "+841645 888 123" };
            Pol_User.Insert(o);
            o = new Pol_User() { Acc = "kt", Pass = "@qwerty", Name = "Kế Văn Toán", Birth = new DateTime(1982, 7, 2), Address = "143 Đường 3/2, F. Xuân Khánh, Q. Ninh Kiều, TP. Cần Thơ", Phone = "+841665 696 123" };
            Pol_User.Insert(o);
            o = new Pol_User() { Acc = "xyz", Pass = "xyz", Name = "Không Văn Biết", Birth = new DateTime(1988, 1, 5), Address = "Sao Hoả, Hệ Mặt Trời", Phone = "+841645 999 666" };
            Pol_User.Insert(o);
            o = new Pol_User() { Acc = "admin", Pass = "", Name = "Siêu Quản Trị", Birth = new DateTime(1988, 1, 5), Address = "Âm Tàu, Địa Phủ", Phone = "+841699 999 666" };
            Pol_User.Insert(o);
            o = new Pol_User() { Acc = "edmin", Pass = "edmin", Name = "Em Quản Trị", Birth = new DateTime(1989, 1, 5), Address = "Phương Trời, Xa Lạ", Phone = "+841699 999 686" };
            Pol_User.Insert(o);
        }

        /// <summary>
        /// Pol_UserRight table
        /// </summary>
        void CreatePol_UserRight()
        {
            if (Pol_UserRight.Count() > 0) return;

            var a = (Pol_User)Pol_User.Select("xyz");
            var b = (Pol_Right)Pol_Right.Select("SKG.DXF.Home.Catalog.FrmPol_Right");
            var o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_UserRight.Insert(o);

            a = (Pol_User)Pol_User.Select("edmin");
            b = (Pol_Right)Pol_Right.Select("SKG.DXF.Home.Catalog.FrmPol_Right");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_UserRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("SKG.DXF.Home.Catalog.FrmPol_Role");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_UserRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("SKG.DXF.Home.Catalog.FrmPol_User");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_UserRight.Insert(o);
        }

        /// <summary>
        /// Pol_UserRole table
        /// </summary>
        void CreatePol_UserRole()
        {
            if (Pol_UserRole.Count() > 0) return;

            var a = (Pol_Role)Pol_Role.Select("CV");
            var b = (Pol_User)Pol_User.Select("nvt");
            var o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);
            b = (Pol_User)Pol_User.Select("cv");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);

            a = (Pol_Role)Pol_Role.Select("CR");
            b = (Pol_User)Pol_User.Select("ntt");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);
            b = (Pol_User)Pol_User.Select("cr");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);

            b = (Pol_User)Pol_User.Select("nvl");
            a = (Pol_Role)Pol_Role.Select("ND");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);

            b = (Pol_User)Pol_User.Select("admin");
            a = (Pol_Role)Pol_Role.Select("QT");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);

            b = (Pol_User)Pol_User.Select("kt");
            a = (Pol_Role)Pol_Role.Select("TK");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);
        }

        /// <summary>
        /// Pol_RoleRight table
        /// </summary>
        void CreatePol_RoleRight()
        {
            if (Pol_RoleRight.Count() > 0) return;

            var a = (Pol_Role)Pol_Role.Select("QT");
            var b = (Pol_Right)Pol_Right.Select("SKG.DXF.Home.Catalog.FrmPol_Action");
            var o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("SKG.DXF.Home.Catalog.FrmPol_Right");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("SKG.DXF.Home.Catalog.FrmPol_Role");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("SKG.DXF.Home.Catalog.FrmPol_User");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("SKG.DXF.Home.Catalog.FrmPol_Lang");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("SKG.DXF.Home.Grant.FrmPol_UserRight");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("SKG.DXF.Home.Grant.FrmPol_RoleRight");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("SKG.DXF.Home.Grant.FrmPol_UserRole");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true, Default = true };
            Pol_RoleRight.Insert(o);
        }
        #endregion

        /// <summary>
        /// Delete old all
        /// </summary>
        protected virtual void DeleteAll()
        {
            Pol_Lang.Delete();
            Pol_RoleRight.Delete();
            Pol_UserRole.Delete();
            Pol_UserRight.Delete();
            Pol_Role.Delete();
            Pol_Right.Delete();
            Pol_Action.Delete();
        }

        /// <summary>
        /// Create new all
        /// </summary>
        protected virtual void CreateAll()
        {
            CreatePol_Action();
            CreatePol_Right();
            CreatePol_Role();
            CreatePol_User();
            CreatePol_UserRight();
            CreatePol_UserRole();
            CreatePol_RoleRight();
            CreatePol_Lang();
        }
    }
}