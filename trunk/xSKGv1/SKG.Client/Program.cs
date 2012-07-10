using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SKG.Client
{
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

            DevExpress.Skins.SkinManager.EnableFormSkins();
            //DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

#if DEBUG
            BLL.Sample.CreateData(false);
#endif
            var frm = Properties.Settings.Default.IsDevExpress ? (Form)new PRE.FrmDemo() : (Form)new GUI.FrmMain();
            //var frm = Properties.Settings.Default.IsDevExpress ? (Form)new PRE.Orther.FrmMain() : (Form)new GUI.FrmMain();
            Application.Run(frm);
        }
    }
}