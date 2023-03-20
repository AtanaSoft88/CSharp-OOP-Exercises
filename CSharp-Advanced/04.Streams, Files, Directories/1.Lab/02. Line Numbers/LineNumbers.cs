namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using (StreamWriter strmWriter = new StreamWriter(outputFilePath))
            {

                using (StreamReader strmReader = new StreamReader(inputFilePath))
                {
                   
                    string readTxt = strmReader.ReadLine();
                    int indexer = 1; 
                    while (readTxt != null)
                    {
                        strmWriter.WriteLine($"{indexer}. {readTxt}");

                        readTxt = strmReader.ReadLine();
                        indexer++;
                    }
                    
                }
            }
        }
    }
}
