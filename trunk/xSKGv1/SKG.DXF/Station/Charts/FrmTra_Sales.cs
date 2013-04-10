#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 25/01/2012 21:07
 * Update: 25/01/2012 21:07
 * Status: OK
 */
#endregion

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.DXF.Station.Charts
{
    using SKG.Plugin;
    using DevExpress.Utils;
    using DevExpress.XtraCharts;

    public partial class FrmTra_Sales : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmTra_Sales);
                var name = Global.GetIconName(type);

                var menu = new Menuz
                {
                    Code = type.FullName,
                    Parent = "SKG.DXF.Home.Charts",
                    Text = STR_TITLE,
                    Level = 1,
                    Order = 0,
                    Picture = String.Format(Global.STR_ICON, name)
                };
                return menu;
            }
        }
        #endregion

        #region Implements
        #endregion

        #region Overrides
        #endregion

        #region Methods
        public FrmTra_Sales()
        {
            InitializeComponent();

            Text = STR_TITLE;
        }

        void SetAxisTitle(XYDiagram diagram, string axisX, string axisY)
        {
            // Customize the appearance of the X-axis title
            diagram.AxisX.Title.Visible = true;
            diagram.AxisX.Title.Alignment = StringAlignment.Far;
            diagram.AxisX.Title.Text = axisX;
            diagram.AxisX.Title.TextColor = Color.Red;
            diagram.AxisX.Title.Antialiasing = true;
            diagram.AxisX.Label.Visible = false;

            // Customize the appearance of the Y-axis title
            diagram.AxisY.Title.Visible = true;
            diagram.AxisY.Title.Alignment = StringAlignment.Far;
            diagram.AxisY.Title.Text = axisY;
            diagram.AxisY.Title.TextColor = Color.Blue;
            diagram.AxisY.Title.Antialiasing = true;
            diagram.AxisY.NumericOptions.Format = NumericFormat.Number;
            diagram.AxisY.NumericOptions.Precision = 0;
        }

        /// <summary>
        /// Bar series chart
        /// </summary>
        void BarChart(DataTable tb)
        {
            if (tb == null || tb.Rows.Count == 0) return;
            var tmp = tb.Compute("Sum(Money)", "");
            var sum = Convert.ToDecimal(tmp).ToString("#,0");

            // Create an empty chart
            var chart = new ChartControl();
            chart.Titles.Add(new ChartTitle()
            {
                Text = String.Format("{0} ngày {1} = {2}đ",
                Text.ToUpper(), Global.ToDateVN, sum)
            });

            // Create an empty Bar series and add it to the chart
            var series = new Series("Series1", ViewType.Bar) { DataSource = tb };
            chart.Series.Add(series);

            // Adjust the point options of the series
            series.Label.PointOptions.PointView = PointView.ArgumentAndValues;
            series.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
            series.Label.PointOptions.ValueNumericOptions.Precision = 0;

            series.ArgumentDataMember = "Key";
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { "Money" });

            // Set some properties to get a nice-looking chart and set axis title
            ((SideBySideBarSeriesView)series.View).ColorEach = true;
            SetAxisTitle((XYDiagram)chart.Diagram, "Vùng/Nhóm xe", "Số tiền");

            chart.Legend.Visible = false;
            series.LabelsVisibility = DefaultBoolean.True;

            // Dock the chart into its parent and add it to the current form
            chart.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(chart);
        }

        /// <summary>
        /// Pie series chart
        /// </summary>
        void PieChart(DataTable tb)
        {
            if (tb == null || tb.Rows.Count == 0) return;

            // Create an empty chart
            var pieChart = new ChartControl();

            // Create an empty Pie series and add it to the chart
            var series1 = new Series("DOANH THU THEO TỈ LỆ %", ViewType.Pie) { DataSource = tb };
            pieChart.Series.Add(series1);

            series1.ArgumentDataMember = "Key";
            series1.ValueScaleType = ScaleType.Numerical;
            series1.ValueDataMembers.AddRange(new string[] { "Money" });

            // Adjust the point options of the series
            series1.Label.PointOptions.PointView = PointView.ArgumentAndValues;
            series1.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            series1.Label.PointOptions.ValueNumericOptions.Precision = 2;

            // Detect overlapping of series labels
            ((PieSeriesLabel)series1.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;

            // Access the view-type-specific options of the series
            PieSeriesView myView = (PieSeriesView)series1.View;

            // Show a title for the series.
            myView.Titles.Add(new SeriesTitle());
            myView.Titles[0].Text = series1.Name;

            // Specify a data filter to explode points.
            myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Value_1,
                DataFilterCondition.GreaterThanOrEqual, 9));
            myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Argument,
                DataFilterCondition.NotEqual, "Others"));
            myView.ExplodeMode = PieExplodeMode.UseFilters;
            myView.ExplodedDistancePercentage = 30;
            myView.RuntimeExploding = true;
            myView.HeightToWidthRatio = 99;

            // Hide the legend (if necessary).
            pieChart.Legend.Visible = false;

            // Add the chart to the form.
            pieChart.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(pieChart);
        }
        #endregion

        #region Events
        private void FrmTra_Sales_Load(object sender, EventArgs e)
        {
            AllowBar = false;

            var tb = _bll.Tra_Detail.SumaryFixedByAreaToday();

            BarChart(tb);
            PieChart(tb);
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constants
        private const string STR_TITLE = "DOANH THU";
        #endregion
    }
}