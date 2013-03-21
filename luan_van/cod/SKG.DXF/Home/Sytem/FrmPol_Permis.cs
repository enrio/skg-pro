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

namespace SKG.DXF.Home.Sytem
{
    using SKG.Plugin;

    /// <summary>
    /// Menuz - Permission
    /// </summary>
    public partial class FrmPol_Permis : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmPol_Permis);
                var name = Global.GetIconName(type);

                var menu = new Menuz
                {
                    Code = type.FullName,
                    Parent = typeof(Level2).FullName,
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
        public FrmPol_Permis()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constants
        private const string STR_TITLE = "Phân quyền";
        #endregion
    }
}