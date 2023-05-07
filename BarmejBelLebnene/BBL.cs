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

        public static Dictionary<string, string> variables = new Dictionary<string, string>(); //Hashmap to store variables
        StringBuilder sb;


        /*
         * 
         * Initiliaze the  String builder
         * Call the setup and program funcs  
         * 
         */

        public BBL(string s)
        {
            sb = new StringBuilder();
            variables = new Dictionary<string, string>();

            //To make sure that every BBL program has #barmajeh and #tejhiz
            if (!s.Contains("#tejhiz") || !s.Contains("#barmajeh"))
            {
                bool tejhizFound = s.Contains("#tejhiz");
                throw new FunctionNotFound(tejhizFound ? "#barmajeh" : "#tejhiz");
            }


            setup(s.Split("#tejhiz")[1].Split("#")[0].Trim());
            program(s.Split("#barmajeh")[1]);

        }
        public override string ToString()
        {
            return sb.ToString();
        }




        /**
         * 
         * Setup function -  convert variable definitions in #tejhiz to assembly 
         * 
         */
        private void setup(string s)
        {
            string[] variablesExp = s.Split("\n\t");
            int counter = 0;
            foreach (string variable in variablesExp)
            {
                if (string.IsNullOrEmpty(variable)) continue;
                if (!Regex.IsMatch(variable, RegexPatterns.DefineVarPattern)) throw new InvalidVariableDefinitionException(variable);
                string name = variable.Split("ra2m")[1].Split('=')[0];   // Get the variable name
                string value = variable.Split("ra2m")[1].Split('=')[1];  // Get the variable value
                variables.Add(name.Trim(), "R" + counter);
                sb.Append($"mov R{counter},#{value.Trim()}\n");
                counter++;
            }
        }



        /*
         * 
         * Program function - convert every expression in #barmajeh from BBL to assembly 
         * 
         */
        private string program(string s)
        {
            string[] programStatements = s.Split("\n\t"); // Split the Statements by "\n" 
            for (int i = 0; i < programStatements.Length; i++)
            {
                if (programStatements[i].Trim().StartsWith("min")) // detect if its a loop expression
                {
                    //If its a for loop, we get all expressions after this for loop and add them to a string builder so we can convert the for loop 
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
                    ForLoop forLoop = new ForLoop(fs.ToString());
                    sb.AppendLine(forLoop.ToString());
                }


            }
            return s;
        }


        /**
         * 
         * Static function - get variable value from the variables dictionary
         * 
         */
        public static string getVariableValue(string variableName)
        {

            if (variables.ContainsKey(variableName.Trim()))
            {
                return variables[variableName.Trim()];
            }
            int num;
            if (int.TryParse(variableName, out num))
            {
                return $"#{variableName.Trim()}";
            }
            else
            {
                throw new UndefinedVariabledException(variableName);
            }
        }



        /**
         * 
         * 
         * Generate random code - get random BBL code 
         * 
         */
        public static string generateRandomCode()
        {
            string[] randomCode = new string[]
            {
                "#tejhiz\r\n\tra2m i =0\r\n\tra2m j=0\r\n#barmajeh\r\n\tmin i la 10:\r\n\t\tzid i 3a j",
                "#tejhiz\r\n\tra2m i =0\r\n\tra2m j=0\r\n\tra2m z=0\r\n#barmajeh\r\n\tmin i la 10:\r\n\t\tzid i 3a j\r\n\t\tzid i,j 3a z",
                "#tejhiz\r\n\tra2m i =0\r\n\tra2m z=6\r\n#barmajeh\r\n\tmin i la 2:\r\n\t\tna2es i mn z",
                "#tejhiz\r\n\tra2m i =0\r\n\tra2m test=0\r\n#barmajeh\r\n\tmin i lja 2:\r\n\t\tzid i 3a test",
                "#tejhiz\r\n\tra2m i =0\r\n\tra2m test=0\r\n\tra2m z=0\r\n#barmajeh\r\n\tmin i la 2:\r\n\t\tmin z la 7:\r\n\t\t\tzid i 3a test\r\n\t\t\tzid z 3a test\r\n\t\t\tna2es i mn test"

            };
            Random random = new Random();
            return randomCode[random.Next(randomCode.Length)];
        }
    }
}
