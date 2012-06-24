using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.PRE.PlugTypes
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
            AvailablePlugin toReturn = null;
            foreach (AvailablePlugin i in List)
            {
                if ((i.Instance.Name.Equals(s)) || i.AssemblyPath.Equals(s))
                {
                    toReturn = i;
                    break;
                }
            }
            return toReturn;
        }
    }
}