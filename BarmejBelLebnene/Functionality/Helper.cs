using BarmejBelLebnene.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BarmejBelLebnene.Functionality
{

    /*
     * 
     * Contains Functions that can help throughout the program 
     * 
     */
    internal class Helper
    {

        /**
         * 
         * removeExtraSpace - remove unnecessary whitespaces in expressions
         * 
         */
        public static void removeExtraSpace(ref String s)
        {
            s = Regex.Replace(s, @"\s+", " ");
        }


        public static string computeExpression(string expression)
        {

            if (Regex.IsMatch(expression, RegexPatterns.varAdditionPattern))
            {
                return ArithmaticOperations.varAdditionOnInitial(expression);
            }
            else if (Regex.IsMatch(expression, RegexPatterns.varSubtractionPattern))
            {
                return ArithmaticOperations.varSubtractionOnInitial(expression);
            }

            throw new InvalidArithmaticOperation(expression);
        }

    }
}
