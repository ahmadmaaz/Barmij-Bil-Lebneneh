using BarmejBelLebnene.Exceptions;
using Microsoft.VisualBasic.Devices;
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
            string[] fs = s.Split("\n"); // Get the loop expression

            if (!Regex.IsMatch(fs[0].Trim(), RegexPatterns.ForStatementPattern)) throw new InvalidForLoopDefinitionException(fs[0]);
            string[] forParam = fs[0].Split(" ");
            string startVar = BBL.getVariableValue(forParam[1]);
            string toVal = BBL.getVariableValue(forParam[3].Split(':')[0]);
            string[] minList = s.Split(new string[] { "min" }, StringSplitOptions.None);
            if (minList.Length - 1 >1)  
            {
                string incrementExpression = $"add {startVar},{startVar},#1\n";
                string[] forParamSecond = fs[1].Split(" ");
                string startVarSecond = BBL.getVariableValue(forParamSecond[1]);

                string firstLoop = $"for0: cmp {startVar},{toVal}\nbgt end\n{incrementExpression}mov {startVarSecond},#0\nb for1\n";
                string[] tempFs = s.Split("\r");
                tempFs[0] = "";
                return firstLoop + computeNestedForLoop(string.Join(" ", tempFs).Trim(), 1) + "\nend:";
            }


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


            return generateForLoop(startVar, toVal, assemblyExp.ToString()); ;

        }


        private string computeNestedForLoop(string s,int forLoopNmb)
        {
            string[] fs = s.Split("\n"); // Get the loop expression
            string[] minList = s.Split(new string[] { "min" }, StringSplitOptions.None);
            string[] forParam = fs[0].Split(" ");
            string startVar = BBL.getVariableValue(forParam[1]);
            string toVal = BBL.getVariableValue(forParam[3].Split(':')[0]);
            if (minList.Length - 1 > 1)  // Only 2 nested loops 
            {
              
                string[] tempFs = s.Split("\n");
                tempFs[0] = "";

                return generateNestedForLoop(startVar, toVal, "", forLoopNmb) +"\n"+ computeNestedForLoop(string.Join(" ",tempFs).Trim(),forLoopNmb+1);
            }

            StringBuilder assemblyExp = new StringBuilder();
            string[] insideExp = s.Split(":")[1].Split("\n\t");

            for (int i = 0; i < insideExp.Length; i++)
            {
                
                Helper.removeExtraSpace(ref insideExp[i]);
                string expression = insideExp[i].Trim();
                if (string.IsNullOrEmpty(expression)) //To skip empty lines
                {
                    continue;
                }
                assemblyExp.AppendLine(computeExpression(expression.Trim()));
            }

            return generateNestedForLoop(startVar, toVal, assemblyExp.ToString(),forLoopNmb); ;

        }

        /**
         * 
         * Convert every expression in for loop to assembly expression
         * 
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

        private string generateNestedForLoop(string startVar, string toVal, string assemblyExp,int nmb)
        {
            string incrementExpression = $"add {startVar},{startVar},#1\n";
            return $"for{nmb}: cmp {startVar},{toVal}\nbgt for{nmb-1}\n{assemblyExp}{incrementExpression}b for{nmb}\n";
        }
        

    }
}
