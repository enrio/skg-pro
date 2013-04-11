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
    using SKG.Extend;
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
        protected override void LoadData()
        {
            if (dteDayMonth.DateTime > Global.Session.Current)
                dteDayMonth.DateTime = Global.Session.Current;

            decimal sum;
            var by = (Summary)cbbType.SelectedIndex;
            var format = "dd/MM/yyyy";
            var ix = rdgDayMonth.SelectedIndex;

            switch (ix)
            {
                case 0:
                    format = "dd/MM/yyyy";
                    _dtb = _bll.Tra_Detail.SumarySalesDay(out sum, by, dteDayMonth.DateTime);

                    dteDayMonth.Properties.DisplayFormat.FormatString = format;
                    dteDayMonth.Properties.EditFormat.FormatString = format;
                    break;

                case 1:
                    format = "MM/yyyy";
                    _dtb = _bll.Tra_Detail.SumarySalesMonth(out sum, by, dteDayMonth.DateTime);

                    dteDayMonth.Properties.DisplayFormat.FormatString = format;
                    dteDayMonth.Properties.EditFormat.FormatString = format;
                    break;

                default:
                    format = "yyyy";
                    _dtb = _bll.Tra_Detail.SumarySalesYear(out sum, by, dteDayMonth.DateTime);

                    dteDayMonth.Properties.DisplayFormat.FormatString = format;
                    dteDayMonth.Properties.EditFormat.FormatString = format;
                    break;
            }

            if (sum <= 0) return;

            var dm = rdgDayMonth.Properties.Items[ix].Description;
            dm = dm.ToUpper();
            var tit = cbbType.Text.Replace("Theo", "").ToUpperFirst();

            SetAxisTitle((XYDiagram)_barChart.Diagram, tit, "Số tiền");

            var str = String.Format("{0} {3} {1} = {2}đ", Text.ToUpper(),
                dteDayMonth.DateTime.ToString(format), sum.ToString("#,0"), dm);

            if (_barChart.Titles.Count > 0) _barChart.Titles[0].Text = str;
            else _barChart.Titles.Add(new ChartTitle() { Text = str });

            if (_barChart.Series.Count > 0)
                _barChart.Series[0].DataSource = _dtb;

            if (_pieChart.Series.Count > 0)
                _pieChart.Series[0].DataSource = _dtb;

            base.LoadData();
        }

        protected override void TimerTick(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region Methods
        public FrmTra_Sales()
        {
            InitializeComponent();

            Text = STR_TITLE;

            BarChart();
            PieChart();
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
        void BarChart()
        {
            // Create an empty Bar series and add it to the chart
            var series = new Series("Series1", ViewType.Bar);
            series.LegendPointOptions.PointView = PointView.Argument;
            _barChart.Series.Add(series);

            // Adjust the point options of the series
            series.Label.PointOptions.PointView = PointView.Values;
            series.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
            series.Label.PointOptions.ValueNumericOptions.Precision = 0;

            series.ArgumentDataMember = "Key";
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { "Money" });

            // Set some properties to get a nice-looking chart and set axis title
            ((SideBySideBarSeriesView)series.View).ColorEach = true;

            series.LabelsVisibility = DefaultBoolean.True;

            // Dock the chart into its parent and add it to the current form
            _barChart.Dock = DockStyle.Fill;
            sccContent.Panel1.Controls.Add(_barChart);
        }

        /// <summary>
        /// Pie series chart
        /// </summary>
        void PieChart()
        {
            // Create an empty Pie series and add it to the chart
            var series = new Series("DOANH THU THEO TỈ LỆ %", ViewType.Pie);
            series.LegendPointOptions.PointView = PointView.Argument;
            _pieChart.Series.Add(series);

            // Adjust the point options of the series
            series.Label.PointOptions.PointView = PointView.Values;
            series.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            series.Label.PointOptions.ValueNumericOptions.Precision = 2;

            series.ArgumentDataMember = "Key";
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { "Money" });

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

            // Dock the chart into its parent and add it to the current form
            _pieChart.Dock = DockStyle.Fill;
            sccContent.Panel2.Controls.Add(_pieChart);
        }
        #endregion

        #region Events
        private void FrmTra_Sales_Load(object sender, EventArgs e)
        {
            AllowBar = false;
            dteDayMonth.DateTime = Global.Session.Current;
        }

        private void dteDayMonth_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ckbAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAutoUpdate.Checked)
            {
                tmrMain.Interval = 10000;
                tmrMain.Enabled = true;
            }
            else tmrMain.Enabled = false;
        }

        private void rdgDayMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        ChartControl _barChart = new ChartControl();
        ChartControl _pieChart = new ChartControl();
        #endregion

        #region Constants
        private const string STR_TITLE = "DOANH THU";
        #endregion
    }
}