using BarmejBelLebnene.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BarmejBelLebnene.Functionality
{
    internal class ForLoop
    {
        private readonly Dictionary<string, string> variables;
        public ForLoop(Dictionary<string, string> variables)
        {
            //Set the variable dictionary
            this.variables = variables;
        }

        public string computeFor(string s)
        {
            string[] fs = s.Split(":"); // Get the loop expression

            if (!Regex.IsMatch(fs[0].Trim(), RegexPatterns.ForStatementPattern)) throw new InvalidForLoopDefinitionException(fs[0]);
            if (fs[1].Contains("min"))
            {

                // Nested loop, do nothing
                return "";
            }
            Helper.removeExtraSpace(ref fs[0]);
            string[] forParam = fs[0].Split(" ");
            string startVar = BBL.getVariableValue(forParam[1]);
            string toVal = BBL.getVariableValue(forParam[3].Split(':')[0]);
            StringBuilder assemblyExp = new StringBuilder();
            string[] insideExp = s.Split(":")[1].Split("\n\t");

            for (int i = 1; i < insideExp.Length; i++)
            {
                Helper.removeExtraSpace(ref insideExp[i]);
                string expression = insideExp[i];
                if (string.IsNullOrEmpty(expression)) //To skip empty lines
                {
                    continue;
                }
                assemblyExp.AppendLine(computeExpression(expression.Trim()));
            }

            string forLoop = generateForLoop(startVar, toVal, assemblyExp.ToString());
            return forLoop;

        }


        /**
         * 
         * Convert every expression in for loop to assembly expression
         * Its either Add or Sub
         *
         */
        private string computeExpression(string expression)
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

        private string generateForLoop(string startVar, string toVal, string assemblyExp)
        {
            string incrementExpression = $"add {startVar},{startVar},#1\n";
            return $"for: cmp {startVar},{toVal}\nbgt end\n{assemblyExp}{incrementExpression}b for\nend:";
        }

    }
}
