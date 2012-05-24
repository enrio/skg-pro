using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    using System.Data;
    using DAL.Entities;

    /// <summary>
    /// Base static class Bussiness Logic Layer
    /// </summary>
    public static class BaseBLL
    {
        public static Pol_ActionBLL _pol_ActionBLL = new Pol_ActionBLL();
        public static Pol_RightBLL _pol_RightBLL = new Pol_RightBLL();
        public static Pol_RoleBLL _pol_RoleBLL = new Pol_RoleBLL();
        public static Pol_UserBLL _pol_UserBLL = new Pol_UserBLL();
        public static Pol_UserRightBLL _pol_UserRightBLL = new Pol_UserRightBLL();
        public static Pol_UserRoleBLL _pol_UserRoleBLL = new Pol_UserRoleBLL();
        public static Pol_RoleRightBLL _pol_RoleRightBLL = new Pol_RoleRightBLL();

        public static Tra_GroupBLL _tra_GroupBLL = new Tra_GroupBLL();
        public static Tra_KindBLL _tra_KindBLL = new Tra_KindBLL();
        public static Tra_VehicleBLL _tra_VehicleBLL = new Tra_VehicleBLL();
        public static Tra_DetailBLL _tra_DetailBLL = new Tra_DetailBLL();

        #region Insert template data
        static void CreatePol_Action()
        {
            if (_pol_ActionBLL.Count() > 0) return;

            var o = new Pol_Action() { Code = "Add", Name = "Thêm", Descript = "Thêm dữ liệu", Order = 0 };
            _pol_ActionBLL.Insert(o);
            o = new Pol_Action() { Code = "Edit", Name = "Sửa", Descript = "Sửa dữ liệu", Order = 1 };
            _pol_ActionBLL.Insert(o);
            o = new Pol_Action() { Code = "Delete", Name = "Xoá", Descript = "Xoá dữ liệu", Order = 2 };
            _pol_ActionBLL.Insert(o);
            o = new Pol_Action() { Code = "Query", Name = "Truy vấn", Descript = "Truy vấn dữ liệu", Order = 3 };
            _pol_ActionBLL.Insert(o);
            o = new Pol_Action() { Code = "Print", Name = "In ấn", Descript = "In ấn dữ liệu", Order = 4 };
            _pol_ActionBLL.Insert(o);
            o = new Pol_Action() { Code = "Full", Name = "Tất cả", Descript = "Có tất cả quyền", Order = 5 };
            _pol_ActionBLL.Insert(o);
            o = new Pol_Action() { Code = "None", Name = "Không có", Descript = "Không có quyền", Order = 6 };
            _pol_ActionBLL.Insert(o);
        }

        static void CreatePol_Right()
        {
            if (_pol_RightBLL.Count() > 0) return;

            var o = new Pol_Right() { Code = "Catalog", Name = "Danh mục", Descript = "Nhóm form danh mục" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Code = "FrmBase", Name = "Nhập liệu", Descript = "Tất cả form nhập liệu" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Code = "FrmPol_Right", Name = "Quyền hạn", Descript = "Form danh mục quyền hạn" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Code = "FrmPol_Role", Name = "Vai trò", Descript = "Form danh mục vai trò" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Code = "FrmPol_User", Name = "Người dùng", Descript = "Form người dùng" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Code = "rbpMain", Name = "Trang chính", Descript = "Menu trang chính" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Code = "rbpCatalog", Name = "Danh mục", Descript = "Menu danh mục" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Code = "rbpManage", Name = "Quản lí", Descript = "Menu quản lí" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Code = "rbpHelp", Name = "Trợ giúp", Descript = "Menu trợ giúp" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Code = "bbiPol_Right", Name = "Quyền hạn", Descript = "Menu quyền hạn" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Code = "bbiPol_Role", Name = "Vai trò", Descript = "Menu danh mục vai trò" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Code = "bbiPol_User", Name = "Người dùng", Descript = "Menu danh mục người dùng" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Code = "bbiPol_UserRight", Name = "Người dùng", Descript = "Menu phân quyền người dùng" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Code = "bbiPol_RoleRight", Name = "Nhóm người dùng", Descript = "Menu phân quyền nhóm người dùng" };
            _pol_RightBLL.Insert(o);
        }

        static void CreatePol_Role()
        {
            if (_pol_RoleBLL.Count() > 0) return;

            var o = new Pol_Role() { Code = "CV", Name = "Cổng vào", Descript = "Có vai trò ở cổng vào" };
            _pol_RoleBLL.Insert(o);
            o = new Pol_Role() { Code = "CR", Name = "Cổng ra", Descript = "Có vai trò ở cổng ra" };
            _pol_RoleBLL.Insert(o);
            o = new Pol_Role() { Code = "ND", Name = "Người dùng", Descript = "Có vai trò ở cổng vào và ra" };
            _pol_RoleBLL.Insert(o);
            o = new Pol_Role() { Code = "QL", Name = "Quản lí", Descript = "Có vai trò quản lí người dùng, nhóm, loại, xe" };
            _pol_RoleBLL.Insert(o);
            o = new Pol_Role() { Code = "QT", Name = "Quản trị", Descript = "Có tất cả vai trò" };
            _pol_RoleBLL.Insert(o);
            o = new Pol_Role() { Code = "TK", Name = "Thống kê", Descript = "Xem và in ấn các báo cáo, thống kê" };
            _pol_RoleBLL.Insert(o);
        }

        static void CreatePol_User()
        {
            if (_pol_UserBLL.Count() > 0) return;

            var o = new Pol_User() { Acc = "nvt", Pass = "nvt", Name = "Nguyễn Văn Toàn", Birth = new DateTime(1988, 1, 5), Address = "26A/3 Hoà Tân, Tân Hoà, Lai Vung, Đồng Tháp", Phone = "+841645 515 010" };
            _pol_UserBLL.Insert(o);
            o = new Pol_User() { Acc = "ntt", Pass = "ntt", Name = "Nguyễn Thị Thuy Thuỷ", Birth = new DateTime(1991, 1, 5), Address = "26A/3 Hoà Tân, Tân Hoà, Lai Vung, Đồng Tháp", Phone = "+841654 015 046" };
            _pol_UserBLL.Insert(o);
            o = new Pol_User() { Acc = "nvl", Pass = "nvl", Name = "Nguyễn Văn Lợi", Birth = new DateTime(1992, 12, 12), Address = "26A/3 Hoà Tân, Tân Hoà, Lai Vung, Đồng Tháp", Phone = "+841645 800 000" };
            _pol_UserBLL.Insert(o);
            o = new Pol_User() { Acc = "cr", Pass = "@123456", Name = "Nguyễn Cổng Ra", Birth = new DateTime(1980, 12, 12), Address = "26A/3 Đường 30/4, F. Xuân Khánh, Q. Ninh Kiều, TP. Cần Thơ", Phone = "+841645 888 000" };
            _pol_UserBLL.Insert(o);
            o = new Pol_User() { Acc = "cv", Pass = "@123456", Name = "Nguyễn Cổng Vào", Birth = new DateTime(1980, 12, 12), Address = "143 Đường 3/2, F. Xuân Khánh, Q. Ninh Kiều, TP. Cần Thơ", Phone = "+841645 888 123" };
            _pol_UserBLL.Insert(o);
            o = new Pol_User() { Acc = "kt", Pass = "@qwerty", Name = "Kế Văn Toán", Birth = new DateTime(1982, 7, 2), Address = "143 Đường 3/2, F. Xuân Khánh, Q. Ninh Kiều, TP. Cần Thơ", Phone = "+841665 696 123" };
            _pol_UserBLL.Insert(o);
            o = new Pol_User() { Acc = "xyz", Pass = "xyz", Name = "Không Văn Biết", Birth = new DateTime(1988, 1, 5), Address = "Sao Hoả, Hệ Mặt Trời", Phone = "+841645 999 666" };
            _pol_UserBLL.Insert(o);
        }

        static void CreatePol_UserRight()
        {
            if (_pol_UserRightBLL.Count() > 0) return;
        }

        static void CreatePol_UserRole()
        {
            if (_pol_UserRoleBLL.Count() > 0) return;

            var a = (Pol_User)_pol_UserBLL.Select("nvt");
            var b = (Pol_Role)_pol_RoleBLL.Select("CV");
            var o = new Pol_UserRole() { Pol_UserId = a.Id, Pol_RoleId = b.Id, Add = false, Edit = false, Delete = false, Query = false, Print = false, Full = true, None = false };
            _pol_UserRoleBLL.Insert(o);

            a = (Pol_User)_pol_UserBLL.Select("ntt");
            b = (Pol_Role)_pol_RoleBLL.Select("CV");
            o = new Pol_UserRole() { Pol_UserId = a.Id, Pol_RoleId = b.Id, Add = false, Edit = false, Delete = false, Query = false, Print = false, Full = true, None = false };
            _pol_UserRoleBLL.Insert(o);
        }

        static void CreatePol_RoleRight()
        {
            if (_pol_RoleRightBLL.Count() > 0) return;

            var a = (Pol_Role)_pol_RoleBLL.Select("CV");
            var b = (Pol_Right)_pol_RightBLL.Select("Catalog");
            var o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = false, Edit = false, Delete = false, Query = false, Print = false, Full = true, None = false };
            _pol_RoleRightBLL.Insert(o);

            a = (Pol_Role)_pol_RoleBLL.Select("CR");
            b = (Pol_Right)_pol_RightBLL.Select("Catalog");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Add = false, Edit = false, Delete = false, Query = false, Print = false, Full = true, None = false };
            _pol_RoleRightBLL.Insert(o);
        }

        static void CreateTra_Group()
        {
            if (_tra_GroupBLL.Count() > 0) return;

            var o = new Tra_Group() { Code = "A", Name = "Xe tải lưu đậu & vãng lai", Descript = "", Order = 0 };
            _pol_ActionBLL.Insert(o);
            o = new Tra_Group() { Code = "B", Name = "Xe khách lưu đậu ngày", Descript = "Cứ 24 giờ tính 01 ngày", Order = 1 };
            _pol_ActionBLL.Insert(o);
            o = new Tra_Group() { Code = "C", Name = "Taxi vãng lai", Descript = "", Order = 2 };
            _pol_ActionBLL.Insert(o);
            o = new Tra_Group() { Code = "D", Name = "Xe ba bánh", Descript = "", Order = 3 };
            _pol_ActionBLL.Insert(o);
            o = new Tra_Group() { Code = "E", Name = "Xe khách vãng lai, quá cảnh, trung chuyển", Descript = "Trong vòng 60 phút", Order = 4 };
            _pol_ActionBLL.Insert(o);
        }

        static void CreateTra_Kind()
        {
            if (_tra_KindBLL.Count() > 0) return;
        }

        static void CreateTra_Vehicle()
        {
            if (_tra_VehicleBLL.Count() > 0) return;
        }

        static void CreateTra_Detail()
        {
            if (_tra_DetailBLL.Count() > 0) return;
        }
        #endregion

        public static void CreateData(bool isDeleteData = false)
        {
            if (isDeleteData)
            {
                _pol_ActionBLL.Delete();
                _pol_RightBLL.Delete();
                _pol_RoleBLL.Delete();
                _pol_UserBLL.Delete();
                _pol_UserRightBLL.Delete();
                _pol_UserRoleBLL.Delete();
                _pol_RoleRightBLL.Delete();

                _tra_GroupBLL.Delete();
                _tra_KindBLL.Delete();
                _tra_VehicleBLL.Delete();
                _tra_DetailBLL.Delete();
            }

            CreatePol_Action();
            CreatePol_Right();
            CreatePol_Role();
            CreatePol_User();
            CreatePol_UserRight();
            CreatePol_UserRole();
            CreatePol_RoleRight();

            CreateTra_Group();
            CreateTra_Kind();
            CreateTra_Vehicle();
            CreateTra_Detail();
        }
    }
}