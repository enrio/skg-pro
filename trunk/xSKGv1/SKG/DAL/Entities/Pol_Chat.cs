#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:33
 * Update: 24/07/2012 21:45
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Policy - Chat on system
    /// </summary>
    public class Pol_Chat : Zinfors
    {
        #region Foreign key
        /// <summary>
        /// Refercence to Pol_User
        /// </summary>
        [Column(Order = 0), ForeignKey("Sender")]
        public Guid? SenderId { set; get; }
        /// <summary>
        /// Sender
        /// </summary>
        public virtual Pol_User Sender { get; set; }

        /// <summary>
        /// Refercence to Pol_User
        /// </summary>
        [Column(Order = 1), ForeignKey("Receiver")]
        public Guid? ReceiverId { set; get; }
        /// <summary>
        /// Receiver
        /// </summary>
        public virtual Pol_User Receiver { get; set; }
        #endregion

        /// <summary>
        /// Content message
        /// </summary>
        public string Message { set; get; }

        /// <summary>
        /// Date sent
        /// </summary>
        public DateTime Date { set; get; }
    }
}