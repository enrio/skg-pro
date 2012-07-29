using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BXE.DAL.Entities
{
    using SKG.DAL.Entities;

    /// <summary>
    /// Vận tải - Nhóm xe
    /// </summary>
    public class Tra_Group : Zinfors
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