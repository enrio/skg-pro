using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.PRE.PlugTypes
{
    using UTL;
    using UTL.Plugin;
    using System.Xml.Linq;

    public class AvailablePlugin
    {
        public IPlugin Instance { set; get; }
        public Info Menu { set; get; }
        public string AssemblyPath { set; get; }

        public AvailablePlugin()
        {
            Instance = null;
            AssemblyPath = "";
        }
    }
}