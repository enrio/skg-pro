using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    class KetNoiCSDL:System.Data.DataTable
    {
        String ConnectionString = "server = (Local); database = Chat; uid = sa; pwd = hauk";
        private static SqlConnection Connect = null;
        SqlDataAdapter adap = null;

        public KetNoiCSDL()
        {
            if (Connect == null)
            {
                try
                {
                    Connect = new SqlConnection(ConnectionString);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Ko tao dc ket noi!!!");
                    return;
                }
            }
            if (Connect.State != ConnectionState.Open)
            {
                try
                {
                    Connect.Open();
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Ko mo dc ket noi!!!");
                    return;
                }
            }
        }
        public void Load(String SQL)
        {
            try
            {

                adap = new SqlDataAdapter(SQL, Connect);
                this.Clear();
                adap.Fill(this);
            }
            catch { System.Windows.Forms.MessageBox.Show("dasfasd"); }
        
        }
        public void Load(SqlCommand com)
        {
           // SqlCommand com = new SqlCommand(SQL);
            com.Connection = Connect;
            adap = new SqlDataAdapter();
            adap.SelectCommand = com;
            this.Clear();
            adap.Fill(this);
            // return this;
        }
        public int ThucThi(SqlCommand com)
        {
            int kq = 0;
            com.Connection = Connect;
            try
            {
                kq = com.ExecuteNonQuery();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ko thuc thi dc cau lenh");
                return 0;
            }
            return kq;
            
        }
        public object Excarlar(SqlCommand com)
        {
            object kq = null;
            com.Connection = Connect;
            try
            {
                kq = com.ExecuteScalar();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ko excarlar dc!!!");
                return null;
            }
            return kq;
        }
        public int Update()
        {
            try
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(this.adap);
                return this.adap.Update(this);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Không thành công ");
                return 0;
            }
        }
    }
}
