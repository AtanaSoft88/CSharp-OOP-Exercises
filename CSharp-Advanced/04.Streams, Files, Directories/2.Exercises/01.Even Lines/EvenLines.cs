using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EvenLines
{
    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFile = @"..\..\..\text.txt";
            Console.WriteLine(ProcessLines(inputFile));
        }
        public static string ProcessLines(string inputFilePath)
        {
            StreamReader streamReader = new StreamReader(inputFilePath);
            string[] chars = new string[] { "-", ",", ".", "!", "?" };
            List<string> newLines = new List<string>();
            int line = 0;
            while (true)
            {
                string result = streamReader.ReadLine();

                if (result == null)
                {
                    break;
                }

                if (line % 2 == 0)
                {
                    foreach (var item in chars)
                    {
                        result = result.Replace(item, "@");
                    }

                    var line1 = result.Split(" ").Reverse().ToArray();
                    newLines.Add(string.Join(" ", line1));
                }
                line++;
            }

            string newString = string.Join("\n", newLines);


            return newString;
        }
    }
}