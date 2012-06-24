using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.UTL.Plugin
{
    public sealed class AvailablePlugin
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