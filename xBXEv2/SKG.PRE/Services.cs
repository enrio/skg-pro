using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.PRE
{
    using UTL.Plugin;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// Services for plugin
    /// </summary>
    public class Services : IHost
    {
        private AvailablePlugins _availablePlugins = new AvailablePlugins();

        /// <summary>
        /// Available all plugins
        /// </summary>
        public AvailablePlugins AvailablePlugins
        {
            get { return _availablePlugins; }
            set { _availablePlugins = value; }
        }

        /// <summary>
        /// Find all plugins
        /// </summary>
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
                _availablePlugins.Clear();
                foreach (string fileOn in Directory.GetFiles(path))
                {
                    FileInfo file = new FileInfo(fileOn);

                    #region Skip
                    if (file.Name.Contains("UTL.dll")) continue;
                    if (file.Name.Contains("DAL.dll")) continue;
                    if (file.Name.Contains("BLL.dll")) continue;
                    if (file.Name.Contains("PRE.exe")) continue;
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
            foreach (AvailablePlugin pluginOn in _availablePlugins)
            {
                pluginOn.Instance.Dispose();
                pluginOn.Instance = null;
            }
            _availablePlugins.Clear();
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
                if (!pluginType.IsPublic) continue;
                if (pluginType.IsAbstract) continue;

                var a = pluginType.GetInterface(typeof(IPlugin).FullName, true);
                if (a == null) continue;

                var type = pluginAssembly.GetType(pluginType + "");
                var plugin = new AvailablePlugin
                {
                    Path = fileName,
                    Instance = (IPlugin)Activator.CreateInstance(type)
                };

                plugin.Instance.Host = this;
                plugin.Instance.Initialize();
                _availablePlugins.Add(plugin);
            }
        }

        public void FeedBack(string feedBack, IPlugin plugin) { return; }
        public bool Register(IPlugin plugin) { return true; }
        public void LoadPlugins() { return; }
    }
}