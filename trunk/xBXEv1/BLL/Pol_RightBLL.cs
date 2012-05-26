using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    using DAL.Entities;

    public sealed class Pol_RightBLL : DAL.Pol_RightDAL
    {
        public object Insert(string code, string name, string descript)
        {
            var o = new Pol_Right() { Code = code, Name = name, Descript = descript };
            return Insert(o);
        }
    }
}