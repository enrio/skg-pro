using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.PRE
{
    using UTL.Plugin;
    using PlugTypes;
    using System.IO;
    using System.Reflection;

    public class Services : IHost
    {
        private AvailablePlugins colAvailablePlugins = new AvailablePlugins();

        public AvailablePlugins AvailablePlugins
        {
            get { return colAvailablePlugins; }
            set { colAvailablePlugins = value; }
        }

        public void FindPlugins() { FindPlugins(AppDomain.CurrentDomain.BaseDirectory + @"\Plugins"); }

        public void FindPlugins(string path)
        {
            try
            {
                colAvailablePlugins.Clear();
                foreach (string fileOn in Directory.GetFiles(path))
                {
                    FileInfo file = new FileInfo(fileOn);
                    if (file.Name.Equals("SKG.UTL.dll")) continue;
                    if (file.Extension.Equals(".dll")) AddPlugin(fileOn);
                }
            }
            catch { }
        }

        public void ClosePlugins()
        {
            foreach (AvailablePlugin pluginOn in colAvailablePlugins)
            {
                pluginOn.Instance.Dispose();
                pluginOn.Instance = null;
            }
            colAvailablePlugins.Clear();
        }

        private void AddPlugin(string FileName)
        {
            var pluginAssembly = Assembly.LoadFrom(FileName);
            foreach (Type pluginType in pluginAssembly.GetTypes())
            {
                if (pluginType.IsPublic)
                {
                    if (!pluginType.IsAbstract)
                    {
                        var a = pluginType.GetInterface(typeof(IPlugin).FullName, true);
                        if (a != null)
                        {
                            var b = pluginAssembly.GetType(pluginType + "");
                            var c = new AvailablePlugin
                            {
                                AssemblyPath = FileName,
                                Instance = (IPlugin)Activator.CreateInstance(b)
                            };

                            c.Instance.Host = this;
                            c.Instance.Initialize();
                            colAvailablePlugins.Add(c);
                            c = null;
                        }
                        a = null;
                    }
                }
            }
            pluginAssembly = null;
        }

        public void FeedBack(string feedBack, IPlugin plug) { return; }
        public bool Register(IPlugin plug) { return true; }
        public void LoadPlugins() { return; }
    }
}