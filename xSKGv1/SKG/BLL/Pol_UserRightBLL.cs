#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:33
 * Update: 24/07/2012 22:02
 * Status: OK
 */
#endregion

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace SKG.BLL
{
    /// <summary>
    /// Policy - Pol_UserRight accessing
    /// </summary>
    public sealed class Pol_UserRightBLL : DAL.Pol_UserRightDAL
    {
        public new DataTable Select(object obj = null, int skip = 0, int take = 0)
        {
            var tb = base.Select(obj, skip, take);
            var str = String.Format("RightId = '{0}'", Guid.Empty);

            var user = tb.Select(str, "");
            for (int i = 0; i < user.Count(); i++)
            {
                var id = user[i]["Id"];
                str = "xParentID = '{0}' and ParentID = '{0}' and RightId <> '{1}'";
                str = String.Format(str, id, Guid.Empty);

                var l1 = tb.Select(str, "");
                foreach (DataRow r1 in l1)
                {
                    var tmp = r1["Id"];
                    r1["Id"] = r1["xId"];
                    str = String.Format("xParentID = '{0}' and ParentID = '{1}'", id, tmp);

                    var l2 = tb.Select(str, "");
                    foreach (DataRow r2 in l2)
                    {
                        tmp = r2["Id"];
                        r2["ParentID"] = r1["Id"];
                        r2["Id"] = r2["xId"];
                        str = String.Format("xParentID = '{0}' and ParentID = '{1}'", id, tmp);

                        var l3 = tb.Select(str, "");
                        foreach (DataRow r3 in l3)
                        {
                            r3["ParentID"] = r2["Id"];
                            r3["Id"] = r3["xId"];
                        }
                    }
                }
            }

            return tb;
        }
    }
}