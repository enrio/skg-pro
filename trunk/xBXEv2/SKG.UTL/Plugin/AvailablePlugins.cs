using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.UTL.Plugin
{
    using System.Collections;

    public class AvailablePlugins : CollectionBase
    {
        public AvailablePlugins() { }
        public AvailablePlugins(int capacity) : base(capacity) { }

        public void Add(AvailablePlugin pluginToAdd) { List.Add(pluginToAdd); }
        public void Remove(AvailablePlugin pluginToRemove) { List.Remove(pluginToRemove); }

        /// <summary>
        /// Find plugin
        /// </summary>
        /// <param name="s">Plugin name or path</param>
        /// <returns></returns>
        public AvailablePlugin Find(string s)
        {
            AvailablePlugin a = null;
            foreach (AvailablePlugin i in List)
            {
                if ((i.Instance.Name.Equals(s)) || i.Path.Equals(s))
                {
                    a = i;
                    break;
                }
            }
            return a;
        }
    }
}