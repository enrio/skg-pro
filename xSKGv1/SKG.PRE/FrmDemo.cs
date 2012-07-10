using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;


namespace SKG.PRE
{
    public partial class FrmDemo : RibbonForm
    {
        public FrmDemo()
        {
            InitializeComponent();
            InitSkinGallery();
            InitGrid();
            splitContainerControl.Visible = false;
        }

        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        readonly BindingList<Person> gridDataList = new BindingList<Person>();

        void InitGrid()
        {
            gridDataList.Add(new Person("John", "Smith"));
            gridDataList.Add(new Person("Gabriel", "Smith"));
            gridDataList.Add(new Person("Ashley", "Smith", "some comment"));
            gridDataList.Add(new Person("Adrian", "Smith", "some comment"));
            gridDataList.Add(new Person("Gabriella", "Smith", "some comment"));
            gridControl.DataSource = gridDataList;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var a = Global.Service.GetPlugins();
            ribbonControl.LoadMenu(a, this);
        }
    }
}