using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.DAL.Entities
{
    public class Pol_Menu : Base
    {
        /// <summary>
        /// Menu of level
        /// </summary>
        public int Level { set; get; }

        /// <summary>
        /// Default language
        /// </summary>
        public string Caption { set; get; }

        #region Language
        /// <summary>
        /// First language
        /// </summary>
        public string LangF { set; get; }

        /// <summary>
        /// Second language
        /// </summary>
        public string LangS { set; get; }

        /// <summary>
        /// Third language
        /// </summary>
        public string LangT { set; get; }
        #endregion

        /// <summary>
        /// Namespace or type name
        /// </summary>
        public string Type { set; get; }

        /// <summary>
        /// Picture for icon
        /// </summary>
        public string Picture { set; get; }
    }
}