using System;
using System.Collections;

namespace SKG.PlugTypes
{
    public class AvailablePlugins : CollectionBase
    {
        public AvailablePlugins() { }
        public AvailablePlugins(int capacity) : base(capacity) { }

        public void Add(AvailablePlugin pluginToAdd) { List.Add(pluginToAdd); }
        public void Remove(AvailablePlugin pluginToRemove) { List.Remove(pluginToRemove); }

        public AvailablePlugin Find(string pluginNameOrPath)
        {
            AvailablePlugin toReturn = null;
            foreach (AvailablePlugin pluginOn in List)
            {
                if ((pluginOn.Instance.Name.Equals(pluginNameOrPath)) || pluginOn.AssemblyPath.Equals(pluginNameOrPath))
                {
                    toReturn = pluginOn;
                    break;
                }
            }
            return toReturn;
        }
    }
}