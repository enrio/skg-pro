using System;

namespace UTL
{
    public sealed class CsoInf
    {
        public string Msg { set; get; }
        public bool Err { set; get; }

        public void Show() { if (Err) UTL.CsoUTL.Show(Msg); }
    }
}