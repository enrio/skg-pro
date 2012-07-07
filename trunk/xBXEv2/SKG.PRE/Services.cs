using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.PRE
{
    using UTL.Plugin;
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

        #region App.Config file
        /// <summary>
        /// Find App.Config file
        /// </summary>
        /// <param name="s">Path</param>
        public static List<string> FindConfigs(string s)
        {
            try
            {
                var l = new List<string>();
                foreach (var i in Directory.GetFiles(s))
                {
                    var f = new FileInfo(i);
                    if (f.Extension.Equals(".config")) l.Add(i);
                }
                return l;
            }
            catch { return null; }
        }
        #endregion

        public void FindPlugins()
        {
            var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"\Plugins");
            foreach (DirectoryInfo i in dir.GetDirectories()) FindPlugins(i.FullName);
        }

        /// <summary>
        /// Find all plugins
        /// </summary>
        /// <param name="path">Path's plugin</param>
        public void FindPlugins(string path)
        {
            try
            {
                colAvailablePlugins.Clear();
                foreach (string fileOn in Directory.GetFiles(path))
                {
                    FileInfo file = new FileInfo(fileOn);

                    #region Skip
                    if (file.Name.Equals("SKG.UTL.dll")) continue;
                    if (file.Name.Equals("SKG.DAL.dll")) continue;
                    if (file.Name.Equals("SKG.BLL.dll")) continue;
                    if (file.Name.Equals("SKG.PRE.exe")) continue;
                    #endregion

                    if (file.Extension.Equals(".dll")) AddPlugin(fileOn);
                    if (file.Extension.Equals(".exe")) AddPlugin(fileOn);
                }
            }
            catch { return; }
        }

        /// <summary>
        /// Close all plugins
        /// </summary>
        public void ClosePlugins()
        {
            foreach (AvailablePlugin pluginOn in colAvailablePlugins)
            {
                pluginOn.Instance.Dispose();
                pluginOn.Instance = null;
            }
            colAvailablePlugins.Clear();
        }

        /// <summary>
        /// Add plugin
        /// </summary>
        /// <param name="fileName">Path file name</param>
        private void AddPlugin(string fileName)
        {
            var pluginAssembly = Assembly.LoadFrom(fileName);
            foreach (Type pluginType in pluginAssembly.GetTypes())
            {
                if (!pluginType.IsPublic) return;
                if (pluginType.IsAbstract) return;

                var a = pluginType.GetInterface(typeof(IPlugin).FullName, true);
                if (a == null) return;

                var type = pluginAssembly.GetType(pluginType + "");
                var plugin = new AvailablePlugin
                {
                    Path = fileName,
                    Instance = (IPlugin)Activator.CreateInstance(type)
                };

                plugin.Instance.Host = this;
                plugin.Instance.Initialize();
                colAvailablePlugins.Add(plugin);
            }
        }

        public void FeedBack(string feedBack, IPlugin plugin) { return; }
        public bool Register(IPlugin plugin) { return true; }
        public void LoadPlugins() { return; }
    }
}