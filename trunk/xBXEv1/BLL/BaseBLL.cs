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
        public static Tra_GroupBLL _tra_GroupBLL = new Tra_GroupBLL();

        #region Insert template data
        static void CreatePol_Right()
        {
            if (_pol_RightBLL.Count() > 0) return;

            var o = new Pol_Right() { Name = "Thêm", Descript = "Có quyền thêm dữ liệu" };
            _pol_RightBLL.Insert(o);

            o = new Pol_Right() { Name = "Sửa", Descript = "Có quyền sửa dữ liệu" };
            _pol_RightBLL.Insert(o);

            o = new Pol_Right() { Name = "Xoá", Descript = "Có quyền xoá dữ liệu" };
            _pol_RightBLL.Insert(o);

            o = new Pol_Right() { Name = "Truy vấn", Descript = "Có quyền truy vấn dữ liệu" };
            _pol_RightBLL.Insert(o);

            o = new Pol_Right() { Name = "In ấn", Descript = "Có quyền in ấn" };
            _pol_RightBLL.Insert(o);

            o = new Pol_Right() { Name = "Toàn quyền", Descript = "Có tất cả các quyền" };
            _pol_RightBLL.Insert(o);

            o = new Pol_Right() { Name = "Không quyền", Descript = "Không có quyền nào cả" };
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
        }

        static void CreateTra_Group()
        {
            if (_tra_GroupBLL.Count() > 0) return;
        }
        #endregion

        #region Delete all template data
        static void DeletePol_Right()
        {
            var tbl = _pol_RightBLL.Select();
            foreach (DataRow row in tbl.Rows)
                _pol_RightBLL.Delete((Guid)row["Id"]);
        }

        static void DeletePol_Role()
        {
            var tbl = _pol_RoleBLL.Select();
            foreach (DataRow row in tbl.Rows)
                _pol_RoleBLL.Delete((Guid)row["Id"]);
        }

        static void DeletePol_User()
        {
            var tbl = _pol_UserBLL.Select();
            foreach (DataRow row in tbl.Rows)
                _pol_UserBLL.Delete((Guid)row["Id"]);
        }

        static void DeleteTra_Group()
        {
            var tbl = _tra_GroupBLL.Select();
            foreach (DataRow row in tbl.Rows)
                _tra_GroupBLL.Delete((Guid)row["Id"]);
        }
        #endregion

        public static void CreateData(bool isDeleteData = false)
        {
            if (isDeleteData)
            {
                DeletePol_Right();
                DeletePol_Role();
                DeletePol_User();
                DeleteTra_Group();
            }

            CreatePol_Right();
            CreatePol_Role();
            CreatePol_User();
            CreateTra_Group();
        }
    }
}