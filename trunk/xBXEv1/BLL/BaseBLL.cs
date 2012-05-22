using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
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

        static void CreateDataPol_Right()
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

        static void CreateDataPol_Role()
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

        static void CreateDataPol_User()
        {
            if (_pol_UserBLL.Count() > 0) return;

            var o = new Pol_User() { Acc = "nvt", Pass = "nvt", Name = "Nguyễn Văn Toàn", Birth = new DateTime(1988, 1, 5), Address = "26A/3 Hoà Tân, Tân Hoà, Lai Vung, Đồng Tháp", Phone = "+841645 515 010" };
            _pol_UserBLL.Insert(o);
        }

        static void CreateDataTra_Group()
        {
            if (_tra_GroupBLL.Count() > 0) return;
        }

        public static void CreateData()
        {
            CreateDataPol_Right();
            CreateDataPol_Role();
            CreateDataPol_User();
            CreateDataTra_Group();
        }
    }
}