﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    /// <summary>
    /// Vận tải - Nhóm xe
    /// </summary>
    public class Tra_Group : ZInfor
    {
        /// <summary>
        /// Tên nhóm xe
        /// </summary>
        public string Name { set; get; }

        #region Khoá ngoại ở các thực thể khác
        /// <summary>
        /// Danh sách loại xe
        /// </summary>
        public virtual ICollection<Tra_Kind> Tra_Kinds { get; set; }
        #endregion
    }
}