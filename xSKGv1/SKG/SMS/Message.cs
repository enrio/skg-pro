#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 25/01/2012 21:07
 * Update: 25/01/2012 21:07
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;

namespace SKG.SMS
{
    /// <summary>
    /// SMS information
    /// </summary>
    public class Message
    {
        public string Index { get; set; }
        public string Status { get; set; }
        public string Sender { get; set; }
        public string Alphabet { get; set; }
        public string Sent { get; set; }
        public string Content { get; set; }
    }
}