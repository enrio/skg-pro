#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 29/07/2012 10:27
 * Update: 30/07/2012 20:27
 * Status: None
 */
#endregion

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

    /// <summary>
    /// Menuz - Permission
    /// </summary>
    public partial class FrmPol_Permis : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Phân quyền", Level = 3, Order = 5, Picture = @"Icons\Permission.png" };
                return menu;
            }
        }
        #endregion

        public FrmPol_Permis()
        {
            InitializeComponent();
        }
    }
}