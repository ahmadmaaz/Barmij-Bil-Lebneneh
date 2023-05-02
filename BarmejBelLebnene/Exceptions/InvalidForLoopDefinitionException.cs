using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarmejBelLebnene.Exceptions
{
    internal class InvalidForLoopDefinitionException : Exception
    {
        private string exp;
        public InvalidForLoopDefinitionException(String s)
        {
            this.exp = s;
        }
        public override String ToString()
        {
            return exp;
        }
    }
}
