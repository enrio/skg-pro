#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 23/07/2012 22:19
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG
{
    using Extend;
    using Plugin;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

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

        #region Methods
        /// <summary>
        /// Return all plugin
        /// </summary>
        /// <param name="fileName">Path file name</param>
        /// <returns></returns>
        public List<Plugins> GetPlugins(string fileName)
        {
            try
            {
                var lst = new List<Plugins>();
                var pluginAssembly = Assembly.LoadFrom(fileName);

                foreach (Type pluginType in pluginAssembly.GetTypes())
                {
                    #region Skip
                    if (!pluginType.IsPublic || pluginType.IsAbstract) continue;
                    var iPlugin = pluginType.GetInterface(typeof(IPlugin).FullName, true);
                    if (iPlugin == null) continue;
                    #endregion

                    var type = pluginAssembly.GetType(pluginType.FullName);
                    var plugin = new Plugins
                    {
                        Path = fileName,
                        Instance = (IPlugin)Activator.CreateInstance(type)
                    };

                    plugin.Instance.Host = this;
                    plugin.Instance.Initialize();

                    plugin.Menuz = plugin.Instance.Menuz;
                    plugin.Menuz.Code = pluginType.FullName;

                    if (plugin.Menuz.Level > 0) lst.Add(plugin);
                }
                return lst;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }

        /// <summary>
        /// Return list path of plugin and write menu XML menu file
        /// </summary>
        /// <returns></returns>
        public List<string> GetPlugins()
        {
            try
            {
                var lst = new List<string>();
                string[] files = Directory.GetFiles(Application.StartupPath, "*.dll", SearchOption.AllDirectories);

                foreach (var i in files)
                {
                    var b = GetPlugins(i);
                    var r = from s in b
                            orderby s.Menuz.Order
                            select s.Menuz;
                    if (r.Count() > 0)
                    {
                        lst.Add(i);
                        var c = r.ToDataTable(false, typeof(Menuz).Name);
                        var file = String.Format("{0}.xml", i);
#if DEBUG
                        c.WriteXml(file);
#else
                        if (!File.Exists(file)) c.WriteXml(file);
#endif
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }

        /// <summary>
        /// Get menu of a plugin
        /// </summary>
        /// <param name="s">Plugin file name</param>
        /// <returns></returns>
        public static List<Menuz> GetMenu(string s)
        {
            try
            {
                var name = typeof(Menuz).Name;
                var file = String.Format("{0}.xml", s);
                return file.ToMenu(name);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }

        /// <summary>
        /// Get all menu of plugins
        /// </summary>
        /// <param name="l">List all of plugin file name</param>
        /// <returns></returns>
        public static List<Menuz> GetMenu(List<string> l)
        {
            try
            {
                var menu = new List<Menuz>();
                foreach (var i in l) menu.AddRange(GetMenu(i));
                return menu;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }
        #endregion
    }
}