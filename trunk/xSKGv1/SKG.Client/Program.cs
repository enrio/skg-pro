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

#if DEBUG
            BLL.Sample.CreateData(false);
#endif
            var frm = Properties.Settings.Default.IsDevExpress ? (Form)new DXF.FrmMain() : (Form)new MSF.FrmDemo();
            Application.Run(frm);
        }
    }
}