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

namespace SKG.DXF
{
    using BLL;
    using SKG.Data;
    using System.Data;
    using DAL.Entities;

    using System.Windows.Forms;

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
            var file = Application.StartupPath + @"\Import\Sample.xls";
            SqlServer.ImportFromExcel(file, Global.Connection.ConnectionString, typeof(Pol_Dictionary).Name);
            SqlServer.ImportFromExcel(file, Global.Connection.ConnectionString, typeof(Tra_Vehicle).Name);
            bll.CreateAll();
        }
        #endregion

        #region Create data sample
        /// <summary>
        /// Pol_Dictionary table
        /// </summary>
        void CreatePol_Dictionary()
        {
            if (Pol_Dictionary.Count() > 0) return;

            #region List of languages
            var o = new Pol_Dictionary() { Type = Global.STR_LANG, Code = "1", Text = "ZngIoz", Note = "Tiếng ZnG", Order = 0 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_LANG, Code = "2", Text = "Vietnamese", Note = "Tiếng Việt", Order = 1 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_LANG, Code = "3", Text = "English", Note = "Tiếng Anh", Order = 2 };
            Pol_Dictionary.Insert(o);
            #endregion

            #region List of buttons
            o = new Pol_Dictionary() { Type = Global.STR_BUTTON, Code = "Add", Text = "Thêm", Note = "Cho phép thêm dữ liệu", Order = 0 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_BUTTON, Code = "Edit", Text = "Sửa", Note = "Cho phép sửa dữ liệu", Order = 1 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_BUTTON, Code = "Delete", Text = "Xoá", Note = "Cho phép xoá dữ liệu", Order = 2 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_BUTTON, Code = "Default", Text = "Tự mở", Note = "Cho phép tự động hiện form", Order = 3 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_BUTTON, Code = "Print", Text = "In ấn", Note = "Cho phép in ấn dữ liệu", Order = 4 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_BUTTON, Code = "Access", Text = "Truy cập", Note = "Cho truy cập menu, form (menuz)", Order = 5 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_BUTTON, Code = "Full", Text = "Tất cả", Note = "Có tất cả quyền", Order = 6 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_BUTTON, Code = "None", Text = "Không có", Note = "Không có quyền", Order = 7 };
            Pol_Dictionary.Insert(o);
            #endregion

            CreateRoles();
            CreateRights();

            #region List of transport
            CreateRegion();
            CreateArea();
            CreateProvince();
            CreateGroup();
            #endregion
        }

        /// <summary>
        /// Create list of roles
        /// </summary>
        void CreateRoles()
        {
            var o = new Pol_Dictionary() { Type = Global.STR_ROLE, Code = "CV", Text = "Cổng vào", Note = "Có vai trò ở cổng vào" };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_ROLE, Code = "CR", Text = "Cổng ra", Note = "Có vai trò ở cổng ra" };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_ROLE, Code = "ND", Text = "Người dùng", Note = "Có vai trò cơ bản nhất" };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_ROLE, Code = "QL", Text = "Quản lí", Note = "Có vai trò quản lí người dùng, nhóm, loại, xe" };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_ROLE, Code = "QT", Text = "Quản trị", Note = "Có tất cả vai trò" };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_ROLE, Code = "TK", Text = "Thống kê", Note = "Xem và in ấn các báo cáo, thống kê" };
            Pol_Dictionary.Insert(o);
        }

        /// <summary>
        /// Create list of rights
        /// </summary>
        void CreateRights()
        {
            var a = new Services();
            var b = a.GetPlugins();
            var c = Services.GetMenu(b);
            var l1 = typeof(Home.Level1).Name;
            var l2 = typeof(Home.Sytem.Level2).Name;
            var d1 = new Pol_Dictionary();
            var d2 = new Pol_Dictionary();

            foreach (var i in c)
            {
                if (i.Code.Contains(l1)) // level 1
                {
                    d1 = new Pol_Dictionary() { Type = Global.STR_RIGHT, Code = i.Code, Text = i.Text, Order = i.Order, Show = i.Show };
                    d1 = (Pol_Dictionary)Pol_Dictionary.Insert(d1);
                }
                else if (i.Code.Contains(l2)) // level 2
                {
                    d2 = new Pol_Dictionary() { Type = Global.STR_RIGHT, ParentId = d1.Id, Code = i.Code, Text = i.Text, Order = i.Order, Show = i.Show };
                    d2 = (Pol_Dictionary)Pol_Dictionary.Insert(d2);
                }
                else // level 3
                {
                    var d3 = new Pol_Dictionary() { Type = Global.STR_RIGHT, ParentId = d2.Id, Code = i.Code, Text = i.Text, Order = i.Order, Show = i.Show };
                    d3 = (Pol_Dictionary)Pol_Dictionary.Insert(d3);
                }
            }
        }

        #region List of transport
        /// <summary>
        /// Create list region of Vietnam
        /// </summary>
        void CreateRegion()
        {
            var o = new Pol_Dictionary() { Type = Global.STR_REGION, Code = Global.STR_REGION + "_0", Text = "Miền Bắc", Order = 0 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_REGION, Code = Global.STR_REGION + "_1", Text = "Miền Trung", Order = 1 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_REGION, Code = Global.STR_REGION + "_2", Text = "Miền Nam", Order = 2 };
            Pol_Dictionary.Insert(o);
        }

        /// <summary>
        /// Create list area of Vietnam
        /// </summary>
        void CreateArea()
        {
            var d = (Pol_Dictionary)Pol_Dictionary.Select(Global.STR_REGION + "_0");
            var o = new Pol_Dictionary() { Type = Global.STR_AREA, ParentId = d.Id, Code = Global.STR_AREA + "_0", Text = "ĐB. Sông Hồng", Order = 0 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_AREA, ParentId = d.Id, Code = Global.STR_AREA + "_1", Text = "Đông Bắc Bộ", Order = 1 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_AREA, ParentId = d.Id, Code = Global.STR_AREA + "_2", Text = "Tây Bắc Bộ", Order = 2 };
            Pol_Dictionary.Insert(o);

            d = (Pol_Dictionary)Pol_Dictionary.Select(Global.STR_REGION + "_1");
            o = new Pol_Dictionary() { Type = Global.STR_AREA, ParentId = d.Id, Code = Global.STR_AREA + "_3", Text = "Bắc Trung Bộ", Order = 3 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_AREA, ParentId = d.Id, Code = Global.STR_AREA + "_4", Text = "Nam Trung Bộ", Order = 4 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_AREA, ParentId = d.Id, Code = Global.STR_AREA + "_5", Text = "Tây Nguyên", Order = 5 };
            Pol_Dictionary.Insert(o);

            d = (Pol_Dictionary)Pol_Dictionary.Select(Global.STR_REGION + "_2");
            o = new Pol_Dictionary() { Type = Global.STR_AREA, ParentId = d.Id, Code = Global.STR_AREA + "_6", Text = "Đông Nam Bộ", Order = 6 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_AREA, ParentId = d.Id, Code = Global.STR_AREA + "_7", Text = "ĐB. Sông Cửu Long", Order = 7 };
            Pol_Dictionary.Insert(o);
        }

        /// <summary>
        /// Create list province of Vietnam
        /// </summary>
        void CreateProvince()
        {
            var d = (Pol_Dictionary)Pol_Dictionary.Select(Global.STR_AREA + "_0");
            var o = new Pol_Dictionary() { Type = Global.STR_PROVINCE, ParentId = d.Id, Code = Global.STR_PROVINCE + "_0", Text = "Hà Nội (cũ)", Order = 0 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_PROVINCE, ParentId = d.Id, Code = Global.STR_PROVINCE + "_1", Text = "Hà Nam", Order = 1 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_PROVINCE, ParentId = d.Id, Code = Global.STR_PROVINCE + "_2", Text = "Hà Nội (mở rộng)", Order = 2 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_PROVINCE, ParentId = d.Id, Code = Global.STR_PROVINCE + "_3", Text = "", Order = 3 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_PROVINCE, ParentId = d.Id, Code = Global.STR_PROVINCE + "_4", Text = "", Order = 4 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_PROVINCE, ParentId = d.Id, Code = Global.STR_PROVINCE + "_5", Text = "", Order = 5 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_PROVINCE, ParentId = d.Id, Code = Global.STR_PROVINCE + "_6", Text = "", Order = 6 };
            Pol_Dictionary.Insert(o);
        }

        /// <summary>
        /// Create list group of vehicle
        /// </summary>
        void CreateGroup()
        {
            var o = new Pol_Dictionary() { Type = Global.STR_GROUP, Code = "A", Text = "Xe tải lưu đậu & vãng lai", Note = "", Order = 0 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_GROUP, Code = "B", Text = "Xe khách lưu đậu ngày", Note = "Cứ 24 giờ tính 01 ngày", Order = 1 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_GROUP, Code = "C", Text = "Taxi vãng lai", Note = "", Order = 2 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_GROUP, Code = "D", Text = "Xe ba bánh", Note = "", Order = 3 };
            Pol_Dictionary.Insert(o);
            o = new Pol_Dictionary() { Type = Global.STR_GROUP, Code = "E", Text = "Xe khách vãng lai, quá cảnh, trung chuyển", Note = "Trong vòng 60 phút", Order = 4 };
            Pol_Dictionary.Insert(o);
        }
        #endregion

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
            o = new Pol_User() { Acc = "admin", Pass = "", Name = "Siêu Quản Trị", Birth = new DateTime(1988, 1, 5), Address = "Âm Tàu, Địa Phủ", Phone = "+841699 999 666" };
            Pol_User.Insert(o);
            o = new Pol_User() { Acc = "duylong", Pass = "123456", Name = "Nguyễn Duy Long", Birth = new DateTime(1975, 1, 1), Address = "TP. HCM", Phone = "+841699 999 686", Note = "Giám đốc" };
            Pol_User.Insert(o);
            o = new Pol_User() { Acc = "tranhieu", Pass = "123456", Name = "Trần Hiếu", Birth = new DateTime(1975, 1, 1), Address = "TP. HCM", Phone = "+841699 999 686", Note = "Phó Giám đốc" };
            Pol_User.Insert(o);
        }

        /// <summary>
        /// Pol_UserRight table
        /// </summary>
        void CreatePol_UserRight()
        {
            if (Pol_UserRight.Count() > 0) return;

            //var a = (Pol_User)Pol_User.Select("edmin");
            //var b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Catalog.FrmPol_Role).FullName);
            //var o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            //Pol_UserRight.Insert(o);
            //b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Catalog.FrmPol_User).FullName);
            //o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            //Pol_UserRight.Insert(o);
        }

        /// <summary>
        /// Pol_UserRole table
        /// </summary>
        void CreatePol_UserRole()
        {
            if (Pol_UserRole.Count() > 0) return;

            var a = (Pol_Dictionary)Pol_Dictionary.Select("ND");
            var b = (Pol_User)Pol_User.Select("nvl");
            var o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);
            b = (Pol_User)Pol_User.Select("nvt");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);
            b = (Pol_User)Pol_User.Select("ntt");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);
            b = (Pol_User)Pol_User.Select("admin");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);
            b = (Pol_User)Pol_User.Select("kt");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);
            b = (Pol_User)Pol_User.Select("duylong");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);
            b = (Pol_User)Pol_User.Select("tranhieu");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);
            b = (Pol_User)Pol_User.Select("cv");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);
            b = (Pol_User)Pol_User.Select("cr");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);
            b = (Pol_User)Pol_User.Select("nvl");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);

            a = (Pol_Dictionary)Pol_Dictionary.Select("CV");
            b = (Pol_User)Pol_User.Select("nvt");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);
            b = (Pol_User)Pol_User.Select("cv");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);

            a = (Pol_Dictionary)Pol_Dictionary.Select("CR");
            b = (Pol_User)Pol_User.Select("ntt");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);
            b = (Pol_User)Pol_User.Select("cr");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);

            a = (Pol_Dictionary)Pol_Dictionary.Select("QT");
            b = (Pol_User)Pol_User.Select("admin");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);

            a = (Pol_Dictionary)Pol_Dictionary.Select("TK");
            b = (Pol_User)Pol_User.Select("kt");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);
            b = (Pol_User)Pol_User.Select("duylong");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);
            b = (Pol_User)Pol_User.Select("tranhieu");
            o = new Pol_UserRole() { Pol_UserId = b.Id, Pol_RoleId = a.Id };
            Pol_UserRole.Insert(o);
        }

        /// <summary>
        /// Pol_RoleRight table
        /// </summary>
        void CreatePol_RoleRight()
        {
            if (Pol_RoleRight.Count() > 0) return;

            var a = (Pol_Dictionary)Pol_Dictionary.Select("ND");
            var b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Level1).FullName);
            var o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Catalog.Level2).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = false };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Grant.Level2).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = false };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Sytem.Level2).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            Pol_RoleRight.Insert(o);
            //b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Sytem.FrmPol_Permis).FullName);
            //o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = false };
            //Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Sytem.FrmPol_Close).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Sytem.FrmPol_Exit).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Help.Level1).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Help.Infor.Level2).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Help.Infor.Frm_PolManual).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Help.Util.Level2).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Station.Level1).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Station.Catalog.Level2).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Station.Manage.Level2).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Station.Sumary.Level2).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Station.Manage.FrmTra_InDepot).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            Pol_RoleRight.Insert(o);

            a = (Pol_Dictionary)Pol_Dictionary.Select("QT");
            //b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Catalog.FrmPol_Right).FullName);
            //o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            //Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Catalog.FrmPol_Role).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Catalog.FrmPol_User).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Catalog.FrmPol_Dictionary).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true, Default = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Grant.FrmPol_UserRight).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Grant.FrmPol_RoleRight).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Grant.FrmPol_UserRole).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Catalog.Level2).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Grant.Level2).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            Pol_RoleRight.Insert(o);
            //b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Sytem.FrmPol_Permis).FullName);
            //o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            //Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Home.Sytem.FrmPol_Setting).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Station.Catalog.FrmTra_Group).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Station.Catalog.FrmTra_Kind).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Station.Catalog.FrmTra_Vehicle).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Station.Manage.FrmTra_GateIn).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            //b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Station.Manage.FrmTra_HandIn).FullName);
            //o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            //Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Station.Manage.FrmTra_GateOut).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Station.Sumary.FrmTra_Sales).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true, Print = true };
            Pol_RoleRight.Insert(o);

            a = (Pol_Dictionary)Pol_Dictionary.Select("CV");
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Station.Manage.FrmTra_GateIn).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true, Default = true };
            Pol_RoleRight.Insert(o);
            //b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Station.Manage.FrmTra_HandIn).FullName);
            //o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            //Pol_RoleRight.Insert(o);

            a = (Pol_Dictionary)Pol_Dictionary.Select("CR");
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Station.Manage.FrmTra_GateOut).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true, Default = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Station.Manage.FrmTra_GateIn).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Edit = true, Access = true };
            Pol_RoleRight.Insert(o);

            a = (Pol_Dictionary)Pol_Dictionary.Select("TK");
            b = (Pol_Dictionary)Pol_Dictionary.Select(typeof(SKG.DXF.Station.Sumary.FrmTra_Sales).FullName);
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true, Print = true, Default = true };
            Pol_RoleRight.Insert(o);
        }

        /// <summary>
        /// Tạo dữ liệu mẫu bảng Tra_Kind
        /// </summary>
        void CreateTra_Kind()
        {
            if (Tra_Kind.Count() > 0) return;

            var a = (Pol_Dictionary)Pol_Dictionary.Select("GROUP_0");
            var o = new Tra_Kind() { Code = "KIND_0", GroupId = a.Id, Text = "Miền Bắc", Note = "", Price1 = 5000, Price2 = 6500, Order = 0 };
            Tra_Kind.Insert(o);
            o = new Tra_Kind() { Code = "KIND_1", GroupId = a.Id, Text = "Miền Trung", Note = "", Price1 = 4300, Price2 = 5590, Order = 1 };
            Tra_Kind.Insert(o);
            o = new Tra_Kind() { Code = "KIND_2", GroupId = a.Id, Text = "Miền Nam", Note = "", Price1 = 2900, Price2 = 3770, Order = 2 };
            Tra_Kind.Insert(o);

            a = (Pol_Dictionary)Pol_Dictionary.Select("GROUP_1");
            o = new Tra_Kind() { Code = "KIND_3", GroupId = a.Id, Text = "Xe khách vãng lai, quá cảnh, trung chuyển", Note = "Trong vòng 60 phút", Price1 = 2030, Price2 = 2639, Order = 3 };
            Tra_Kind.Insert(o);
            o = new Tra_Kind() { Code = "KIND_4", GroupId = a.Id, Text = "2,5tấn ≤ tải trọng < 5tấn hoặc dài < 6m", Note = "", Price1 = 15000, Price2 = 25000, Order = 4 };
            Tra_Kind.Insert(o);
            o = new Tra_Kind() { Code = "KIND_5", GroupId = a.Id, Text = "5tấn ≤ tải trọng < 10tấn hoặc 6m ≤ dài < 8m", Note = "", Price1 = 15000, Price2 = 30000, Order = 5 };
            Tra_Kind.Insert(o);
            o = new Tra_Kind() { Code = "KIND_6", GroupId = a.Id, Text = "10tấn ≤ tải trọng < 15tấn hoặc dài ≥ 8m", Note = "", Price1 = 20000, Price2 = 35000, Order = 6 };
            Tra_Kind.Insert(o);
            o = new Tra_Kind() { Code = "KIND_7", GroupId = a.Id, Text = "Container 20feet", Note = "", Price1 = 25000, Price2 = 45000, Order = 7 };
            Tra_Kind.Insert(o);
            o = new Tra_Kind() { Code = "KIND_8", GroupId = a.Id, Text = "Container 40feet", Note = "", Price1 = 30000, Price2 = 60000, Order = 8 };
            Tra_Kind.Insert(o);

            a = (Pol_Dictionary)Pol_Dictionary.Select("GROUP_2");
            o = new Tra_Kind() { Code = "KIND_9", GroupId = a.Id, Text = "Taxi vãng lai", Note = "", Price1 = 8000, Price2 = 8000, Order = 9 };
            Tra_Kind.Insert(o);
            o = new Tra_Kind() { Code = "KIND_10", GroupId = a.Id, Text = "Xe ba bánh", Note = "", Price1 = 5000, Price2 = 5000, Order = 10 };
            Tra_Kind.Insert(o);
            o = new Tra_Kind() { Code = "KIND_11", GroupId = a.Id, Text = "Tải trọng < 2,5tấn", Note = "", Price1 = 10000, Price2 = 20000, Order = 11 };
            Tra_Kind.Insert(o);
        }

        /// <summary>
        /// Tạo dữ liệu mẫu bảng Tra_Vehicle
        /// </summary>
        void CreateTra_Vehicle()
        {
            if (Tra_Vehicle.Count() > 0) return;

            var a = (Tra_Kind)Tra_Kind.Select("KIND_11");
            var o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66F-123.09", Note = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn A", Birth = new DateTime(1980, 1, 1), Address = "Sóc Sơ Bay", Phone = "1800 1090" };
            Tra_Vehicle.Insert(o);
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "65F-888.09", Note = "Xe đen thui", Driver = "Nguyễn Văn Su", Birth = new DateTime(1982, 3, 1), Address = "Tây Sơn, Bình Định", Phone = "1800 6969" };
            Tra_Vehicle.Insert(o);
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "75F-888.09", Note = "Xe đen thui", Driver = "Cao Văn Su", Birth = new DateTime(1988, 3, 1), Address = "Sóc Sơ Bay, Sóc Trăng", Phone = "7718 6969" };
            Tra_Vehicle.Insert(o);
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "95F-888.09", Note = "Xe đen thui", Driver = "Trần Như Nhộng", Birth = new DateTime(1980, 3, 1), Address = "Phong Gió, Quảng Bình", Phone = "1899 6969" };
            Tra_Vehicle.Insert(o);

            a = (Tra_Kind)Tra_Kind.Select("KIND_4");
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66F-123.19", Note = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn B", Birth = new DateTime(1980, 1, 1), Address = "Lấp Dò, Đồng Tháp", Phone = "1800 1091" };
            Tra_Vehicle.Insert(o);
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66E-123.19", Note = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn C", Birth = new DateTime(1980, 1, 2), Address = "Cao Lãnh, Đồng Tháp", Phone = "1801 1791" };
            Tra_Vehicle.Insert(o);

            a = (Tra_Kind)Tra_Kind.Select("KIND_5");
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66C-123.19", Note = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn C", Birth = new DateTime(1980, 1, 3), Address = "Tháp Mười, Đồng Tháp", Phone = "1802 1091" };
            Tra_Vehicle.Insert(o);

            a = (Tra_Kind)Tra_Kind.Select("KIND_6");
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66D-123.19", Note = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn D", Birth = new DateTime(1980, 1, 4), Address = "Thanh Bình, Đồng Tháp", Phone = "1803 1091" };
            Tra_Vehicle.Insert(o);

            a = (Tra_Kind)Tra_Kind.Select("KIND_7");
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66E-123.19", Note = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn E", Birth = new DateTime(1980, 1, 5), Address = "Chợ Lách, Bến Tre", Phone = "1804 1091" };
            Tra_Vehicle.Insert(o);

            a = (Tra_Kind)Tra_Kind.Select("KIND_8");
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66F-123.19", Note = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn F", Birth = new DateTime(1980, 1, 6), Address = "Giồng Trôm, Bến Tre", Phone = "1805 1091" };
            Tra_Vehicle.Insert(o);
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66G-123.19", Note = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn G", Birth = new DateTime(1980, 1, 7), Address = "Trà Cú, Trà Vinh", Phone = "1806 1091" };
            Tra_Vehicle.Insert(o);
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66H-123.19", Note = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn H", Birth = new DateTime(1980, 1, 8), Address = "Mỹ Tho, Tiền Giang", Phone = "1807 1091" };
            Tra_Vehicle.Insert(o);
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66I-123.19", Note = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn I", Birth = new DateTime(1980, 1, 9), Address = "Đông Chu, Liệt Quốc", Phone = "1808 1091" };
            Tra_Vehicle.Insert(o);
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66J-123.19", Note = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn J", Birth = new DateTime(1980, 1, 10), Address = "Vĩnh Châu, Sóc Trăng", Phone = "1809 1091" };
            Tra_Vehicle.Insert(o);
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66K-123.19", Note = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn K", Birth = new DateTime(1980, 1, 11), Address = "Cà Xa, Cà Mau", Phone = "1810 1091" };
            Tra_Vehicle.Insert(o);
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66L-123.19", Note = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn L", Birth = new DateTime(1980, 1, 12), Address = "Ngã Bảy, Hậu Giang", Phone = "1811 1091", Seats = 50 };
            Tra_Vehicle.Insert(o);
        }

        /// <summary>
        /// Tạo dữ liệu mẫu bảng Tra_Detail
        /// </summary>
        void CreateTra_Detail()
        {
            if (Tra_Detail.Count() > 0) return;

            #region Bộ dữ liệu 1
            var tbl = Tra_Vehicle.Select();
            if (tbl == null) return;

            var d = Tra_Vehicle.GetDate();
            var ui = (Pol_User)Pol_User.Select("nvt");
            var uo = (Pol_User)Pol_User.Select("ntt");

            var kj = (Tra_Kind)Tra_Kind.Select("J");
            var kk = (Tra_Kind)Tra_Kind.Select("K");
            var kl = (Tra_Kind)Tra_Kind.Select("L");

            foreach (DataRow r in tbl.Rows)
            {
                var id = (Guid)r["Id"];

                var a = new Random();
                var b = -a.Next();
                var x = (Guid)r["Tra_KindId"];
                var c = (x == kj.Id || x == kk.Id || x == kl.Id) ? b % 3 : b % 49;

                var o = new Tra_Detail() { Pol_UserInId = ui.Id, Tra_VehicleId = id, DateIn = DateTime.Now.AddHours(c) };
                Tra_Detail.Insert(o);

                decimal money = 0;
                int price1 = 0, price2 = 0;
                int day = 0, hour = 0;
                o = new Tra_Detail() { Pol_UserOutId = uo.Id, Tra_VehicleId = id, DateOut = d };

                Tra_Detail.InvoiceOut(o, ref  day, ref  hour, ref  money, ref  price1, ref  price2, true);
            }
            #endregion

            #region Bộ dữ liệu 2
            tbl = Tra_Vehicle.Select(null, 0, 5);
            ui = (Pol_User)Pol_User.Select("cv");
            uo = (Pol_User)Pol_User.Select("cr");

            foreach (DataRow r in tbl.Rows)
            {
                var id = (Guid)r["Id"];

                var a = new Random();
                var b = -a.Next();
                var x = (Guid)r["Tra_KindId"];
                var c = (x == kj.Id || x == kk.Id || x == kl.Id) ? b % 3 : b % 49;

                var o = new Tra_Detail() { Pol_UserInId = ui.Id, Tra_VehicleId = id, DateIn = DateTime.Now.AddHours(c) };
                Tra_Detail.Insert(o);

                decimal money = 0;
                int price1 = 0, price2 = 0;
                int day = 0, hour = 0;
                o = new Tra_Detail() { Pol_UserOutId = uo.Id, Tra_VehicleId = id, DateOut = d };

                Tra_Detail.InvoiceOut(o, ref  day, ref  hour, ref  money, ref  price1, ref  price2, true);
            }
            #endregion
        }
        #endregion

        /// <summary>
        /// Delete old all
        /// </summary>
        protected virtual void DeleteAll()
        {
            Tra_Detail.Delete();
            Tra_Vehicle.Delete();
            Tra_Kind.Delete();
            Pol_RoleRight.Delete();
            Pol_UserRole.Delete();
            Pol_UserRight.Delete();
            Pol_Dictionary.Delete();
            Pol_Dictionary.Delete();
            Pol_Dictionary.Delete();
        }

        /// <summary>
        /// Create new all
        /// </summary>
        protected virtual void CreateAll()
        {
            //CreatePol_Dictionary();
            CreatePol_User();
            CreatePol_UserRight();
            CreatePol_UserRole();
            CreatePol_RoleRight();
            CreateTra_Kind();
            CreateTra_Vehicle();
            //CreateTra_Detail();
        }
    }
}