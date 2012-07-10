using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BXE.Client
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

#if DEBUG
            SKG.BLL.Sample.CreateData(false);
#endif

            var frm = Properties.Settings.Default.IsDevExpress ? (Form)new SKG.PRE.Orther.FrmMain() : (Form)new SKG.GUI.FrmMain();
            Application.Run(frm);
        }
    }
}