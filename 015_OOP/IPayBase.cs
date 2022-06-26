using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015_OOP
{
    internal interface IPayBase
    {
        // Since C# 8 an interface may define a default implementation for members!
        void Version()
        {
            // DEFAULT IMPLEMENTATION

            Console.WriteLine("IPayBase: v0.0.1");
        }
    }
}
