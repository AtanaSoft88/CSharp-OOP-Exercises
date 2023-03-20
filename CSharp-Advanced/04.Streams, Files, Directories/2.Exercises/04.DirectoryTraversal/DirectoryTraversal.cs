namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            //1) Get all files from a given Directory ,
            // Search pattern "*" - means all from left and right to be searched.
            string[] files = Directory.GetFiles(inputFolderPath, "*");

            //1) Group by Extension,name,size ->
            //==================================
            //  .cs
            //--Mecanismo.cs - 0.994kb
            //--Program.cs - 1.108kb
            //--Nashmat.cs - 3.967kb
            //--Wedding.cs - 23.787kb
            //--Program - Copy.cs - 35.679kb
            //--Salimur.cs - 588.657kb
            //  .txt
            //--backup.txt - 0.028kb
            //--log.txt - 6.72kb
            //  .asm
            //--script.asm - 0.028kb
            //.config
            //--App.config - 0.187kb
            //.csproj
            //--01.Writing - To - Files.csproj - 2.57kb
            //   .js
            //   --controller.js - 1635.143kb
            //   .php
            //   --model.php - 0kb
            //====================================
            //--Making Dictionary for file extension , inside Dictionary for file name and double for size
            Dictionary<string, Dictionary<string, double>> fileInfoDict = new Dictionary<string, Dictionary<string, double>>();

            foreach (var currFilePath in files)
            {
                // currFilePath -> returns a file representing the full path to the file.
                //Variant I
                FileInfo info = new FileInfo(currFilePath);
                string fileName = info.Name;                
                string extension = info.Extension;
                double size = info.Length/1024.0;

                ////Variant II
                //string fileName = Path.GetFileName(currFilePath);
                //string extension = Path.GetExtension(currFilePath);
                //double size = new FileInfo(currFilePath).Length / 1024.0;      // - .Length returns Bytes as size, divided by 1024.0 ( as double) returns KB.
                if (!fileInfoDict.ContainsKey(extension))
                {
                    fileInfoDict.Add(extension, new Dictionary<string, double>());
                }
                // here it is not necessarry to check wether fileName already exists cuz in a folder there can't be 2 files with same extensions and name! But in other cases we must check this condition! So we just ADD the fileName and size.
                fileInfoDict[extension].Add(fileName, size);
            }
            StringBuilder sb = new StringBuilder();

            foreach (var kvp in fileInfoDict.OrderByDescending(x=>x.Value.Count()).ThenBy(n=>n.Key))
            {
                sb.AppendLine(kvp.Key);
                foreach (var fileValue in kvp.Value.OrderBy(x=>x.Value))
                {
                    sb.AppendLine($"--{fileValue.Key} - {fileValue.Value:F3}kb");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";
            File.WriteAllText(desktopPath, textContent);
        }

    }
}
