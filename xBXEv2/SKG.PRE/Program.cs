using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SKG.PRE
{
    using UTL.Extension;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var a = @"Data Source=.;Initial Catalog=xBXEv1;Integrated Security=True";
            var a1 = a.CheckSqlConnect();

            var b = @"Data Source=|DataDirectory|\xBXEv1.sdf";
            var c = b.Split(new char[] { '|' });
            var d = String.Format("{0}{1}", App.StartupPath, c[2]);
            var b1 = d.CheckSqlCeConnect();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmDemo());
        }
    }
}