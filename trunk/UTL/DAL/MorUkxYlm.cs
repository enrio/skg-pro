using System;
using System.Collections.Generic;
using System.Data;

namespace UTL.DAL
{
    public static class MorUkxYlm
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> data, bool numbered = true, string tableName = "Tmp")
        {
            var res = UTL.CsoUTL.Linq2Table((IEnumerable<T>)data, tableName);
            res.Numbered(numbered);
            return res;
        }

        public static void Numbered(this DataTable dtb, bool numbered = true)
        {
            if (numbered)
            {
                dtb.Columns.Add("No_");
                for (int i = 0; i < dtb.Rows.Count; i++)
                    dtb.Rows[i].SetField("No_", i + 1); // numbered
            }

            dtb.AcceptChanges();
        }
    }
}