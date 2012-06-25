namespace PRE.Catalog
{
    partial class FrmBase
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bmgMain = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bbiAdd = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiSave = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiCancel = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiFind = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiCollapse = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiExpand = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tmrMain = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.bmgMain)).BeginInit();
            this.SuspendLayout();
            // 
            // bmgMain
            // 
            this.bmgMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.bmgMain.DockControls.Add(this.barDockControlTop);
            this.bmgMain.DockControls.Add(this.barDockControlBottom);
            this.bmgMain.DockControls.Add(this.barDockControlLeft);
            this.bmgMain.DockControls.Add(this.barDockControlRight);
            this.bmgMain.Form = this;
            this.bmgMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiAdd,
            this.bbiEdit,
            this.bbiDelete,
            this.bbiSave,
            this.bbiCancel,
            this.bbiRefresh,
            this.bbiFind,
            this.bbiPrint,
            this.bbiClose,
            this.bbiCollapse,
            this.bbiExpand});
            this.bmgMain.MaxItemId = 11;
            this.bmgMain.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bmgMain_ItemClick);
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiSave, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiCancel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiRefresh, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiFind, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiCollapse, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiExpand, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiClose, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // bbiAdd
            // 
            this.bbiAdd.Caption = "Thê&m";
            this.bbiAdd.Glyph = global::PRE.Properties.Resources.add;
            this.bbiAdd.Id = 0;
            this.bbiAdd.Name = "bbiAdd";
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "&Sửa";
            this.bbiEdit.Glyph = global::PRE.Properties.Resources.edit;
            this.bbiEdit.Id = 1;
            this.bbiEdit.Name = "bbiEdit";
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "&Xoá";
            this.bbiDelete.Glyph = global::PRE.Properties.Resources.delete;
            this.bbiDelete.Id = 2;
            this.bbiDelete.Name = "bbiDelete";
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "&Lưu";
            this.bbiSave.Enabled = false;
            this.bbiSave.Glyph = global::PRE.Properties.Resources.save;
            this.bbiSave.Id = 3;
            this.bbiSave.Name = "bbiSave";
            // 
            // bbiCancel
            // 
            this.bbiCancel.Caption = "&Huỷ";
            this.bbiCancel.Enabled = false;
            this.bbiCancel.Glyph = global::PRE.Properties.Resources.cancel;
            this.bbiCancel.Id = 4;
            this.bbiCancel.Name = "bbiCancel";
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "&Cập nhật";
            this.bbiRefresh.Glyph = global::PRE.Properties.Resources.refresh;
            this.bbiRefresh.Id = 5;
            this.bbiRefresh.Name = "bbiRefresh";
            // 
            // bbiFind
            // 
            this.bbiFind.Caption = "&Tìm";
            this.bbiFind.Glyph = global::PRE.Properties.Resources.find;
            this.bbiFind.Id = 6;
            this.bbiFind.Name = "bbiFind";
            // 
            // bbiPrint
            // 
            this.bbiPrint.Caption = "&In";
            this.bbiPrint.Glyph = global::PRE.Properties.Resources.printer;
            this.bbiPrint.Id = 7;
            this.bbiPrint.Name = "bbiPrint";
            this.bbiPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiCollapse
            // 
            this.bbiCollapse.Caption = "Thu &gọn";
            this.bbiCollapse.Glyph = global::PRE.Properties.Resources.collapse;
            this.bbiCollapse.Id = 9;
            this.bbiCollapse.Name = "bbiCollapse";
            this.bbiCollapse.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiExpand
            // 
            this.bbiExpand.Caption = "Mở &rộng";
            this.bbiExpand.Glyph = global::PRE.Properties.Resources.expand;
            this.bbiExpand.Id = 10;
            this.bbiExpand.Name = "bbiExpand";
            this.bbiExpand.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Đó&ng";
            this.bbiClose.Glyph = global::PRE.Properties.Resources.close;
            this.bbiClose.Id = 8;
            this.bbiClose.Name = "bbiClose";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(951, 63);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 566);
            this.barDockControlBottom.Size = new System.Drawing.Size(951, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 63);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 503);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(951, 63);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 503);
            // 
            // tmrMain
            // 
            this.tmrMain.Interval = 1000;
            this.tmrMain.Tick += new System.EventHandler(this.TimerTick);
            // 
            // FrmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 566);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmBase";
            this.Load += new System.EventHandler(this.FrmBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bmgMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager bmgMain;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarLargeButtonItem bbiAdd;
        private DevExpress.XtraBars.BarLargeButtonItem bbiEdit;
        private DevExpress.XtraBars.BarLargeButtonItem bbiDelete;
        private DevExpress.XtraBars.BarLargeButtonItem bbiSave;
        private DevExpress.XtraBars.BarLargeButtonItem bbiCancel;
        private DevExpress.XtraBars.BarLargeButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarLargeButtonItem bbiFind;
        private DevExpress.XtraBars.BarLargeButtonItem bbiPrint;
        private DevExpress.XtraBars.BarLargeButtonItem bbiClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem bbiCollapse;
        private DevExpress.XtraBars.BarLargeButtonItem bbiExpand;
        protected System.Windows.Forms.Timer tmrMain;
    }
}