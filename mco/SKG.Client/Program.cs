#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 23/07/2012 22:19
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SKG.Client
{
    using DevExpress.Skins;
    using DevExpress.LookAndFeel;

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

            SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            Global.Session = new Session();
            var frm = Properties.Settings.Default.IsDevExpress ? (Form)new SKG.DXF.FrmMain() : (Form)new SKG.MSF.FrmDemo();
            Application.Run(frm);
        }
    }
}