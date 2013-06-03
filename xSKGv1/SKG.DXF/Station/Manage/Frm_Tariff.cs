#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 25/01/2012 21:07
 * Update: 02/06/2013 21:07
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;

namespace SKG.DXF.Station.Manage
{
    using SKG.Plugin;

    public partial class Frm_Tariff : FrmMenuz
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(Frm_Tariff);
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
        public Frm_Tariff()
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
        private const string STR_TITLE = "Đơn giá";
        #endregion
    }
}