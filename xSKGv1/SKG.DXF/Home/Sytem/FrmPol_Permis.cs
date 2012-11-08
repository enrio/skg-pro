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
using System.Windows.Forms;

namespace SKG.DXF.Home.Sytem
{
    using SKG.Plugin;

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
                var menu = new Menuz
                {
                    Code = typeof(FrmPol_Permis).FullName,
                    Parent = typeof(Level2).FullName,
                    Text = "Phân quyền",
                    Level = 0,
                    Order = 5,
                    Picture = @"Icons\Permission.png"
                };
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