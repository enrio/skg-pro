using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.PRE.PlugTypes
{
    using UTL.Plugin;
    using System.Xml.Linq;

    public class AvailablePlugin
    {
        public IPlugin Instance { set; get; }
        public string AssemblyPath { set; get; }

        public AvailablePlugin()
        {
            Instance = null;
            AssemblyPath = "";

            ExeConfig();
        }

        public static void ExeConfig(string c = @"D:\HgqOhc\NL\xBXEv2\EXE\Plugins\xBXEv1.dll")
        {
            var loaded = XDocument.Load(c + ".config");
            var q = from s in loaded.Descendants("contact")
                    where (int)s.Attribute("contactId") < 4
                    select String.Format("{0} {1}", (string)s.Element("firstName"), (string)s.Element("lastName"));

            foreach (string name in q)
                Console.WriteLine("Customer name = {0}", name);
        }
    }
}