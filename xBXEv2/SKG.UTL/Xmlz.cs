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

        public List<dynamic> Select(string c)
        {
            var loaded = XDocument.Load(_c);

            var project = from s in loaded.Descendants(c)
                          select new
                          {
                              Vn = s.Attribute("vn"),
                              En = s.Attribute("en"),
                              Ns = s.Attribute("ns")
                          };
            return project.ToList<dynamic>();
        }

        public class PlugInfo
        {
            public string Vn { set; get; }
            public string En { set; get; }
            public string Ns { set; get; }
        }
    }
}