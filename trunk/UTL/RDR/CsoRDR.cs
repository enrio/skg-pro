using System;
using System.Collections.Generic;
using System.Data;

namespace UTL.RDR
{
    public abstract class CsoRDR
    {
        public const string STR_2K7 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";";
        public const string STR_2K3 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";
        public const string STR_SEC = "Data Source={0};Initial Catalog={1};User Id={2};Password={3};";
        public const string STR_TRU = "Data Source={0};Initial Catalog={1};Integrated Security=SSPI;";

        public string Info { set; get; }

        public CsoRDR()
        {
            Info = null;
        }

        public abstract List<string> GetTable(string name = null);

        public abstract DataTable GetColumn(string name);
        public abstract DataTable GetData(string name);
        public abstract int InsertData(DataTable table, string name);

        public abstract bool Open(bool showInfo = false);
        public abstract void Close();
    }
}