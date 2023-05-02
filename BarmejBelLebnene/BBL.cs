using BarmejBelLebnene.Exceptions;
using BarmejBelLebnene.Functionality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BarmejBelLebnene
{
    internal class BBL
    {
        public static Dictionary<string, string> variables;
        StringBuilder sb;
        public BBL(string s)
        {
            sb = new StringBuilder();
            variables = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(s.Trim()))
            {
                setup(s.Split("#tejhiz")[1].Split("#")[0].Trim());
                program(s.Split("#barmajeh")[1]);
            }

        }
        public override string ToString()
        {
            return sb.ToString();
        }
        private void setup(string s)
        {
            string[] variablesExp = s.Split("\n\t");
            int counter = 0;
            foreach (string variable in variablesExp)
            {
                if (string.IsNullOrEmpty(variable)) continue;
                if (!Regex.IsMatch(variable, RegexPatterns.DefineVarPattern)) throw new InvalidVariableDefinitionException(variable);
                string name = variable.Split("ra2m")[1].Split('=')[0];
                string value = variable.Split("ra2m")[1].Split('=')[1];
                variables.Add(name.Trim(), "R" + counter);
                sb.Append($"mov R{counter},#{value.Trim()}\n");
                counter++;
            }

        }

        private string program(string s)
        {
            string[] programStatements = s.Split("\n\t");
            for (int i = 0; i < programStatements.Length; i++)
            {
                if (programStatements[i].StartsWith("min"))
                {
                    StringBuilder fs = new StringBuilder();
                    fs.Append(programStatements[i] + "\n");
                    for (int j = i + 1; j < programStatements.Length; j++)
                    {
                        if (programStatements[j].StartsWith("\t"))
                        {
                            fs.Append(programStatements[j] + "\n");
                            i++;
                            continue;
                        }
                        break;
                    }
                    ForLoop forLoop = new ForLoop(variables);
                    sb.AppendLine(forLoop.computeFor(fs.ToString()));
                    //computeFor(fs.ToString());
                }


            }
            return s;
        }

        public static string getVariableValue(string variableName)
        {
            if (variables.ContainsKey(variableName.Trim()))
            {
                return variables[variableName.Trim()];
            }
            return $"#{variableName.Trim()}";
        }
    }
}
