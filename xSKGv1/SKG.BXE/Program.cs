﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SKG.BXE
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

            var frm = Properties.Settings.Default.IsDevExpress ? (Form)new PRE.Orther.FrmMain() : (Form)new GUI.FrmMain();
            Application.Run(frm);
        }
    }
}