﻿namespace ExtractBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class ExtractBytes
    {
        static void Main(string[] args)
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using StreamReader streamReader = new StreamReader(bytesFilePath); // reading txt file
            byte[] fileBytes = File.ReadAllBytes(binaryFilePath); // reading binary file , record into byte[]
            List<string> bytesList = new List<string>();
            StringBuilder sb = new StringBuilder();

            while (!streamReader.EndOfStream)
            {
                bytesList.Add(streamReader.ReadLine());  // 20,46,183,212 - > add to List
            }
            foreach (var item in fileBytes)
            {
                if (bytesList.Contains(item.ToString()))
                {
                    sb.AppendLine(item.ToString());
                }

            }
            using StreamWriter file = new StreamWriter(outputPath);
            file.WriteLine(sb.ToString().Trim());
        }
    }
}
