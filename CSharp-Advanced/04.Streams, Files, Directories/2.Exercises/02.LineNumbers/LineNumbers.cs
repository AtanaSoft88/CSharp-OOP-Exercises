namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        public static List<string> GetLettersAndPunctuationCount(List<string> listInput, List<string> listResult)
        {            
            int lettersCount = 0;
            int punctuationCount = 0;
            for (int i = 0; i < listInput.Count; i++)
            {
                lettersCount = listInput[i].Count(x => char.IsLetter(x));
                punctuationCount = listInput[i].Count(x => char.IsPunctuation(x));

                listResult.Add($"({lettersCount})({punctuationCount})");
            }

            return listResult;


            //foreach (var item in listWords)
            //{
            //    var lettersCount = 0;
            //    int punctuationCount = 0;
            //    string current = item.ToString();
            //    foreach (var ch in current)
            //    {
            //        if (char.IsLetter(ch))
            //        {
            //            lettersCount++; 
            //        }
            //        else if (char.IsPunctuation(ch))
            //        {
            //            punctuationCount++;
            //        }
            //    }
            //    listResult.Add($"({lettersCount})({punctuationCount})");
            //}

        }
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using StreamReader str = new StreamReader(inputFilePath);
            List<string> listWords = new List<string>();
            string currentLine = str.ReadLine();
            int countLines = 0;
            while (currentLine != null)
            {
                listWords.Add(string.Join(' ', currentLine));

                currentLine = str.ReadLine();
            }
            List<string> listResult = new List<string>();
            GetLettersAndPunctuationCount(listWords, listResult);
                   
                        
            using StreamWriter writer = new StreamWriter(outputFilePath);

            for (int i = 0; i < listWords.Count; i++)
            {
                writer.WriteLine($"Line {i+1}: {listWords[i]} {listResult[i]}");
            }
           
        }
    }
}
