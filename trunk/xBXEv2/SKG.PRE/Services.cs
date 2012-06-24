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
            Assembly pluginAssembly = Assembly.LoadFrom(FileName);

            foreach (Type pluginType in pluginAssembly.GetTypes())
            {
                if (pluginType.IsPublic)
                {
                    if (!pluginType.IsAbstract)
                    {
                        Type typeInterface = pluginType.GetInterface("SKG.UTL.Plugin.IPlugin", true);
                        if (typeInterface != null)
                        {
                            AvailablePlugin newPlugin = new AvailablePlugin
                            {
                                AssemblyPath = FileName,
                                Instance = (IPlugin)Activator.CreateInstance(pluginAssembly.GetType(pluginType.ToString()))
                            };

                            newPlugin.Instance.Host = this;
                            newPlugin.Instance.Initialize();
                            colAvailablePlugins.Add(newPlugin);
                            newPlugin = null;
                        }
                        typeInterface = null;
                    }
                }
            }
            pluginAssembly = null;
        }

        public void FeedBack(string feedBack, IPlugin plug)
        {
            return;
        }

        public bool Register(IPlugin plug)
        {
            return true;
        }

        public void LoadPlugins()
        {
            return;
        }
    }
}