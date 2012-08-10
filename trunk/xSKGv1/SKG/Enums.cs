#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 09/08/2013 20:32
 * Update: 09/08/2013 20:32
 * Status: OK
 */
#endregion

namespace SKG
{
    /// <summary>
    /// Text format
    /// </summary>
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

    /// <summary>
    /// State of input form
    /// </summary>
    public enum State { View, Add, Edit, Delete, Save, Cancel, }

    /// <summary>
    /// License of software
    /// </summary>
    public enum LicState { Unlimited, Trial, None }
}