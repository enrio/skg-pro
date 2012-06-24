using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.UTL.Plugin
{
    using System.Xml.Linq;

    /// <summary>
    /// Load plugin's menu
    /// </summary>
    public class Menu
    {
        readonly string _c;

        /// <summary>
        /// Load plugin's menu
        /// </summary>
        /// <param name="c">App.Config file</param>
        public Menu(string c) { _c = c + ".config"; }

        /// <summary>
        /// Select menu's level
        /// </summary>
        /// <param name="c">Menu's name</param>
        /// <returns></returns>
        public List<AvailablePlugin> Select(string c)
        {
            var a = XDocument.Load(_c);
            var b = from s in a.Descendants(c)
                    select new
                    {
                        Vn = s.Attribute("vn"),
                        En = s.Attribute("en"),
                        Ns = s.Attribute("ns")
                    };
            var l = new List<AvailablePlugin>();
            foreach (var i in b)
            {
                var p = new AvailablePlugin()
                {
                    Vn = i.Vn.Value,
                    En = i.En.Value,
                    Ns = i.Ns.Value
                };
                l.Add(p);
            }
            return l;
        }
    }
}