using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015_OOP
{
    internal sealed class BnlBankFree : BnlBank // sealed prevent other classes from intheriting from it
    {
        public BnlBankFree()
        {
        }

        public override string Plan { get => base.Plan; set => base.Plan = "Free"; }
    }
}
