#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 29/07/2012 09:36
 * Update: 29/07/2012 09:36
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace SKG.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            Global.Session = new Session();
            var frm = Properties.Settings.Default.IsDevExpress ? (Form)new SKG.DXF.FrmMain() : (Form)new SKG.MSF.FrmMain();
            Application.Run(frm);
        }
    }
}