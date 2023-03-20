
namespace OddLines
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class OddLines
    {
        static async Task Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

          await ExtractOddLines(inputPath, outputPath);
        }

        public static async Task ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamWriter strmWriter = new StreamWriter(outputFilePath))
            {
                
                using (StreamReader strmReader = new StreamReader(inputFilePath))
                {
                    string readTxt = await strmReader.ReadLineAsync();
                   int index = 0;

                    while (readTxt != null)
                    {
                        if (index %2 != 0)
                        {
                          await strmWriter.WriteLineAsync(readTxt);
                        }
                        readTxt = await strmReader.ReadLineAsync();

                        index++;
                    }
                }
            }

            
        }
    }
}
