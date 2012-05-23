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
        public static Pol_RightBLL _pol_RightBLL = new Pol_RightBLL();
        public static Pol_RoleBLL _pol_RoleBLL = new Pol_RoleBLL();
        public static Pol_UserBLL _pol_UserBLL = new Pol_UserBLL();
        public static Pol_UserRightBLL _pol_UserRightBLL = new Pol_UserRightBLL();
        public static Pol_UserRoleBLL _pol_UserRoleBLL = new Pol_UserRoleBLL();
        public static Pol_RoleRightBLL _pol_RoleRightBLL = new Pol_RoleRightBLL();
        public static Tra_GroupBLL _tra_GroupBLL = new Tra_GroupBLL();

        #region Insert template data
        static void CreatePol_Right()
        {
            if (_pol_RightBLL.Count() > 0) return;

            var o = new Pol_Right() { Name = "Catalog", Descript = "Nhóm form danh mục" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Name = "FrmBase", Descript = "Form nhập liệu gốc" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Name = "FrmPol_Right", Descript = "Form danh mục quyền hạn" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Name = "FrmPol_Role", Descript = "Form danh mục vai trò" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Name = "FrmPol_User", Descript = "Form người dùng" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Name = "rbpMain", Descript = "Menu trang chính" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Name = "rbpCatalog", Descript = "Menu danh mục" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Name = "rbpManage", Descript = "Menu quản lí" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Name = "rbpHelp", Descript = "Menu trợ giúp" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Name = "bbiPol_Right", Descript = "Menu quyền hạn" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Name = "bbiPol_Role", Descript = "Menu vai trò" };
            _pol_RightBLL.Insert(o);
            o = new Pol_Right() { Name = "bbiPol_User", Descript = "Menu người dùng" };
            _pol_RightBLL.Insert(o);
        }

        static void CreatePol_Role()
        {
            if (_pol_RoleBLL.Count() > 0) return;

            var o = new Pol_Role() { Name = "Cổng vào", Descript = "Có vai trò ở cổng vào" };
            _pol_RoleBLL.Insert(o);
            o = new Pol_Role() { Name = "Cổng ra", Descript = "Có vai trò ở cổng ra" };
            _pol_RoleBLL.Insert(o);
            o = new Pol_Role() { Name = "Người dùng", Descript = "Có vai trò ở cổng vào và ra" };
            _pol_RoleBLL.Insert(o);
            o = new Pol_Role() { Name = "Quản lí", Descript = "Có vai trò quản lí người dùng, nhóm, loại, xe" };
            _pol_RoleBLL.Insert(o);
            o = new Pol_Role() { Name = "Quản trị", Descript = "Có tất cả vai trò" };
            _pol_RoleBLL.Insert(o);
            o = new Pol_Role() { Name = "Thống kê", Descript = "Xem và in ấn các báo cáo, thống kê" };
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

            var o = new Pol_UserRight() { Pol_UserId = Guid.NewGuid(), Pol_RightId = Guid.NewGuid(), Add = false, Edit = false, Delete = false, Query = false, Print = false, Full = true, None = false };
        }

        static void CreatePol_UserRole()
        {
            if (_pol_UserRoleBLL.Count() > 0) return;
        }

        static void CreatePol_RoleRight()
        {
            if (_pol_RoleRightBLL.Count() > 0) return;
        }

        static void CreateTra_Group()
        {
            if (_tra_GroupBLL.Count() > 0) return;
        }
        #endregion

        public static void CreateData(bool isDeleteData = false)
        {
            if (isDeleteData)
            {
                _pol_RightBLL.Delete();
                _pol_RoleBLL.Delete();
                _pol_UserBLL.Delete();
                _pol_UserRightBLL.Delete();
                _pol_UserRoleBLL.Delete();
                _pol_RoleRightBLL.Delete();
                _tra_GroupBLL.Delete();
            }

            CreatePol_Right();
            CreatePol_Role();
            CreatePol_User();
            CreatePol_UserRight();
            CreatePol_UserRole();
            CreatePol_RoleRight();
            CreateTra_Group();
        }
    }
}