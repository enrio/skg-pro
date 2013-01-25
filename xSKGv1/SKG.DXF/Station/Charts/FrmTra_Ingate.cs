using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SKG.DXF.Station.Charts
{
    using DevExpress.XtraCharts;

    public partial class FrmTra_Ingate : SKG.DXF.FrmMenuz
    {
        public FrmTra_Ingate()
        {
            InitializeComponent();

            Text = "Xe trong bến";
            WindowState = FormWindowState.Maximized;
        }

        private void FrmDesktop_Load(object sender, EventArgs e)
        {
            // Create a chart.
            ChartControl chart = new ChartControl();
            chart.Titles.Add(new ChartTitle() { Text = Text.ToUpper() });

            // Create an empty Bar series and add it to the chart.
            Series series = new Series("Series1", ViewType.Bar);
            chart.Series.Add(series);

            var bll = new BLL.BaseBLL();
            var tb = bll.Tra_Detail.GetInDepot();
            series.DataSource = tb;
            series.ArgumentDataMember = "Argument";
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { "Value" });

            // Set some properties to get a nice-looking chart.
            ((SideBySideBarSeriesView)series.View).ColorEach = true;
            ((XYDiagram)chart.Diagram).AxisY.Visible = false;
            chart.Legend.Visible = false;

            // Dock the chart into its parent and add it to the current form.
            chart.Dock = DockStyle.Fill;
            this.Controls.Add(chart);
        }
    }
}