namespace SKG.DXF.Station.Report
{
    partial class Rpt_IngateMaster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrSubreport1 = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrSubreport2 = new DevExpress.XtraReports.UI.XRSubreport();
            this.parDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.parUserOut = new DevExpress.XtraReports.Parameters.Parameter();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrlTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable10 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrcTitle1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.parTitle1 = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrcTitle2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.parTitle2 = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow12 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrcTitle3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.dts_Normal = new SKG.DXF.Station.DataSet.Dts_Normal();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dts_Normal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreport1,
            this.xrSubreport2});
            this.Detail.HeightF = 44.58337F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrSubreport1
            // 
            this.xrSubreport1.LocationFloat = new DevExpress.Utils.PointFloat(3.999631F, 0F);
            this.xrSubreport1.LockedInUserDesigner = true;
            this.xrSubreport1.Name = "xrSubreport1";
            this.xrSubreport1.ReportSource = new SKG.DXF.Station.Report.Rpt_Ingate();
            this.xrSubreport1.SizeF = new System.Drawing.SizeF(381.5001F, 44.58337F);
            // 
            // xrSubreport2
            // 
            this.xrSubreport2.LocationFloat = new DevExpress.Utils.PointFloat(395.9164F, 0F);
            this.xrSubreport2.LockedInUserDesigner = true;
            this.xrSubreport2.Name = "xrSubreport2";
            this.xrSubreport2.ReportSource = new SKG.DXF.Station.Report.Rpt_Ingate();
            this.xrSubreport2.SizeF = new System.Drawing.SizeF(371.0834F, 44.58337F);
            // 
            // parDate
            // 
            this.parDate.Description = "Ngày in";
            this.parDate.Name = "parDate";
            this.parDate.Type = typeof(System.DateTime);
            this.parDate.Value = new System.DateTime(2013, 5, 30, 0, 0, 0, 0);
            this.parDate.Visible = false;
            // 
            // parUserOut
            // 
            this.parUserOut.Description = "Thu ngân cho xe ra";
            this.parUserOut.Name = "parUserOut";
            this.parUserOut.Value = "";
            this.parUserOut.Visible = false;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 30F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 30F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlTitle,
            this.xrTable10});
            this.ReportHeader.HeightF = 114.8438F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrlTitle
            // 
            this.xrlTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrlTitle.LocationFloat = new DevExpress.Utils.PointFloat(89.58334F, 85.15622F);
            this.xrlTitle.Multiline = true;
            this.xrlTitle.Name = "xrlTitle";
            this.xrlTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlTitle.SizeF = new System.Drawing.SizeF(584.9174F, 25.52088F);
            this.xrlTitle.StylePriority.UseFont = false;
            this.xrlTitle.StylePriority.UseTextAlignment = false;
            this.xrlTitle.Text = "DANH SÁCH XE TRONG BẾN";
            this.xrlTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTable10
            // 
            this.xrTable10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTable10.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable10.Name = "xrTable10";
            this.xrTable10.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10,
            this.xrTableRow9,
            this.xrTableRow12});
            this.xrTable10.SizeF = new System.Drawing.SizeF(766.9998F, 77.34375F);
            this.xrTable10.StylePriority.UseFont = false;
            this.xrTable10.StylePriority.UseTextAlignment = false;
            this.xrTable10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow10
            // 
            this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrcTitle1,
            this.xrTableCell1});
            this.xrTableRow10.Name = "xrTableRow10";
            this.xrTableRow10.Weight = 1D;
            // 
            // xrcTitle1
            // 
            this.xrcTitle1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.parTitle1, "Text", "")});
            this.xrcTitle1.Name = "xrcTitle1";
            this.xrcTitle1.StylePriority.UseTextAlignment = false;
            this.xrcTitle1.Text = "xrcTitle1";
            this.xrcTitle1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrcTitle1.Weight = 1.3036635323322625D;
            // 
            // parTitle1
            // 
            this.parTitle1.Description = "Tiêu đề cấp 1";
            this.parTitle1.Name = "parTitle1";
            this.parTitle1.Visible = false;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.Text = "CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM";
            this.xrTableCell1.Weight = 1.6963364676677375D;
            // 
            // xrTableRow9
            // 
            this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrcTitle2,
            this.xrTableCell3});
            this.xrTableRow9.Name = "xrTableRow9";
            this.xrTableRow9.Weight = 1D;
            // 
            // xrcTitle2
            // 
            this.xrcTitle2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.parTitle2, "Text", "")});
            this.xrcTitle2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrcTitle2.Name = "xrcTitle2";
            this.xrcTitle2.StylePriority.UseFont = false;
            this.xrcTitle2.StylePriority.UseTextAlignment = false;
            this.xrcTitle2.Text = "xrcTitle2";
            this.xrcTitle2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrcTitle2.Weight = 1.3036634587113991D;
            // 
            // parTitle2
            // 
            this.parTitle2.Description = "Tiêu đề cấp 2";
            this.parTitle2.Name = "parTitle2";
            this.parTitle2.Visible = false;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.Text = "Độc lập - Tự do - Hạnh phúc";
            this.xrTableCell3.Weight = 1.6963365412886009D;
            // 
            // xrTableRow12
            // 
            this.xrTableRow12.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrcTitle3,
            this.xrTableCell46});
            this.xrTableRow12.Name = "xrTableRow12";
            this.xrTableRow12.Weight = 1D;
            // 
            // xrcTitle3
            // 
            this.xrcTitle3.Name = "xrcTitle3";
            this.xrcTitle3.Weight = 1.3036633393466488D;
            // 
            // xrTableCell46
            // 
            this.xrTableCell46.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.parDate, "Text", "{0:\"Thành phố Hồ Chí Minh, ngày\" dd \"tháng\" MM \"năm\" yyyy}")});
            this.xrTableCell46.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell46.Name = "xrTableCell46";
            this.xrTableCell46.StylePriority.UseFont = false;
            this.xrTableCell46.StylePriority.UseTextAlignment = false;
            this.xrTableCell46.Text = "xrTableCell70";
            this.xrTableCell46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell46.Weight = 1.6963366606533512D;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(395.9165F, 0F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(371.0833F, 25.78125F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "XE VÃNG LAI";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(3.999631F, 0F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(381.5001F, 25.78125F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "XE CỐ ĐỊNH";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // dts_Normal
            // 
            this.dts_Normal.DataSetName = "Dts_Normal";
            this.dts_Normal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReportFooter
            // 
            this.ReportFooter.HeightF = 0F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrLabel4});
            this.PageHeader.HeightF = 25.78125F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
            this.PageFooter.HeightF = 21.875F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(721.1665F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(45.83331F, 21.875F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Rpt_IngateMaster
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter,
            this.PageHeader,
            this.PageFooter});
            this.DataMember = "Ingate";
            this.DataSource = this.dts_Normal;
            this.Margins = new System.Drawing.Printing.Margins(30, 30, 30, 30);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parTitle1,
            this.parTitle2,
            this.parDate,
            this.parUserOut});
            this.RequestParameters = false;
            this.Version = "12.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dts_Normal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DataSet.Dts_Normal dts_Normal;
        public DevExpress.XtraReports.Parameters.Parameter parDate;
        public DevExpress.XtraReports.Parameters.Parameter parUserOut;
        public DevExpress.XtraReports.UI.XRSubreport xrSubreport2;
        public DevExpress.XtraReports.UI.XRSubreport xrSubreport1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        public DevExpress.XtraReports.UI.XRLabel xrLabel4;
        public DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRTable xrTable10;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow9;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow12;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell46;
        public DevExpress.XtraReports.UI.XRLabel xrlTitle;
        public DevExpress.XtraReports.Parameters.Parameter parTitle1;
        public DevExpress.XtraReports.Parameters.Parameter parTitle2;
        private DevExpress.XtraReports.UI.XRTableCell xrcTitle1;
        private DevExpress.XtraReports.UI.XRTableCell xrcTitle2;
        private DevExpress.XtraReports.UI.XRTableCell xrcTitle3;
    }
}