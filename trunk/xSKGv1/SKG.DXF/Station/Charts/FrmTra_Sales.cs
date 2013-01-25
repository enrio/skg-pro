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
using System.Collections.Generic;
using System.Windows.Forms;

namespace SKG.DXF.Station.Charts
{
    using SKG.Plugin;
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
        #endregion

        #region Events
        private void FrmTra_Sales_Load(object sender, EventArgs e)
        {
            AllowBar = false;

            // Create a chart.
            var chart = new ChartControl();
            chart.Titles.Add(new ChartTitle() { Text = Text.ToUpper() });

            // Create an empty Bar series and add it to the chart.
            var series = new Series("Series1", ViewType.Bar)
            {
                DataSource = _bll.Tra_Detail.SumaryFixedByAreaToday()
            };
            chart.Series.Add(series);

            series.ArgumentDataMember = "Area";
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { "Money" });

            // Set some properties to get a nice-looking chart.
            ((SideBySideBarSeriesView)series.View).ColorEach = true;
            //((XYDiagram)chart.Diagram).AxisY.Visible = false;

            chart.Legend.Visible = false;
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            // Dock the chart into its parent and add it to the current form.
            chart.Dock = DockStyle.Fill;
            Controls.Add(chart);
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