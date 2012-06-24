using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.PRE.PlugTypes
{
    using UTL.Plugin;

    public class AvailablePlugin
    {
        public IPlugin Instance { set; get; }
        public string AssemblyPath { set; get; }

        public AvailablePlugin()
        {
            Instance = null;
            AssemblyPath = "";
        }
    }
}