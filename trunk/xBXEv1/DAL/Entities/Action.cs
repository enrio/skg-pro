﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Các chức năng thao tác cơ bản đối với dữ liệu
    /// ------------- ^.^ ------------- @.@ -------------
    /// Tác giả:    Nguyễn Văn Toàn - LT11780
    /// Điện thoại: 01645 515 010
    /// Hộp thư:    nvt87x@gmail.com
    /// </summary>
    public abstract class Action
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
    }
}