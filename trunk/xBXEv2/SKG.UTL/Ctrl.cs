﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.UTL
{
    using System.Windows.Forms;

    public static class Ctrl
    {
        public static string FullName(this Form f)
        {
            return f.GetType().FullName;
        }
    }
}