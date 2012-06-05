using System;
using UTL.PLG;
using SKG.PlugTypes;
using System.IO;
using System.Reflection;

namespace SKG
{
    public class Services : ItfHst
    {
        private AvailablePlugins colAvailablePlugins = new AvailablePlugins();

        public AvailablePlugins AvailablePlugins
        {
            get { return colAvailablePlugins; }
            set { colAvailablePlugins = value; }
        }

        public void FindPlugins() { FindPlugins(AppDomain.CurrentDomain.BaseDirectory + @"\PLG"); }

        public void FindPlugins(string path)
        {
            try
            {
                colAvailablePlugins.Clear();
                foreach (string fileOn in Directory.GetFiles(path))
                {
                    FileInfo file = new FileInfo(fileOn);

                    if (file.Extension.Equals(".dll"))
                    {
                        AddPlugin(fileOn);
                    }
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
                        Type typeInterface = pluginType.GetInterface("UTL.PLG.ItfPlg", true);
                        if (typeInterface != null)
                        {
                            AvailablePlugin newPlugin = new AvailablePlugin
                            {
                                AssemblyPath = FileName,
                                Instance = (ItfPlg)Activator.CreateInstance(pluginAssembly.GetType(pluginType.ToString()))
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

        public void FeedBack(string feedBack, ItfPlg plug)
        {
            return;
        }

        public bool Register(ItfPlg plug)
        {
            return true;
        }

        public void LoadPlugins()
        {
            return;
        }
    }
}