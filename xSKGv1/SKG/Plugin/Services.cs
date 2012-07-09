﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.Plugin
{
    using Extend;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// Services for plugin
    /// </summary>
    public class Services : IHost
    {
        #region Old
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

                plugin.Menu = plugin.Instance.Menu;
                plugin.Menu.Type = plugin.Instance.GetType().FullName;

                _plugins.Add(plugin);
            }
        }
        #endregion

        #region Implement
        public void FeedBack(string feedBack, IPlugin plugin) { return; }
        public bool Register(IPlugin plugin) { return true; }
        public void LoadPlugins() { return; }
        #endregion

        #region New
        /// <summary>
        /// Get plugin
        /// </summary>
        /// <param name="fileName">Path file name</param>
        /// <returns></returns>
        public List<Plugin> GetPlugin(string fileName)
        {
            var lst = new List<Plugin>();
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

                plugin.Menu = plugin.Instance.Menu;
                plugin.Menu.Type = plugin.Instance.GetType().FullName;

                lst.Add(plugin);
            }
            return lst;
        }

        /// <summary>
        /// Write Menu.xml file and return list path of plugin
        /// </summary>
        /// <returns></returns>
        public List<string> GetPlugins()
        {
            var lst = new List<string>();
            var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Plugins");

            foreach (DirectoryInfo i in dir.GetDirectories())
            {
                var a = FindPlugin(i.FullName);
                var b = GetPlugin(a);

                var r = from s in b
                        orderby s.Menu.Order
                        select s.Menu;

                var c = r.ToDataTable(false, typeof(Menuz).Name);
                lst.Add(i.FullName + @"\");

                var file = String.Format(@"{0}\{1}.xml", i.FullName, typeof(Menuz).Name);
                if (!File.Exists(file)) c.WriteXml(file);
            }
            return lst;
        }

        /// <summary>
        /// Find plugin
        /// </summary>
        /// <param name="path">Path of plugin</param>
        /// <returns></returns>
        public static string FindPlugin(string path)
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

                    if (file.Extension.Equals(".dll")) return fileOn;
                    if (file.Extension.Equals(".exe")) return fileOn;
                }
                return null;
            }
            catch { return null; }
        }

        /// <summary>
        /// Get all menus of a plugin
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static List<Menuz> GetMenu(string s)
        {
            var name = typeof(Menuz).Name;
            return String.Format(@"{0}\{1}.xml", s, name).ToMenu(name);
        }

        /// <summary>
        /// Get all menus of plugins
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static List<Menuz> GetMenu(List<string> l)
        {
            var menu = new List<Menuz>();
            foreach (var i in l) menu.AddRange(GetMenu(i));
            return menu;
        }
        #endregion
    }
}