using System;
using System.Drawing;
using System.Windows.Forms;

namespace BXE.PRE.YhwCcn
{
    using System.Data;

    public partial class FrmAhvBdd : Form, UTL.PLG.ItfPlg
    {
        public UTL.BLL.UecLajVei _sss = new UTL.BLL.UecLajVei();
        private readonly string _menu = "&Xe trong bến";
        protected DAL.DetailDAL _dal = new DAL.DetailDAL();
        protected object _obj;
        private DataTable _tb;

        public FrmAhvBdd()
        {
            InitializeComponent();
        }

        #region Implement plugin
        string UTL.PLG.ItfPlg.Name { get { return _menu; } }
        string UTL.PLG.ItfPlg.Description { get { return "Sumary vehicles in gate"; } }
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

        private void FrmAhvBdd_Load(object sender, EventArgs e)
        {
            decimal sum;
            _tb = _dal.GetListIn(out sum);
            dgvAep.DataSource = _tb;
            lblInf.Text = String.Format("Tổng số xe hiện có: {0}", sum.ToString("0"));
        }

        private void dgvAep_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgvAep_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Stt();
        }

        private void Stt()
        {
            for (int i = 0; i < dgvAep.Rows.Count; i++)
                dgvAep.Rows[i].Cells["colNo_"].Value = i + 1;
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text + "" == "") return;
            var dtr = _tb.Select(String.Format("Number Like '%{0}%'", txtNumber.Text));
            if (dtr.Length > 0) dgvAep.DataSource = dtr.CopyToDataTable();
            else MessageBox.Show("Không tìm thấy", Text);
        }
    }
}