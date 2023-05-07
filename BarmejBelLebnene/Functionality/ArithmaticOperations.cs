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
            //eg. zid i,j 3a z

            string target = BBL.getVariableValue(expression.Split("3a")[1].Trim());   // Get the variable that we want to add values to it
            string[] operands = expression.Split("3a")[0].Split("zid")[1].Split(",");   //Get all operands that we want to add them on the inital variable
            StringBuilder varAdditionExps = new StringBuilder();
            for (int i = 0; i < operands.Length; i++)
            {
                varAdditionExps.AppendLine($"add {target},{target},{BBL.getVariableValue(operands[i])}");
            }
            return varAdditionExps.ToString();

        }

        public static string varSubtractionOnInitial(String expression)
        {
            //eg na2es i,j mn z

            string target = BBL.getVariableValue(expression.Split("mn")[1].Trim());
            string[] operands = expression.Split("mn")[0].Split("na2es")[1].Split(",");   //Get all operands that we want to add them on the inital variable
            StringBuilder varAdditionExps = new StringBuilder();
            for (int i = 0; i < operands.Length; i++)
            {
                varAdditionExps.AppendLine($"sub {target},{target},{BBL.getVariableValue(operands[i])}");
            }
            return varAdditionExps.ToString();
        }

    }

}