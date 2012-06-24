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
        public Menu(string c) { _c = c; }

        ///// <summary>
        ///// Select menu's level
        ///// </summary>
        ///// <param name="c">Menu's name</param>
        ///// <returns></returns>
        //public List<AvailablePlugin> Select(string c)
        //{
        //    var a = XDocument.Load(_c);
        //    var b = from s in a.Descendants(c)
        //            select new
        //            {
        //                Vn = s.Attribute("vn"),
        //                En = s.Attribute("en"),
        //                Ns = s.Attribute("ns")
        //            };
        //    var l = new List<AvailablePlugin>();
        //    foreach (var i in b)
        //    {
        //        var p = new AvailablePlugin()
        //        {
        //            Text1 = i.Vn.Value,
        //            Text2 = i.En.Value,
        //            Type = i.Ns.Value
        //        };
        //        l.Add(p);
        //    }
        //    return l;
        //}

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
                        Id = s.Element("Id").Value,
                        ParentId = s.Element("ParentId").Value,
                        Text1 = s.Element("Text1").Value,
                        Text2 = s.Element("Text2").Value,
                        Type = s.Element("Type").Value,
                        Show = s.Element("Show").Value,
                        Order = s.Element("Order").Value
                    };
            var l = new List<AvailablePlugin>();
            foreach (var s in b)
            {
                var p = new AvailablePlugin()
                {
                    Id = s.Id,
                    ParentId = s.ParentId,
                    Text1 = s.Text1,
                    Text2 = s.Text2,
                    Type = s.Type,
                    Show = Convert.ToBoolean(s.Show),
                    Order = Convert.ToInt32(s.Order)
                };
                l.Add(p);
            }
            return l;
        }
    }
}