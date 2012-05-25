using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Thông tin dữ liệu cơ bản
    /// </summary>
    public abstract class Info
    {
        [Key, Column(Order = 0)]
        public Guid Id { set; get; }

        public string Code { set; get; }
        public string Descript { set; get; }

        public int Order { set; get; }
        public bool Show { set; get; }

        public Info() { Show = true; }
    }
}