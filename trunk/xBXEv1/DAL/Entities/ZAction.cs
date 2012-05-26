using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    /// <summary>
    /// Các chức năng thao tác cơ bản đối với dữ liệu
    /// </summary>
    public abstract class ZAction : ZInfor
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
        /// Toàn quyền
        /// </summary>
        public bool Full { set; get; }

        /// <summary>
        /// Không quyền
        /// </summary>
        public bool None { set; get; }

        public ZAction()
        {
            if (Full)
            {
                Add = Full;
                Edit = Full;
                Delete = Full;
                Query = Full;
                Print = Full;
                None = !Full;
            }

            if (None)
            {
                Add = !None;
                Edit = !None;
                Delete = !None;
                Query = !None;
                Print = !None;
                Full = !None;
            }
        }
    }
}