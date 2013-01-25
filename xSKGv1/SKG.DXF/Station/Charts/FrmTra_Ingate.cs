﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SKG.DXF.Station.Charts
{
    using DevExpress.XtraCharts;

    public partial class FrmTra_Ingate : SKG.DXF.FrmInput
    {
        public FrmTra_Ingate()
        {
            InitializeComponent();

            Text = "Xe trong bến";
        }

        private void FrmTra_Ingate_Load(object sender, EventArgs e)
        {
            AllowBar = false;

            // Create a chart.
            var chart = new ChartControl();
            chart.Titles.Add(new ChartTitle() { Text = Text.ToUpper() });

            // Create an empty Bar series and add it to the chart.
            var series = new Series("Series1", ViewType.Bar) { DataSource = _bll.Tra_Detail.GetInDepot() };
            chart.Series.Add(series);

            series.ArgumentDataMember = "Argument";
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { "Value" });

            // Set some properties to get a nice-looking chart.
            ((SideBySideBarSeriesView)series.View).ColorEach = true;
            //((XYDiagram)chart.Diagram).AxisY.Visible = false;

            chart.Legend.Visible = false;
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            // Dock the chart into its parent and add it to the current form.
            chart.Dock = DockStyle.Fill;
            Controls.Add(chart);
        }
    }
}