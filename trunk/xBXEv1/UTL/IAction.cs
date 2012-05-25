using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTL
{
    public interface IAction
    {
        bool Add { set; get; }
        bool Edit { set; get; }
        bool Delete { set; get; }
        bool Query { set; get; }
        bool Print { set; get; }
        bool Full { set; get; }
        bool None { set; get; }
    }
}