using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.DAL.Entities
{
    public class Pol_Menu : SBase
    {
        public Guid ParentId { set; get; }

        #region Menu
        /// <summary>
        /// Menu's level
        /// </summary>
        public int Level { set; get; }

        /// <summary>
        /// Default language
        /// </summary>
        public string Text1 { set; get; }

        /// <summary>
        /// Second language
        /// </summary>
        public string Text2 { set; get; }

        /// <summary>
        /// Namespace or type name
        /// </summary>
        public string Type { set; get; }

        /// <summary>
        /// Enable
        /// </summary>
        public bool Show { set; get; }
        #endregion
    }
}