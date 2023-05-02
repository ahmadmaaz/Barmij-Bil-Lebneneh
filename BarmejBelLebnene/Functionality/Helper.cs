using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BarmejBelLebnene.Functionality
{
    internal class Helper
    {
        public static void removeExtraSpace(ref String s)
        {
            s = Regex.Replace(s, @"\s+", " ");
        }

    }
}
