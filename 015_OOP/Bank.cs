using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015_OOP
{
    /// <summary>
    /// Base class. 
    /// </summary>
    internal abstract class Bank
    {
        protected string pin = "0000";

        public abstract void Hello();
    }
}
