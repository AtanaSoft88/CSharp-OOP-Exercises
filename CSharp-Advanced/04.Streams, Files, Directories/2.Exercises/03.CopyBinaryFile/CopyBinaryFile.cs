using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\copyMe.png";
            string outputPath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputPath, outputPath);
            
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using FileStream fileReader = new FileStream(inputFilePath, FileMode.Open);
            using FileStream fileWriter = new FileStream(outputFilePath, FileMode.Create);

            byte[] buffer = new byte[2048];
            int currentBufferSize = 0;
            while (true)
            {
                currentBufferSize = fileReader.Read(buffer, 0, buffer.Length);
                if (currentBufferSize == 0)
                {
                    break;
                }
                fileWriter.Write(buffer, 0, buffer.Length);
            }
            



            
        }
    }
}
