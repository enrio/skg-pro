using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SKG.DXF.Home.Sytem
{
    using BLL;
    using SKG.Plugin;
    using DevExpress.XtraEditors;

    public partial class FrmPermission : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Đăng nhập", Level = 3, Order = 5, Picture = @"Icons\Login.png" };
                return menu;
            }
        }
        #endregion

        public FrmPermission()
        {
            InitializeComponent();
        }
    }
}