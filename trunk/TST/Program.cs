using System;
using System.Windows.Forms;

namespace TST
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
            Application.Run(new UTL.HSH.FrmBauVlv() { IsKey = true });
#else
            Application.Run(new FrmAepAjf());
#endif
        }
    }
}