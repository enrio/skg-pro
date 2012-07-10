using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BXE.Client
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
            SKG.BLL.Sample.CreateData(false);
#endif
            //var frm = Properties.Settings.Default.IsDevExpress ? (Form)new SKG.PRE.FrmDemo() : (Form)new SKG.GUI.FrmMain();
            var frm = Properties.Settings.Default.IsDevExpress ? (Form)new SKG.PRE.FrmMain() : (Form)new SKG.GUI.FrmMain();
            Application.Run(frm);
        }
    }
}