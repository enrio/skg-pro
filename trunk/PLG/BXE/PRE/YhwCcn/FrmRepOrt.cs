using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace BXE.PRE.YhwCcn
{
    public partial class FrmRepOrt : Form
    {
        public DateTime Fr { set; get; }
        public DateTime To { set; get; }
        public string ThuNgan { set; get; }
        public bool IsOut { set; get; }

        readonly DAL.DetailDAL _dal = new DAL.DetailDAL();
        decimal _sum;

        public FrmRepOrt()
        {
            InitializeComponent();

            IsOut = true;
        }

        private void FrmRepOrt_Load(object sender, EventArgs e)
        {
            if (IsOut) SumaryDateOut();
            else SumaryDateIn();

            SetParameters();
            rptAep.RefreshReport();

            Text = String.Format("Tổng doanh thu: {0:0,0} VND", _sum);
        }

        private void SumaryDateOut()
        {
            var res = _dal.SumaryDateOut(out _sum, Fr, To);
            SumaryBindingSource.DataSource = res;
        }

        private void SumaryDateIn()
        {
            var res = _dal.SumaryDateIn(out _sum, Fr, To);
            SumaryBindingSource.DataSource = res;
        }

        private void SetParameters()
        {
            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("parCa", Fr.ToString("dd/MM/yyyy"));
            parameters[1] = new ReportParameter("parNgay", To.ToString("dd/MM/yyyy"));

            string tmp = UTL.SFI.CsoSFI.ChangeNum2VNStr(Convert.ToDouble(_sum), " đồng");
            tmp = tmp.Substring(0, 1).ToUpper() + tmp.Substring(1, tmp.Length - 1);
            parameters[2] = new ReportParameter("sfiTee", tmp);            

            rptAep.LocalReport.SetParameters(parameters);
            rptAep.LocalReport.DisplayName = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}