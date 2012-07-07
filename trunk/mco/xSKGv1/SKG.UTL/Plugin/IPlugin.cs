using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.UTL.Plugin
{
    using System.Windows.Forms;

    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }
        string Author { get; }
        string Version { get; }

        Form Form { get; }
        IHost Host { get; set; }

        void Initialize();
        void Dispose();
    }
}