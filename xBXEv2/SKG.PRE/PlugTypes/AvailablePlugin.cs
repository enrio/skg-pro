using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.PRE.PlugTypes
{
    using UTL.Plugin;
    using System.Configuration;
    using System.Reflection;

    public class AvailablePlugin
    {
        public IPlugin Instance { set; get; }
        public string AssemblyPath { set; get; }

        public AvailablePlugin()
        {
            Instance = null;
            AssemblyPath = "";

            var a = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var b = ExeConfig();

            var c = @"D:\HgqOhc\NL\xBXEv2\EXE\Plugins\xBXEv1.dll";
            var fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = c + ".config";

            var d = ConfigurationManager.OpenExeConfiguration(c + ".config");
            var e = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            var configSection = (System.Configuration.DefaultSection)e.GetSection("applicationSettings");
            var result = configSection.SectionInformation.GetRawXml();
        }

        public static Configuration ExeConfig()
        {
            var a = Assembly.GetAssembly(typeof(AvailablePlugin));
            return ConfigurationManager.OpenExeConfiguration(a.Location);
        }
    }
}