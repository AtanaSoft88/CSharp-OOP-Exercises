namespace MergeFiles
{
    using System;
    using System.IO;
    

    public class MergeFiles
    {
        static void Main(string[] args)
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            


            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {

            string[] readFirst = File.ReadAllText(firstInputFilePath).Split();
            string[] readSecond = File.ReadAllText(secondInputFilePath).Split();
            File.WriteAllText(outputFilePath,"");
            for (int i = 0; i < readFirst.Length; i++)
            {
                File.AppendAllText(outputFilePath, readFirst[i] + Environment.NewLine + readSecond[i]);
            }
        }
    }
}
