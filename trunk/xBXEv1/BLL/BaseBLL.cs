using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
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
        /// Truy cập cơ sở dữ liệu bảng Tra_Group: danh mục nhóm xe.
        /// </summary>
        public Tra_GroupBLL Tra_Group { set; get; }

        /// <summary>
        /// Truy cập cơ sở dữ liệu bảng Tra_Kind: danh mục loại xe.
        /// </summary>
        public Tra_KindBLL Tra_Kind { set; get; }

        /// <summary>
        /// Truy cập cơ sở dữ liệu bảng Tra_Vehicle: danh sách xe cộ.
        /// </summary>
        public Tra_VehicleBLL Tra_Vehicle { set; get; }

        /// <summary>
        /// Truy cập cơ sở dữ liệu bảng Tra_Detail: chi tiết xe ra vào, bến.
        /// </summary>
        public Tra_DetailBLL Tra_Detail { set; get; }
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

            Tra_Group = new Tra_GroupBLL();
            Tra_Kind = new Tra_KindBLL();
            Tra_Vehicle = new Tra_VehicleBLL();
            Tra_Detail = new Tra_DetailBLL();
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
            o = new Pol_Action() { Code = "Query", Name = "Truy vấn", Descript = "Cho phép truy vấn dữ liệu", Order = 3 };
            Pol_Action.Insert(o);
            o = new Pol_Action() { Code = "Print", Name = "In ấn", Descript = "Cho phép in ấn dữ liệu", Order = 4 };
            Pol_Action.Insert(o);
            o = new Pol_Action() { Code = "Access", Name = "Truy cập", Descript = "Cho phép hiện form (chức năng) này", Order = 5 };
            Pol_Action.Insert(o);
            o = new Pol_Action() { Code = "Full", Name = "Tất cả", Descript = "Có tất cả quyền", Order = 6 };
            Pol_Action.Insert(o);
            o = new Pol_Action() { Code = "None", Name = "Không có", Descript = "Không có quyền", Order = 7 };
            Pol_Action.Insert(o);
            o = new Pol_Action() { Code = "Default", Name = "Mặc định", Descript = "Hiện sau khi đăng nhập", Order = 8 };
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
            var o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_UserRight.Insert(o);

            a = (Pol_User)Pol_User.Select("edmin");
            b = (Pol_Right)Pol_Right.Select("FrmPol_Right");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_UserRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmPol_Role");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_UserRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmPol_User");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_UserRight.Insert(o);

            b = (Pol_Right)Pol_Right.Select("FrmTra_Group");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_UserRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmTra_Kind");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_UserRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmTra_Vehicle");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_UserRight.Insert(o);

            b = (Pol_Right)Pol_Right.Select("FrmGateOut");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Full = true, Default = true };
            Pol_UserRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmGateIn");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_UserRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmInDepot");
            o = new Pol_UserRight() { Pol_UserId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_UserRight.Insert(o);
        }

        /// <summary>
        /// Tạo dữ liệu mẫu bảng Pol_UserRole
        /// </summary>
        void CreatePol_UserRole()
        {
            if (Pol_UserRole.Count() > 0) return;

            var a = (Pol_User)Pol_User.Select("nvt");
            var b = (Pol_Role)Pol_Role.Select("CV");
            var o = new Pol_UserRole() { Pol_UserId = a.Id, Pol_RoleId = b.Id };
            Pol_UserRole.Insert(o);

            a = (Pol_User)Pol_User.Select("ntt");
            b = (Pol_Role)Pol_Role.Select("CR");
            o = new Pol_UserRole() { Pol_UserId = a.Id, Pol_RoleId = b.Id };
            Pol_UserRole.Insert(o);

            a = (Pol_User)Pol_User.Select("nvl");
            b = (Pol_Role)Pol_Role.Select("ND");
            o = new Pol_UserRole() { Pol_UserId = a.Id, Pol_RoleId = b.Id };
            Pol_UserRole.Insert(o);

            a = (Pol_User)Pol_User.Select("admin");
            b = (Pol_Role)Pol_Role.Select("QT");
            o = new Pol_UserRole() { Pol_UserId = a.Id, Pol_RoleId = b.Id };
            Pol_UserRole.Insert(o);

            a = (Pol_User)Pol_User.Select("kt");
            b = (Pol_Role)Pol_Role.Select("TK");
            o = new Pol_UserRole() { Pol_UserId = a.Id, Pol_RoleId = b.Id };
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
            var o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Full = true, Default = true };
            Pol_RoleRight.Insert(o);

            a = (Pol_Role)Pol_Role.Select("CR");
            b = (Pol_Right)Pol_Right.Select("FrmGateOut");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Full = true, Default = true };
            Pol_RoleRight.Insert(o);

            a = (Pol_Role)Pol_Role.Select("QT");
            b = (Pol_Right)Pol_Right.Select("FrmPol_Right");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmPol_Role");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmPol_User");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmPol_UserRight");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmPol_RoleRight");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmPol_UserRole");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_RoleRight.Insert(o);

            b = (Pol_Right)Pol_Right.Select("FrmTra_Group");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmTra_Kind");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmTra_Vehicle");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_RoleRight.Insert(o);

            b = (Pol_Right)Pol_Right.Select("FrmGateIn");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Full = true, Default = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmGateOut");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmInDepot");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_RoleRight.Insert(o);
            b = (Pol_Right)Pol_Right.Select("FrmSales");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Full = true };
            Pol_RoleRight.Insert(o);

            a = (Pol_Role)Pol_Role.Select("TK");
            b = (Pol_Right)Pol_Right.Select("FrmSales");
            o = new Pol_RoleRight() { Pol_RoleId = a.Id, Pol_RightId = b.Id, Full = true, Default = true };
            Pol_RoleRight.Insert(o);
        }

        /// <summary>
        /// Tạo dữ liệu mẫu bảng Tra_Group
        /// </summary>
        void CreateTra_Group()
        {
            if (Tra_Group.Count() > 0) return;

            var o = new Tra_Group() { Code = "A", Name = "Xe tải lưu đậu & vãng lai", Descript = "", Order = 0 };
            Tra_Group.Insert(o);
            o = new Tra_Group() { Code = "B", Name = "Xe khách lưu đậu ngày", Descript = "Cứ 24 giờ tính 01 ngày", Order = 1 };
            Tra_Group.Insert(o);
            o = new Tra_Group() { Code = "C", Name = "Taxi vãng lai", Descript = "", Order = 2 };
            Tra_Group.Insert(o);
            o = new Tra_Group() { Code = "D", Name = "Xe ba bánh", Descript = "", Order = 3 };
            Tra_Group.Insert(o);
            o = new Tra_Group() { Code = "E", Name = "Xe khách vãng lai, quá cảnh, trung chuyển", Descript = "Trong vòng 60 phút", Order = 4 };
            Tra_Group.Insert(o);
        }

        /// <summary>
        /// Tạo dữ liệu mẫu bảng Tra_Kind
        /// </summary>
        void CreateTra_Kind()
        {
            if (Tra_Kind.Count() > 0) return;

            var a = (Tra_Group)Tra_Group.Select("A");
            var o = new Tra_Kind() { Code = "A", Tra_GroupId = a.Id, Name = "Tải trọng < 2,5tấn", Descript = "", Price1 = 10000, Price2 = 20000, Order = 0 };
            Tra_Kind.Insert(o);
            o = new Tra_Kind() { Code = "B", Tra_GroupId = a.Id, Name = "2,5tấn ≤ tải trọng < 5tấn hoặc dài < 6m", Descript = "", Price1 = 15000, Price2 = 25000, Order = 1 };
            Tra_Kind.Insert(o);
            o = new Tra_Kind() { Code = "C", Tra_GroupId = a.Id, Name = "5tấn ≤ tải trọng < 10tấn hoặc 6m ≤ dài < 8m", Descript = "", Price1 = 15000, Price2 = 30000, Order = 2 };
            Tra_Kind.Insert(o);
            o = new Tra_Kind() { Code = "D", Tra_GroupId = a.Id, Name = "10tấn ≤ tải trọng < 15tấn hoặc dài ≥ 8m", Descript = "", Price1 = 20000, Price2 = 35000, Order = 3 };
            Tra_Kind.Insert(o);
            o = new Tra_Kind() { Code = "E", Tra_GroupId = a.Id, Name = "Container 20feet", Descript = "", Price1 = 25000, Price2 = 45000, Order = 4 };
            Tra_Kind.Insert(o);
            o = new Tra_Kind() { Code = "F", Tra_GroupId = a.Id, Name = "Container 40feet", Descript = "", Price1 = 30000, Price2 = 55000, Order = 5 };
            Tra_Kind.Insert(o);

            a = (Tra_Group)Tra_Group.Select("B");
            o = new Tra_Kind() { Code = "G", Tra_GroupId = a.Id, Name = "Số ghế < 16", Descript = "", Price1 = 0, Price2 = 20000, Order = 6 };
            Tra_Kind.Insert(o);
            o = new Tra_Kind() { Code = "H", Tra_GroupId = a.Id, Name = "16 ≤ số ghế ≤ 40", Descript = "", Price1 = 0, Price2 = 25000, Order = 7 };
            Tra_Kind.Insert(o);
            o = new Tra_Kind() { Code = "I", Tra_GroupId = a.Id, Name = "Số ghế > 40", Descript = "", Price1 = 0, Price2 = 30000, Order = 8 };
            Tra_Kind.Insert(o);

            a = (Tra_Group)Tra_Group.Select("C");
            o = new Tra_Kind() { Code = "J", Tra_GroupId = a.Id, Name = "Taxi vãng lai", Descript = "", Price1 = 0, Price2 = 8000, Order = 9 };
            Tra_Kind.Insert(o);

            a = (Tra_Group)Tra_Group.Select("D");
            o = new Tra_Kind() { Code = "K", Tra_GroupId = a.Id, Name = "Xe ba bánh", Descript = "", Price1 = 0, Price2 = 5000, Order = 10 };
            Tra_Kind.Insert(o);

            a = (Tra_Group)Tra_Group.Select("E");
            o = new Tra_Kind() { Code = "L", Tra_GroupId = a.Id, Name = "Xe khách vãng lai, quá cảnh, trung chuyển", Descript = "Trong vòng 60 phút", Price1 = 0, Price2 = 2030, Order = 11 };
            Tra_Kind.Insert(o);
        }

        /// <summary>
        /// Tạo dữ liệu mẫu bảng Tra_Vehicle
        /// </summary>
        void CreateTra_Vehicle()
        {
            if (Tra_Vehicle.Count() > 0) return;

            var a = (Tra_Kind)Tra_Kind.Select("A");
            var o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66F-123.09", Descript = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn A", Birth = new DateTime(1980, 1, 1), Address = "Sóc Sơ Bay", Phone = "1800 1090" };
            Tra_Vehicle.Insert(o);
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "65F-888.09", Descript = "Xe đen thui", Driver = "Nguyễn Văn Su", Birth = new DateTime(1982, 3, 1), Address = "Tây Sơn, Bình Định", Phone = "1800 6969" };
            Tra_Vehicle.Insert(o);
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "75F-888.09", Descript = "Xe đen thui", Driver = "Cao Văn Su", Birth = new DateTime(1988, 3, 1), Address = "Sóc Sơ Bay, Sóc Trăng", Phone = "7718 6969" };
            Tra_Vehicle.Insert(o);
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "95F-888.09", Descript = "Xe đen thui", Driver = "Trần Như Nhộng", Birth = new DateTime(1980, 3, 1), Address = "Phong Gió, Quảng Bình", Phone = "1899 6969" };
            Tra_Vehicle.Insert(o);

            a = (Tra_Kind)Tra_Kind.Select("B");
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66F-123.19", Descript = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn B", Birth = new DateTime(1980, 1, 1), Address = "Lấp Dò, Đồng Tháp", Phone = "1800 1091" };
            Tra_Vehicle.Insert(o);
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66E-123.19", Descript = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn C", Birth = new DateTime(1980, 1, 2), Address = "Cao Lãnh, Đồng Tháp", Phone = "1801 1791" };
            Tra_Vehicle.Insert(o);

            a = (Tra_Kind)Tra_Kind.Select("C");
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66C-123.19", Descript = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn C", Birth = new DateTime(1980, 1, 3), Address = "Tháp Mười, Đồng Tháp", Phone = "1802 1091" };
            Tra_Vehicle.Insert(o);

            a = (Tra_Kind)Tra_Kind.Select("D");
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66D-123.19", Descript = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn D", Birth = new DateTime(1980, 1, 4), Address = "Thanh Bình, Đồng Tháp", Phone = "1803 1091" };
            Tra_Vehicle.Insert(o);

            a = (Tra_Kind)Tra_Kind.Select("E");
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66E-123.19", Descript = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn E", Birth = new DateTime(1980, 1, 5), Address = "Chợ Lách, Bến Tre", Phone = "1804 1091" };
            Tra_Vehicle.Insert(o);

            a = (Tra_Kind)Tra_Kind.Select("F");
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66F-123.19", Descript = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn F", Birth = new DateTime(1980, 1, 6), Address = "Giồng Trôm, Bến Tre", Phone = "1805 1091" };
            Tra_Vehicle.Insert(o);

            a = (Tra_Kind)Tra_Kind.Select("G");
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66G-123.19", Descript = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn G", Birth = new DateTime(1980, 1, 7), Address = "Trà Cú, Trà Vinh", Phone = "1806 1091" };
            Tra_Vehicle.Insert(o);

            a = (Tra_Kind)Tra_Kind.Select("H");
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66H-123.19", Descript = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn H", Birth = new DateTime(1980, 1, 8), Address = "Mỹ Tho, Tiền Giang", Phone = "1807 1091" };
            Tra_Vehicle.Insert(o);

            a = (Tra_Kind)Tra_Kind.Select("I");
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66I-123.19", Descript = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn I", Birth = new DateTime(1980, 1, 9), Address = "Đông Chu, Liệt Quốc", Phone = "1808 1091" };
            Tra_Vehicle.Insert(o);

            a = (Tra_Kind)Tra_Kind.Select("J");
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66J-123.19", Descript = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn J", Birth = new DateTime(1980, 1, 10), Address = "Vĩnh Châu, Sóc Trăng", Phone = "1809 1091" };
            Tra_Vehicle.Insert(o);

            a = (Tra_Kind)Tra_Kind.Select("K");
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66K-123.19", Descript = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn K", Birth = new DateTime(1980, 1, 11), Address = "Cà Xa, Cà Mau", Phone = "1810 1091" };
            Tra_Vehicle.Insert(o);

            a = (Tra_Kind)Tra_Kind.Select("L");
            o = new Tra_Vehicle() { Tra_KindId = a.Id, Number = "66L-123.19", Descript = "Xe mui trắng, cũ xì", Driver = "Nguyễn Văn L", Birth = new DateTime(1980, 1, 12), Address = "Ngã Bảy, Hậu Giang", Phone = "1811 1091", Chair = 50 };
            Tra_Vehicle.Insert(o);
        }

        /// <summary>
        /// Tạo dữ liệu mẫu bảng Tra_Detail
        /// </summary>
        void CreateTra_Detail()
        {
            if (Tra_Detail.Count() > 0) return;

            /*var a = (Tra_Vehicle)Tra_Vehicle.Select("66F-123.09");
            var b = (Pol_User)Pol_User.Select("nvt");
            var c = (Pol_User)Pol_User.Select("admin");
            var o = new Tra_Detail() { Pol_UserInId = b.Id, Pol_UserOutId = c.Id, Tra_VehicleId = a.Id, DateIn = DateTime.Now.AddDays(-1), DateOut = DateTime.Now };
            Tra_Detail.Insert(o);
            a = (Tra_Vehicle)Tra_Vehicle.Select("65F-888.09");
            o = new Tra_Detail() { Pol_UserInId = b.Id, Pol_UserOutId = c.Id, Tra_VehicleId = a.Id, DateIn = DateTime.Now, DateOut = DateTime.Now };
            Tra_Detail.Insert(o);*/

            var tbl = Tra_Vehicle.Select();
            if (tbl == null) return;

            var d = Tra_Vehicle.GetDate();
            var ui = (Pol_User)Pol_User.Select("nvt");
            var uo = (Pol_User)Pol_User.Select("admin");

            foreach (DataRow r in tbl.Rows)
            {
                var id = (Guid)r["Id"];

                var o = new Tra_Detail() { Pol_UserInId = ui.Id, Tra_VehicleId = id, DateIn = DateTime.Now.AddDays(-1) };
                Tra_Detail.Insert(o);

                decimal money = 0;
                int price1 = 0, price2 = 0;
                int day = 0, hour = 0;
                o = new Tra_Detail() { Pol_UserOutId = uo.Id, Tra_VehicleId = id, DateOut = d };
                var tb = Tra_Detail.InvoiceOut(o, ref  day, ref  hour, ref  money, ref  price1, ref  price2, true);
            }
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

            Tra_Detail.Delete();
            Tra_Vehicle.Delete();
            Tra_Kind.Delete();
            Tra_Group.Delete();

            Pol_User.Delete();
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

            CreateTra_Group();
            CreateTra_Kind();
            CreateTra_Vehicle();
            CreateTra_Detail();
        }
    }
}