using System;

namespace UTL.PLG
{
    public interface ItfHst
    {
        void FeedBack(string feedBack, ItfPlg plug);
        bool Register(ItfPlg plug);
        void LoadPlugins();
    }
}