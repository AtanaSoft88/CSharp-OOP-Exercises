namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using FileStream newFileStream = new FileStream(sourceFilePath, FileMode.Open);
            long size1 = 0;
            long size2 = 0;
            if (newFileStream.Length % 2 == 0) // Write a program to split it into two equal-sized files 
            {
                size1 = size2 = newFileStream.Length / 2;           
            }
            else              //When the input file size is an odd number, the first part should be 1 byte bigger than the second.
            {
                size1 = newFileStream.Length / 2 + 1;                                                                        
                size2 = newFileStream.Length / 2;
            }

            byte[] data1 = new byte[size1];
            byte[] data2 = new byte[size2];

            newFileStream.Read(data1, 0, data1.Length);
            newFileStream.Read(data2, 0, data2.Length);

            using (FileStream writer = new FileStream(partOneFilePath, FileMode.OpenOrCreate))
            {
                writer.Write(data1);
                writer.Close();
            }

            using (FileStream writer2 = new FileStream(partTwoFilePath, FileMode.OpenOrCreate))
            {
                writer2.Write(data2);
                writer2.Close();
            }
            newFileStream.Close();

        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream reader = new FileStream(partOneFilePath, FileMode.OpenOrCreate))
            {
                byte[] file1 = new byte[reader.Length];
                reader.Read(file1);
                using (FileStream reader1 = new FileStream(partTwoFilePath, FileMode.Open))
                {
                    byte[] file2 = new byte[reader1.Length];
                    reader1.Read(file2);
                    using (FileStream writer = new FileStream(joinedFilePath, FileMode.OpenOrCreate))
                    {
                        writer.Write(file1, 0, file1.Length);
                        writer.Write(file2, 0, file2.Length);
                        writer.Close();
                    }
                    reader1.Close();
                }
                reader.Close();
            }
        }
    }
}