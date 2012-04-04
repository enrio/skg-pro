using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace BXE.PRE.YhwCcn
{
    public partial class FrmRepOrt : Form
    {
        public DataTable SumaryData { set; get; }
        public decimal SumaryMoney { set; get; }
        public DateTime? Current { set; get; }

        public FrmRepOrt()
        {
            InitializeComponent();
        }

        private void FrmRepOrt_Load(object sender, EventArgs e)
        {
            SumaryBindingSource.DataSource = SumaryData;
            SetParameters();
            rptAep.RefreshReport();

            Text = String.Format("Tổng doanh thu: {0:0,0} VNĐ", SumaryMoney);
        }

        private void SetParameters()
        {
            ReportParameter[] parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("parCa", "");
            parameters[1] = new ReportParameter("parNgay", Current.Value.ToString("dd/MM/yyyy"));

            string tmp = UTL.SFI.CsoSFI.ChangeNum2VNStr(Convert.ToDouble(SumaryMoney), " đồng");
            tmp = tmp.Substring(0, 1).ToUpper() + tmp.Substring(1, tmp.Length - 1);
            parameters[2] = new ReportParameter("sfiTee", tmp);

            parameters[3] = new ReportParameter("parLuotXe", "?");
            parameters[4] = new ReportParameter("parLuotNgay", "?");
            parameters[5] = new ReportParameter("parTongTien", SumaryMoney.ToString("#,#") + " VNĐ");

            rptAep.LocalReport.SetParameters(parameters);
            rptAep.LocalReport.DisplayName = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}