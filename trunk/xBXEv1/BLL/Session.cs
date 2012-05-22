using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    using DAL.Entities;

    /// <summary>
    /// Session login
    /// </summary>
    public sealed class Session
    {
        public Pol_User Pol_User { set; get; }
        public DateTime? Current { set; get; }

        public Session() { Pol_User = null; }
    }
}