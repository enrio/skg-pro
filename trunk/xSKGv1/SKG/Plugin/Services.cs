using System;
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
        #region Implement
        /// <summary>
        /// Feed back
        /// </summary>
        /// <param name="feedBack">Feed back</param>
        /// <param name="plugin">Plugin</param>
        public void FeedBack(string feedBack, IPlugin plugin) { return; }

        /// <summary>
        /// Register plugin
        /// </summary>
        /// <param name="plugin">Plugin</param>
        /// <returns></returns>
        public bool Register(IPlugin plugin) { return true; }

        /// <summary>
        /// Load all plugins
        /// </summary>
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

                var type = pluginAssembly.GetType(pluginType.FullName);
                var plugin = new Plugin
                {
                    Path = fileName,
                    Instance = (IPlugin)Activator.CreateInstance(type)
                };
                plugin.Instance.Host = this;
                plugin.Instance.Initialize();
                plugin.Menu = plugin.Instance.Menu;
                plugin.Menu.Type = pluginType.FullName;
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
            var path = AppDomain.CurrentDomain.BaseDirectory + "Plugins";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            var lst = new List<string>();
            var dir = new DirectoryInfo(path);

            foreach (DirectoryInfo i in dir.GetDirectories())
            {
                var a = FindPlugin(i.FullName);
                var b = GetPlugin(a);
                var r = from s in b
                        orderby s.Menu.Order
                        select s.Menu;
                var c = r.ToDataTable(false, typeof(Menuz).Name);
                lst.Add(i.FullName + @"\");
                var file = String.Format("{0}.xml", a);
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