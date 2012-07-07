using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BXE.DAL.Entities
{
    using SKG.DAL.Entities;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Vận tải - Loại xe
    /// </summary>
    public class Tra_Kind : SBase
    {
        #region Khoá ngoại
        /// <summary>
        /// Khoá ngoại tham chiếu tới Tra_Group
        /// </summary>
        [ForeignKey("Tra_Group")]
        public Guid? Tra_GroupId { set; get; }
        public virtual Tra_Group Tra_Group { get; set; }
        #endregion

        /// <summary>
        /// Tên loại xe
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Đơn giá nửa ngày
        /// </summary>
        public int Price1 { set; get; }

        /// <summary>
        /// Đơn giá một ngày
        /// </summary>
        public int Price2 { set; get; }

        #region Khoá ngoại ở các thực thể khác
        /// <summary>
        /// Danh sách xe
        /// </summary>
        public virtual ICollection<Tra_Vehicle> Tra_Vehicles { get; set; }
        #endregion
    }
}