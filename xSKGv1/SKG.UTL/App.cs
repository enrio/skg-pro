using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.UTL
{
    using System.Reflection;
    using System.IO;

    public sealed class App
    {
        public static string StartupPath
        {
            get
            {//var s1 = Assembly.GetCallingAssembly().Location;
                var s2 = Assembly.GetEntryAssembly().Location;
                //var s3 = Assembly.GetEntryAssembly().FullName;

                //var s4 = Path.GetFileName(s2);
                var s7 = Path.GetDirectoryName(s2);
                //var s5 = AppDomain.CurrentDomain.FriendlyName;

                //{
                //    var s6 = System.AppDomain.CreateDomain("NewApplicationDomain");
                //    s6.ExecuteAssembly(s2);
                //    System.AppDomain.Unload(s6);
                //}

                return s7;
            }
        }

        public static string ProductName
        {
            get
            {
                var a = Assembly.GetEntryAssembly().Location;
                return Path.GetFileName(a);
            }
        }
    }
}