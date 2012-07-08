using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.BLL
{
    using UTL.Plugin;
    using DAL.Entities;
    using System.Data;

    /// <summary>
    /// Lớp nghiệp vụ cơ sở của Bussiness Logic Layer (BLL), các luồng xử lí dữ liệu sử dụng tại đây
    /// </summary>
    public sealed class BaseBLL
    {
        #region Các thuộc tính truy cập cơ sở dữ liệu
        /// <summary>
        /// Truy cập cơ sở dữ liệu bảng Pol_Action: danh sách các chức năng trên form - thêm, xoá, sửa, truy vấn, 
        /// in ấn, truy cập, hiện khi đăng nhập, ...
        /// </summary>
        public Pol_ActionBLL Pol_Action { set; get; }

        /// <summary>
        /// Truy cập cơ sở dữ liệu bảng Pol_Right: danh mục form.
        /// </summary>
        public Pol_RightBLL Pol_Right { set; get; }

        /// <summary>
        /// Truy cập cơ sở dữ liệu bảng Pol_Role: danh mục nhóm quyền. 
        /// </summary>
        public Pol_RoleBLL Pol_Role { set; get; }

        /// <summary>
        /// Truy cập cơ sở dữ liệu bảng Pol_User: danh sách người dùng.
        /// </summary>
        public Pol_UserBLL Pol_User { set; get; }

        /// <summary>
        /// Truy cập cơ sở dữ liệu bảng Pol_UserRight: quyền người dùng - phân quyền trên từng form theo người dùng.
        /// </summary>
        public Pol_UserRightBLL Pol_UserRight { set; get; }

        /// <summary>
        /// Truy cập cơ sở dữ liệu bảng Pol_UserRole - người dùng thuộc nhóm quyền.
        /// </summary>
        public Pol_UserRoleBLL Pol_UserRole { set; get; }

        /// <summary>
        /// Truy cập cơ sở dữ liệu bảng Pol_RoleRight: nhóm quyền - phân quyền trên từng form theo nhóm quyền.
        /// </summary>
        public Pol_RoleRightBLL Pol_RoleRight { set; get; }

        /// <summary>
        /// Truy cập cơ sở dữ liệu bảng Pol_Menu: danh sách menu.
        /// </summary>
        public Pol_MenuBLL Pol_Menu { set; get; }
        #endregion

        #region Các phương thức tĩnh
        /// <summary>
        /// Tự động tạo dữ liễu mẫu
        /// </summary>
        /// <param name="isDelete"></param>
        public static void CreateData(bool isDelete = false)
        {
            var bll = new BaseBLL();
            if (isDelete) bll.DeleteAll();
            if (bll.Pol_User.Count() > 0) return;
            bll.CreateAll();
        }

        /// <summary>
        /// Check database exists
        /// </summary>
        /// <returns>Exists or not exists</returns>
        public static bool CheckDb()
        {
            var bll = new BaseBLL();
            if (bll.Pol_User.Count() > 0) return true;
            return false;
        }
        #endregion

        /// <summary>
        /// Khởi tạo các thuộc tính truy cập cơ sở dữ liệu
        /// </summary>
        public BaseBLL()
        {
            Pol_Action = new Pol_ActionBLL();
            Pol_Right = new Pol_RightBLL();
            Pol_Role = new Pol_RoleBLL();
            Pol_User = new Pol_UserBLL();
            Pol_UserRight = new Pol_UserRightBLL();
            Pol_UserRole = new Pol_UserRoleBLL();
            Pol_RoleRight = new Pol_RoleRightBLL();
            Pol_Menu = new Pol_MenuBLL();
        }

        #region Tạo dữ liệu mẫu
        /// <summary>
        /// Tạo dữ liệu mẫu bảng Pol_Action
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
        /// Tạo dữ liệu mẫu bảng Pol_Right
        /// </summary>
        void CreatePol_Right()
        {
            if (Pol_Right.Count() > 0) return;

            var o = new Pol_Right() { Code = "FrmPol_Right", Name = "Chức năng", Descript = "Danh mục chức năng" };
            Pol_Right.Insert(o);
            o = new Pol_Right() { Code = "FrmPol_Role", Name = "Nhóm quyền", Descript = "Danh mục nhóm quyền" };
            Pol_Right.Insert(o);
            o = new Pol_Right() { Code = "FrmPol_User", Name = "Người dùng", Descript = "Danh mục người dùng" };
            Pol_Right.Insert(o);
            o = new Pol_Right() { Code = "FrmPol_UserRight", Name = "Quyền người sử dụng", Descript = "Form quyền người sử dụng" };
            Pol_Right.Insert(o);
            o = new Pol_Right() { Code = "FrmPol_RoleRight", Name = "Nhóm quyền người dùng", Descript = "Form nhóm quyền người dùng" };
            Pol_Right.Insert(o);
            o = new Pol_Right() { Code = "FrmPol_UserRole", Name = "Phân quyền cho nhóm người", Descript = "Form phân quyền cho nhóm người" };
            Pol_Right.Insert(o);

            o = new Pol_Right() { Code = "FrmTra_Group", Name = "Nhóm xe", Descript = "Danh mục nhóm xe" };
            Pol_Right.Insert(o);
            o = new Pol_Right() { Code = "FrmTra_Kind", Name = "Loại xe", Descript = "Danh mục loại xe" };
            Pol_Right.Insert(o);
            o = new Pol_Right() { Code = "FrmTra_Vehicle", Name = "Danh sách xe", Descript = "Danh sách xe" };
            Pol_Right.Insert(o);

            o = new Pol_Right() { Code = "FrmGateIn", Name = "Cổng vào", Descript = "Form cổng vào" };
            Pol_Right.Insert(o);
            o = new Pol_Right() { Code = "FrmGateOut", Name = "Cổng ra", Descript = "Form cổng ra" };
            Pol_Right.Insert(o);
            o = new Pol_Right() { Code = "FrmInDepot", Name = "Xe trong bến", Descript = "Form xe trong bến" };
            Pol_Right.Insert(o);
            o = new Pol_Right() { Code = "FrmSales", Name = "Doanh thu", Descript = "Form doanh thu" };
            Pol_Right.Insert(o);
            o = new Pol_Right() { Code = "FrmShowPrint", Name = "In thống kê", Descript = "Form in thống kê" };
            Pol_Right.Insert(o);
        }

        /// <summary>
        /// Tạo dữ liệu mẫu bảng Pol_Role
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
        /// Tạo dữ liệu mẫu bảng Pol_User
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
        /// Tạo dữ liệu mẫu bảng Pol_UserRight
        /// </summary>
        void CreatePol_UserRight()
        {
            if (Pol_UserRight.Count() > 0) return;

            var a = (Pol_User)Pol_User.Select("xyz");
            var b = (Pol_Right)Pol_Right.Select("FrmPol_Right");
            var o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_UserRight.Insert(o);

            a = (Pol_User)Pol_User.Select("edmin");
            b = (Pol_Right)Pol_Right.Select("FrmPol_Right");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_UserRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmPol_Role");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_UserRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmPol_User");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_UserRight.Insert(o);

            b = (Pol_Right)Pol_Right.Select("FrmTra_Group");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_UserRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmTra_Kind");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_UserRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmTra_Vehicle");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_UserRight.Insert(o);

            b = (Pol_Right)Pol_Right.Select("FrmGateOut");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true, Default = true };
            Pol_UserRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmGateIn");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_UserRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmInDepot");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_UserRight.Insert(o);
        }

        /// <summary>
        /// Tạo dữ liệu mẫu bảng Pol_UserRole
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
        /// Tạo dữ liệu mẫu bảng Pol_RoleRight
        /// </summary>
        void CreatePol_RoleRight()
        {
            if (Pol_RoleRight.Count() > 0) return;

            var a = (Pol_Role)Pol_Role.Select("CV");
            var b = (Pol_Right)Pol_Right.Select("FrmGateIn");
            var o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true, Default = true };
            Pol_RoleRight.Insert(o);

            a = (Pol_Role)Pol_Role.Select("CR");
            b = (Pol_Right)Pol_Right.Select("FrmGateOut");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true, Print = true, Default = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmShowPrint");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            Pol_RoleRight.Insert(o);

            a = (Pol_Role)Pol_Role.Select("QT");
            b = (Pol_Right)Pol_Right.Select("FrmPol_Right");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmPol_Role");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmPol_User");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmPol_UserRight");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmPol_RoleRight");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmPol_UserRole");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true, Default = true };
            Pol_RoleRight.Insert(o);

            b = (Pol_Right)Pol_Right.Select("FrmTra_Group");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmTra_Kind");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmTra_Vehicle");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);

            b = (Pol_Right)Pol_Right.Select("FrmGateIn");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmGateOut");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true, Print = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmInDepot");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmSales");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true, Print = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmShowPrint");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            Pol_RoleRight.Insert(o);

            a = (Pol_Role)Pol_Role.Select("TK");
            b = (Pol_Right)Pol_Right.Select("FrmSales");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = true, Edit = true, Delete = true, Access = true, Print = true, Default = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmShowPrint");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Access = true };
            Pol_RoleRight.Insert(o);
        }

        /// <summary>
        /// Tạo dữ liệu mẫu bảng Pol_Menu
        /// </summary>
        void CreatePol_Menu()
        {
            var a = new Services();
            var b = a.GetPlugins();
            var c = Services.GetMenu(b);
        }
        #endregion

        /// <summary>
        /// Xoá tất cả
        /// </summary>
        void DeleteAll()
        {
            Pol_RoleRight.Delete();
            Pol_UserRole.Delete();
            Pol_UserRight.Delete();
            Pol_Role.Delete();
            Pol_Right.Delete();
            Pol_Action.Delete();
            Pol_User.Delete();
            Pol_Menu.Delete();
        }

        /// <summary>
        /// Tạo mới tất cả
        /// </summary>
        void CreateAll()
        {
            CreatePol_Action();
            CreatePol_Right();
            CreatePol_Role();
            CreatePol_User();
            CreatePol_UserRight();
            CreatePol_UserRole();
            CreatePol_RoleRight();
            CreatePol_Menu();
        }
    }
}