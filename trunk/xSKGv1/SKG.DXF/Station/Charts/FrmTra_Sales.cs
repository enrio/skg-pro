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
                Text.ToUpper(), dteDay.DateTime.ToString("dd/MM/yyyy"), sum)
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
            sccContent.Panel1.Controls.Add(chart);
        }

        /// <summary>
        /// Pie series chart
        /// </summary>
        void PieChart(DataTable tb)
        {
            if (tb == null || tb.Rows.Count == 0) return;

            // Create an empty chart
            var chart = new ChartControl();

            // Create an empty Pie series and add it to the chart
            var series = new Series("DOANH THU THEO TỈ LỆ %", ViewType.Pie) { DataSource = tb };
            chart.Series.Add(series);

            series.ArgumentDataMember = "Key";
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { "Money" });

            // Adjust the point options of the series
            series.Label.PointOptions.PointView = PointView.ArgumentAndValues;
            series.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            series.Label.PointOptions.ValueNumericOptions.Precision = 0;

            // Detect overlapping of series labels
            ((PieSeriesLabel)series.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;

            // Access the view-type-specific options of the series
            PieSeriesView myView = (PieSeriesView)series.View;

            // Show a title for the series.
            myView.Titles.Add(new SeriesTitle());
            myView.Titles[0].Text = series.Name;

            // Specify a data filter to explode points.
            myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Value_1,
                DataFilterCondition.GreaterThanOrEqual, 9));
            myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Argument,
                DataFilterCondition.NotEqual, "Others"));
            myView.ExplodeMode = PieExplodeMode.UseFilters;
            myView.ExplodedDistancePercentage = 30;
            myView.RuntimeExploding = true;
            myView.HeightToWidthRatio = 99;

            // Hide the legend (if necessary)
            chart.Legend.Visible = false;

            // Dock the chart into its parent and add it to the current form
            chart.Dock = DockStyle.Fill;
            sccContent.Panel2.Controls.Add(chart);
        }
        #endregion

        #region Events
        private void FrmTra_Sales_Load(object sender, EventArgs e)
        {
            AllowBar = false;
            dteDay.DateTime = Global.Session.Current;
        }

        private void dteDay_EditValueChanged(object sender, EventArgs e)
        {
            var tb = _bll.Tra_Detail.SumaryFixedByArea(dteDay.DateTime);

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