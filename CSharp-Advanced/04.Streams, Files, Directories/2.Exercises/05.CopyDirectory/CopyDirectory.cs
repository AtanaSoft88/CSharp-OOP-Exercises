namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main(string[] args)
        {
            string inputPath = @"C:\Users\Naka7a\source\repos\Advanced CSharp Module 11.01.21\05.CopyDirectory";//Console.ReadLine();
            string outputPath = @"C:\Users\Naka7a\Desktop\Test";//Console.ReadLine();

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath,true);  // true -> to delete all directories and subdirectories or files. false -> to not touch.
                Directory.CreateDirectory(outputPath);
            }
            else
            {
                Directory.CreateDirectory(outputPath);
            }

            string[] files = Directory.GetFiles(inputPath);

            foreach (var file in files)
            {
                string fileName = outputPath + "\\" + Path.GetFileName(file);
                File.Copy(file, fileName);
            }
        }
    }
}
