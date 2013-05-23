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
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.DXF.Station.Charts
{
    using SKG.Plugin;
    using DevExpress.Utils;
    using DevExpress.XtraCharts;

    public partial class FrmTra_Ingate : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmTra_Ingate);
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
            _dtb = _bll.Tra_Detail.GetInDepot();
            if (_dtb == null || _dtb.Rows.Count == 0) return;

            SetAxisTitle((XYDiagram)_barChart.Diagram, "Tuyến/Loại xe", "Số xe");

            var tmp = _dtb.Compute("Sum(Value)", "");
            var sum = Convert.ToInt32(tmp).ToString("#,0");
            var str = String.Format("{0} = {1}XE", Text.ToUpper(), sum);

            if (_barChart.Titles.Count > 0) _barChart.Titles[0].Text = str;
            else _barChart.Titles.Add(new ChartTitle() { Text = str });

            if (_barChart.Series.Count > 0)
                _barChart.Series[0].DataSource = _dtb;

            base.LoadData();
        }
        #endregion

        #region Methods
        public FrmTra_Ingate()
        {
            InitializeComponent();

            Text = STR_TITLE;

            BarChart();
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

            series.ArgumentDataMember = "Argument";
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { "Value" });

            // Set some properties to get a nice-looking chart and set axis title
            ((SideBySideBarSeriesView)series.View).ColorEach = true;

            series.LabelsVisibility = DefaultBoolean.True;

            // Dock the chart into its parent and add it to the current form
            _barChart.Dock = DockStyle.Fill;
            Controls.Add(_barChart);
        }
        #endregion

        #region Events
        private void FrmTra_Ingate_Load(object sender, EventArgs e)
        {
            AllowBar = false;

            LoadData();
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        ChartControl _barChart = new ChartControl();
        #endregion

        #region Constants
        private const string STR_TITLE = "XE TRONG BẾN";
        #endregion
    }
}