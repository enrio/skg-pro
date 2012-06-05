using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace UTL.RDR
{
    public class ExcEls : CsoRDR
    {
        private const string STR_SL1 = "select * from [{0}$]";

        public OleDbConnection Cnn { set; get; }
        public ExcEls() { Cnn = null; }

        #region Override method
        public override List<string> GetTable(string name = null)
        {
            try
            {
                if (name.IndexOf("xlsx") == -1)
                {
                    Cnn = new OleDbConnection(String.Format(STR_2K3, name));
                }
                else
                {
                    Cnn = new OleDbConnection(String.Format(STR_2K7, name));
                }

                Open();
                DataTable tbl = Cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                List<string> lst = new List<string>();

                foreach (DataRow r in tbl.Rows)
                {
                    lst.Add(r["TABLE_NAME"].ToString().Trim(new char[] { '$' }));
                }
                lst.Sort();
                return lst;
            }
            catch (Exception e)
            {
                Info = e.Message;
                return null;
            }
            finally
            {
                Close();
            }
        }

        public override DataTable GetColumn(string name)
        {
            try
            {
                Open();
                DataTable tbl = Cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, null);
                DataTable tmp = new DataTable(name);
                tmp.Columns.Add("COLUMN_NAME");
                DataRow[] dr = tbl.Select(String.Format("[TABLE_NAME]='{0}$'", name));

                foreach (DataRow r in dr)
                {
                    tmp.Rows.Add(new[] { r["COLUMN_NAME"].ToString() });
                }

                return tmp;
            }
            catch (Exception e)
            {
                Info = e.Message;
                return null;
            }
            finally
            {
                Close();
            }
        }

        public override DataTable GetData(string name)
        {
            try
            {
                Open();
                using (var dar = new OleDbDataAdapter(String.Format(STR_SL1, name), Cnn))
                {
                    var tbl = new DataTable(name);
                    dar.Fill(tbl);
                    return tbl;
                }
            }
            catch (Exception e)
            {
                Info = e.Message;
                return null;
            }
            finally
            {
                Close();
            }
        }

        public override int InsertData(DataTable table, string name)
        {
            try
            {
                return 1;
            }
            catch (Exception e)
            {
                Info = e.Message;
                return -1;
            }
            finally
            {
                Close();
            }
        }

        public override bool Open(bool showInfo = false)
        {
            try
            {
                if (Cnn.State == ConnectionState.Closed) Cnn.Open();
                return true;
            }
            catch (Exception ex)
            {
                if (showInfo)
                {
                    string s = String.Format("{0};{1}", "Lỗi kết nối!", ex.Message);
                    string t = String.Format("{0};{1}", "Lỗi", "Error");
                    Info = s;
                    UTL.CsoUTL.Show(s, t);
                }

                return false;
            }
        }

        public override void Close() { if (Cnn != null) { Cnn.Close(); } }
        #endregion
    }
}