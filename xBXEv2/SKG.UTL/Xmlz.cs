using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.UTL
{
    using System.Xml.Linq;

    public class Xmlz
    {
        string _c;

        public Xmlz(string c = @"D:\HgqOhc\NL\xBXEv2\EXE\Plugins\xBXEv1.dll")
        {
            _c = c + ".config";
        }

        public List<PlugInfo> Select(string c)
        {
            var a = XDocument.Load(_c);
            var b = from s in a.Descendants(c)
                    select new
                    {
                        Vn = s.Attribute("vn"),
                        En = s.Attribute("en"),
                        Ns = s.Attribute("ns")
                    };
            var l = new List<PlugInfo>();
            foreach (var i in b)
            {
                var p = new PlugInfo()
                {
                    Vn = i.Vn.Value,
                    En = i.En.Value,
                    Ns = i.Ns.Value
                };
                l.Add(p);
            }
            return l;
        }

        public class PlugInfo
        {
            public string Vn { set; get; }
            public string En { set; get; }
            public string Ns { set; get; }
        }
    }
}