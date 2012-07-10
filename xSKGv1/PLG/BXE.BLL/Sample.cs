using System;
using System.Collections.Generic;
using System.Linq;

namespace BXE.BLL
{
    using System.Data;
    using DAL.Entities;
    using SKG.DAL.Entities;

    /// <summary>
    /// Dữ liệu mẫu, các luồng xử lí dữ liệu sử dụng tại đây.
    /// </summary>
    public sealed class Sample : SKG.BLL.Sample
    {
        #region Các thuộc tính truy cập cơ sở dữ liệu
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

        /// <summary>
        /// Khởi tạo các thuộc tính truy cập cơ sở dữ liệu
        /// </summary>
        public Sample()
        {
            Tra_Group = new Tra_GroupBLL();
            Tra_Kind = new Tra_KindBLL();
            Tra_Vehicle = new Tra_VehicleBLL();
            Tra_Detail = new Tra_DetailBLL();
        }

        #region Tạo dữ liệu mẫu
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
            o = new Tra_Kind() { Code = "G", Tra_GroupId = a.Id, Name = "Số ghế < 16", Descript = "", Price1 = 20000, Price2 = 20000, Order = 6 };
            Tra_Kind.Insert(o);
            o = new Tra_Kind() { Code = "H", Tra_GroupId = a.Id, Name = "16 ≤ số ghế ≤ 40", Descript = "", Price1 = 25000, Price2 = 25000, Order = 7 };
            Tra_Kind.Insert(o);
            o = new Tra_Kind() { Code = "I", Tra_GroupId = a.Id, Name = "Số ghế > 40", Descript = "", Price1 = 30000, Price2 = 30000, Order = 8 };
            Tra_Kind.Insert(o);

            a = (Tra_Group)Tra_Group.Select("C");
            o = new Tra_Kind() { Code = "J", Tra_GroupId = a.Id, Name = "Taxi vãng lai", Descript = "", Price1 = 8000, Price2 = 8000, Order = 9 };
            Tra_Kind.Insert(o);

            a = (Tra_Group)Tra_Group.Select("D");
            o = new Tra_Kind() { Code = "K", Tra_GroupId = a.Id, Name = "Xe ba bánh", Descript = "", Price1 = 5000, Price2 = 5000, Order = 10 };
            Tra_Kind.Insert(o);

            a = (Tra_Group)Tra_Group.Select("E");
            o = new Tra_Kind() { Code = "L", Tra_GroupId = a.Id, Name = "Xe khách vãng lai, quá cảnh, trung chuyển", Descript = "Trong vòng 60 phút", Price1 = 2030, Price2 = 2030, Order = 11 };
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
        /// Xoá tất cả
        /// </summary>
        protected override void DeleteAll()
        {
            Tra_Detail.Delete();
            Tra_Vehicle.Delete();
            Tra_Kind.Delete();
            Tra_Group.Delete();
            base.DeleteAll();
        }

        /// <summary>
        /// Tạo mới tất cả
        /// </summary>
        protected override void CreateAll()
        {
            base.CreateAll();
            CreateTra_Group();
            CreateTra_Kind();
            CreateTra_Vehicle();
            CreateTra_Detail();
        }
    }
}