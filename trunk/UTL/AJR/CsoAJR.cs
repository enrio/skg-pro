using System;

namespace UTL.AJR
{
    public class CsoAJR : CsoAjf, ItfAjf
    {
        #region Contansts
        #endregion

        #region Default objects
        #endregion

        #region More objects
        #endregion

        #region Properties
        #endregion

        #region Implements
        #endregion

        #region Constructors
        #endregion

        #region Events
        #endregion

        #region Methods
        /// <summary>
        /// Trim space all the string (start, middle, end)
        /// </summary>
        /// <param name="str">a string need to trim</param>
        /// <returns>the string trimed</returns>
        public static string TrimAll(string str)
        {
            var tmp = str.Split(new char[] { ' ' });
            string res = "";

            foreach (var s in tmp)
                if (s != "") res += s.Trim() + " ";

            return res.TrimEnd();
        }
        #endregion

        #region More
        #endregion
    }
}