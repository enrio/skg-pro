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
        private List<Plugin> _plugins = new List<Plugin>();
        /// <summary>
        /// Available all plugins
        /// </summary>
        public List<Plugin> Plugins
        {
            get { return _plugins; }
            set { _plugins = value; }
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
                foreach (string fileOn in Directory.GetFiles(path))
                {
                    FileInfo file = new FileInfo(fileOn);

                    #region Skip
                    if (file.Name.Contains("UTL.dll")) continue;
                    if (file.Name.Contains("DAL.dll")) continue;
                    if (file.Name.Contains("BLL.dll")) continue;
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
            foreach (Plugin pluginOn in _plugins)
            {
                pluginOn.Instance.Dispose();
                pluginOn.Instance = null;
            }
            _plugins.Clear();
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
                #region Skip
                if (!pluginType.IsPublic || pluginType.IsAbstract) continue;
                var iPlugin = pluginType.GetInterface(typeof(IPlugin).FullName, true);
                if (iPlugin == null) continue;
                #endregion

                var type = pluginAssembly.GetType(pluginType + "");
                var plugin = new Plugin
                {
                    Path = fileName,
                    Instance = (IPlugin)Activator.CreateInstance(type)
                };

                plugin.Instance.Host = this;
                plugin.Instance.Initialize();
                _plugins.Add(plugin);
            }
        }

        public void FeedBack(string feedBack, IPlugin plugin) { return; }
        public bool Register(IPlugin plugin) { return true; }
        public void LoadPlugins() { return; }
    }
}