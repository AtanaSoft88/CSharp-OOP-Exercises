namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class WordCount
    {
        static async Task Main(string[] args)
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

           await CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static async Task CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            using StreamReader strmWordsFile = new StreamReader(wordsFilePath);
            using StreamReader strmTextFile = new StreamReader(textFilePath);
            using StreamWriter wrt = new StreamWriter(outputFilePath);

            string wordsOccurrance = await strmWordsFile.ReadToEndAsync();
            string textToSearch = await strmTextFile.ReadToEndAsync();

            string[] outpWord = wordsOccurrance.ToLower().Split(new char[] { ' ', '.', ',', '-', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] outpTxt = textToSearch.ToLower().Split(new char[] { ' ', '.', ',', '-', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in outpTxt)
            {
                if (outpWord.Contains(word))
                {
                    if (!dict.ContainsKey(word))
                    {
                        dict.Add(word, 0);
                    }
                    dict[word]++;
                }
            }
            dict = dict.OrderByDescending(x=>x.Value).ToDictionary(x=>x.Key,x=>x.Value);

            foreach (var item in dict)
            {
              await  wrt.WriteLineAsync($"{item.Key} - {item.Value}");
            }
            
        }
    }
}
