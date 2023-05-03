using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarmejBelLebnene.Functionality
{
    internal class ArithmaticOperations
    {

        public static string varAdditionOnInitial(String expression)
        {
            string target= BBL.getVariableValue(expression.Split("3a")[1].Trim());
            string[] operands = expression.Split("3a")[0].Split("zid")[1].Split(",");
            StringBuilder varAdditionExps = new StringBuilder();
            for(int i = 0; i < operands.Length; i++)
            {
                varAdditionExps.AppendLine($"add {target},{target},{BBL.getVariableValue(operands[i])}");   
            }
            return varAdditionExps.ToString();

        }

        public static string varSubtractionOnInitial(String expression)
        {
            string target = BBL.getVariableValue(expression.Split("mn")[1].Trim());
            string[] operands = expression.Split("zid")[0].Split("na2es")[1].Split(",");
            StringBuilder varAdditionExps = new StringBuilder();
            for (int i = 0; i < operands.Length; i++)
            {
                varAdditionExps.AppendLine($"sub {target},{target},{BBL.getVariableValue(operands[i])}");
            }
            return varAdditionExps.ToString();
        }

    }

}
