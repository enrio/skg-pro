using System;
using System.Windows.Forms;

namespace BXE.PRE.YhwCcn
{
    public partial class FrmTkeGaa : Form, UTL.PLG.ItfPlg
    {
        public UTL.BLL.UecLajVei _sss = new UTL.BLL.UecLajVei();
        private const string _menu = "&Doanh thu";
        protected DAL.DetailDAL _dal = new DAL.DetailDAL();
        protected object _obj;
        private decimal _sum;

        public bool TkeUsr { get; set; }

        public FrmTkeGaa()
        {
            InitializeComponent();
        }

        #region Implement plugin
        string UTL.PLG.ItfPlg.Name { get { return _menu; } }
        string UTL.PLG.ItfPlg.Description { get { return "Sumary vehicles out gate"; } }
        string UTL.PLG.ItfPlg.Author { get { return "Zng Tfy"; } }
        string UTL.PLG.ItfPlg.Version { get { return "1.0"; } }

        UserControl UTL.PLG.ItfPlg.Usrcontrol { get { return null; } }
        Form UTL.PLG.ItfPlg.Frmcontrol { get { return this; } }
        UTL.PLG.ItfHst UTL.PLG.ItfPlg.Host { get; set; }

        public UTL.BLL.UecLajVei Sss { get { return _sss; } set { _sss = value; } }
        public UTL.CsoInf Inf { get; set; }

        void UTL.PLG.ItfPlg.Initialize() { }
        void UTL.PLG.ItfPlg.Dispose() { }
        #endregion

        private void FrmTkeGaa_Load(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Maximized;
            bool flag;
            if (TkeUsr) flag = false;
            else flag = true;

            LoadOut(!flag);

            dtpFrom.Enabled = flag;
            dtpTo.Enabled = flag;
            //cmdInDay.Enabled = flag;
            radIn.Enabled = flag;
            radOut.Enabled = flag;
            cbbQuy.Enabled = flag;
            cbbThang.Enabled = flag;


        }

        /// <summary>
        /// Sumary current datetime
        /// </summary>
        private void LoadOut(bool isUser = true, bool isOut = true)
        {
            DateTime fr, to;
            MakCodDate(out fr, out to);
            if (isUser)
            {
                dgvAep.DataSource = _dal.SumaryDateOutByUser(out _sum, fr, to, _sss.Id);
            }
            else
            {
                if (isOut) dgvAep.DataSource = _dal.SumaryDateOut(out _sum, fr, to);
                else dgvAep.DataSource = _dal.SumaryDateIn(out _sum, fr, to);
            }

            lblTotal.Text = _sum.ToString("0,0 VNĐ");
        }

        private void MakCodDate(out DateTime fr, out DateTime to)
        {
            int y = dtpFrom.Value.Year;
            int d = dtpFrom.Value.Day;
            int m = dtpFrom.Value.Month;

            fr = new DateTime(y, m, d, 0, 0, 0);

            d = dtpTo.Value.Day;
            m = dtpTo.Value.Month;
            y = dtpTo.Value.Year;
            to = new DateTime(y, m, d, 23, 59, 59, 999);
        }

        //private void LoadTke()
        //{
        //    dgvAep.DataSource = _dal.ThongKe();
        //}

        private void dgvMain_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            return;
            //using (var sf = new StringFormat { Alignment = StringAlignment.Center })
            //{
            //    if (e.ColumnIndex < 0 && e.RowIndex >= 0 && e.RowIndex < dgvAep.Rows.Count)
            //    {
            //        using (var drawBrush = new SolidBrush(Color.Black))
            //        {
            //            e.Graphics.DrawString((e.RowIndex + 1).ToString(), Font, drawBrush, e.CellBounds, sf);
            //        }
            //        e.Handled = true;
            //    }
            //}
        }

        private void cmdPdf_Click(object sender, EventArgs e)
        {
            using (var x = new FrmRepOrt() { WindowState = FormWindowState.Maximized })
            {
                DateTime fr, to;
                MakCodDate(out fr, out to);
                x.Fr = fr;
                x.To = to;
                if (cbbQuy.Text != "") x.ThuNgan = String.Format("Quý {0} năm {1}", cbbQuy.Text, fr.Year);
                else x.ThuNgan = "";

                if (radIn.Checked) x.IsOut = false;
                if (radOut.Checked) x.IsOut = true;

                x.ShowDialog();
            }
        }

        private void cmdInDay_Click(object sender, EventArgs e)
        {
            bool flag;
            if (TkeUsr) flag = false;
            else flag = true;

            if (radOut.Checked) LoadOut(!flag);
            if (radIn.Checked) LoadOut(!flag, false);
        }

        private void Stt()
        {
            for (int i = 0; i < dgvAep.Rows.Count; i++)
                dgvAep.Rows[i].Cells["colNo_"].Value = i + 1;
        }

        private void dgvAep_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Stt();
        }

        private void cbbQuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tmp = cbbQuy.Text.Trim();
            cbbThang.Text = "";

            if (tmp != "")
            {
                int y = _dal.CurrentTime().Value.Year;
                int m = Convert.ToInt32(tmp);

                var fr = UTL.ICA.CsoICA.GetStartOfQuarter(y, (UTL.ICA.CsoICA.Quarter)m);
                var to = UTL.ICA.CsoICA.GetEndOfQuarter(y, (UTL.ICA.CsoICA.Quarter)m);

                dtpFrom.Value = fr;
                dtpTo.Value = to;
            }
        }

        private void cbbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tmp = cbbThang.Text.Trim();
            cbbQuy.Text = "";

            if (tmp != "")
            {
                int y = _dal.CurrentTime().Value.Year;
                int m = Convert.ToInt32(tmp);

                var fr = new DateTime(y, m, 1);
                var to = new DateTime(y, m, DateTime.DaysInMonth(y, m), 23, 59, 59, 999);

                dtpFrom.Value = fr;
                dtpTo.Value = to;
            }
        }
    }
}