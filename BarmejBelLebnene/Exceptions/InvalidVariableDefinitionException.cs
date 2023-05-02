using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarmejBelLebnene.Exceptions
{
    internal class InvalidVariableDefinitionException : Exception
    {
        private string exp;
        public InvalidVariableDefinitionException(String s)
        {
            this.exp = s;
        }
        public override String ToString()
        {
            return exp;
        }
    }
}
