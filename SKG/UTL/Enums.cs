#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 23/07/2012 21:48
 * Status: OK
 */
#endregion

namespace UTL
{
    #region Text format
    public enum Format
    {
        /// <summary>
        /// Sentence case
        /// </summary>
        Sentence,

        /// <summary>
        /// lower case
        /// </summary>
        Lower,

        /// <summary>
        /// UPPER CASE
        /// </summary>
        Upper,

        /// <summary>
        /// Capitalized Case
        /// </summary>
        Capitalized,

        /// <summary>
        /// Orginal string
        /// </summary>
        Orginal
    }
    #endregion

    #region Date
    /// <summary>
    /// Enums of quarter
    /// </summary>
    public enum Quarter { First = 1, Second = 2, Third = 3, Fourth = 4 }

    /// <summary>
    /// Enums of month
    /// </summary>
    public enum Month
    {
        January = 1, February = 2, March = 3, April = 4,
        May = 5, June = 6, July = 7, August = 8,
        September = 9, October = 10, November = 11, December = 12
    }
    #endregion

    #region Form
    /// <summary>
    /// State of input form
    /// </summary>
    public enum State { View, Add, Edit, Delete, Save, Cancel, }
    #endregion

    #region License
    /// <summary>
    /// License of software
    /// </summary>
    public enum LicState { Unlimited, Trial, None }
    #endregion
}