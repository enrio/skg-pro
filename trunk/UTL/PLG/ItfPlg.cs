using System;
using System.Windows.Forms;

namespace UTL.PLG
{
    public interface ItfPlg
    {
        string Name { get; }
        string Description { get; }
        string Author { get; }
        string Version { get; }

        UserControl Usrcontrol { get; }
        Form Frmcontrol { get; }
        ItfHst Host { get; set; }

        UTL.BLL.UecLajVei Sss { get; set; }
        UTL.CsoInf Inf { set; get; }

        void Initialize();
        void Dispose();
    }
}