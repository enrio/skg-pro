﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.UTL.Plugin
{
    public interface IHost
    {
        void FeedBack(string feedBack, IPlugin plug);
        bool Register(IPlugin plug);
        void LoadPlugins();
    }
}