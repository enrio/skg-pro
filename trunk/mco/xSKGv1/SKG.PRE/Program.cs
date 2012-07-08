using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SKG.PRE
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

            BLL.SBaseBLL.CreateData(true);
            Application.Run(new FrmDemo());
        }
    }
}