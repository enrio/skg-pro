using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Người dùng
    /// </summary>
    public class User
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        public long Id { set; get; }

        /// <summary>
        /// Tài khoản
        /// </summary>
        [StringLength(50)]
        public string Acc { set; get; }

        /// <summary>
        /// Mật khẩu
        /// </summary>
        [StringLength(200)]
        public string Pass { set; get; }

        /// <summary>
        /// Họ tên
        /// </summary>
        [StringLength(200)]
        public string Name { set; get; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime Birth { set; get; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        [StringLength(200)]
        public string Address { set; get; }

        /// <summary>
        /// Điện thoại
        /// </summary>
        [StringLength(200)]
        public string Phone { set; get; }

        /// <summary>
        /// Vai trò, quyền hạn
        /// </summary>
        public int Role { set; get; }

        public virtual ICollection<Detail> Details { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}