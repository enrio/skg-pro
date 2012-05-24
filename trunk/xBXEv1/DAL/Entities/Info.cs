using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    /// <summary>
    /// Thông tin dữ liệu
    /// </summary>
    public abstract class Info
    {
        public string Code { set; get; }
        public int Order { set; get; }
        public bool Show { set; get; }

        public Info()
        {
            Show = true;
        }
    }
}