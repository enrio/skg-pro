using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.Extend
{
    using System.Windows.Forms;

    /// <summary>
    /// Form processing
    /// </summary>
    public static class Ctrl
    {
        /// <summary>
        /// Get full name
        /// </summary>
        /// <param name="f">Form</param>
        /// <returns></returns>
        public static string GetFullName(this Form f)
        {
            try { return f.GetType().FullName; }
            catch { return String.Empty; }
        }
    }
}