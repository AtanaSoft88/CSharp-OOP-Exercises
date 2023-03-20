using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _00.Demo_Writing_into_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            HashSet<int> uniqueNumbers = new HashSet<int>();           
            
            while (uniqueNumbers.Count != 6)
            {
                string currentluckyNumbers = rnd.Next(1, 50).ToString();
                uniqueNumbers.Add(int.Parse(currentluckyNumbers));            
                
            }            

            string outputPath = @"..\..\..\LuckyNumbers.txt";
            using FileStream fileStrm = File.Open(outputPath, FileMode.Append); // will append to end of file
            using StreamWriter writer = new StreamWriter(fileStrm);
            writer.WriteLine(string.Join(",", uniqueNumbers));
            Console.WriteLine(string.Join("|", uniqueNumbers));
        }
    }
}
