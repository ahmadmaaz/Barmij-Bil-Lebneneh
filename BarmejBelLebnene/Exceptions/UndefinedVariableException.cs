using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarmejBelLebnene.Exceptions
{

    internal class UndefinedVariabledException : Exception
    {
        private string exp;
        public UndefinedVariabledException(String s)
        {
            this.exp = s;
        }
        public override String ToString()
        {
            return exp;
        }
    }
}