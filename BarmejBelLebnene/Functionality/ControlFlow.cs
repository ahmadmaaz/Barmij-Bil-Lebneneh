using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarmejBelLebnene.Functionality
{
    internal abstract class ControlFlow
    {
        protected StringBuilder sb = new StringBuilder();
        protected abstract void compute(string s);
    }
}
