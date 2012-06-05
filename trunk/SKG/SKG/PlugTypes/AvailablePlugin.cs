using System;
using UTL.PLG;

namespace SKG.PlugTypes
{
    public class AvailablePlugin
    {
        public ItfPlg Instance { set; get; }
        public string AssemblyPath { set; get; }

        public AvailablePlugin()
        {
            Instance = null;
            AssemblyPath = "";
        }
    }
}