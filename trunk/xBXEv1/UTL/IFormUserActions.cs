using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTL
{
    public interface IFormUserActions
    {
        //bool Add { set; get; }
        //bool Edit { set; get; }
        //bool Delete { set; get; }
        //bool Query { set; get; }
        //bool Print { set; get; }
        //bool Full { set; get; }
        //bool None { set; get; }

        bool EnableAdd { get; set; }
        bool EnableEdit { get; set; }
        bool EnableDelete { get; set; }
        bool EnableQuery { get; set; }
        bool EnablePrintPreview { get; set; }

        bool EnableTest { get; set; }
        bool EnableVerify { get; set; }

        bool CancelClosed { get; set; }
        bool Denied { get; set; }

        Actions UserActions { get; set; }
    }
}