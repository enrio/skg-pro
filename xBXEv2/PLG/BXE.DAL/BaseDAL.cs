using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BXE.DAL
{
    using Entities;
    using System.Data;

    public class BaseDAL : SKG.DAL.SBaseDAL
    {
        internal ZContext _db = new ZContext();
        internal DataTable _tb = new DataTable("Tmp");
    }
}