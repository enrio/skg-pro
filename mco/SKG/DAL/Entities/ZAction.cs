using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    /// <summary>
    /// Các chức năng thao tác cơ bản đối với dữ liệu
    /// </summary>
    public class ZAction : ZBase
    {
        /// <summary>
        /// Cho phép thêm
        /// </summary>
        public bool Add { set; get; }

        /// <summary>
        /// Cho phép sửa
        /// </summary>
        public bool Edit { set; get; }

        /// <summary>
        /// Cho phép xoá
        /// </summary>
        public bool Delete { set; get; }

        /// <summary>
        /// Cho phép truy vấn
        /// </summary>
        public bool Query { set; get; }

        /// <summary>
        /// Cho phép in ấn
        /// </summary>
        public bool Print { set; get; }

        /// <summary>
        /// Cho phép truy cập chức năng (form) này
        /// </summary>
        public bool Access { set; get; }

        /// <summary>
        /// Mặc định hiện sau khi đăng nhập
        /// </summary>
        public bool Default { set; get; }

        private bool _full;
        /// <summary>
        /// Toàn quyền
        /// </summary>
        public bool Full
        {
            set
            {
                _full = value;

                if (value)
                {
                    Add = value;
                    Edit = value;
                    Delete = value;
                    Query = value;
                    Print = value;
                    Access = value;
                    None = !value;
                }
            }
            get { return _full; }
        }

        private bool _none;
        /// <summary>
        /// Không quyền
        /// </summary>
        public bool None
        {
            set
            {
                _none = value;

                if (value)
                {
                    Add = !value;
                    Edit = !value;
                    Delete = !value;
                    Query = !value;
                    Print = !value;
                    Access = !value;
                    Full = !value;
                }
            }
            get { return _none; }
        }
    }
}