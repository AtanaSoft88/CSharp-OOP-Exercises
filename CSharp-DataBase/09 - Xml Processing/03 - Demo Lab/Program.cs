using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace XML_Deserialize_fm_File
{
    public class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            //We need external Class ( used as DTO) which contains as properties the needed Elements from XML
            //Then create XmlSerializer and Deserialize the data from XML to a List or Array of data.
            var serializer = new XmlSerializer(typeof(List<Article>), new XmlRootAttribute("feed"));

            Console.WriteLine("Моля напиши дума за тъсене на инфо...");
            string magicWord = Console.ReadLine();
            
            var articlesFull = (List<Article>)serializer.Deserialize(File.OpenRead(@"..\..\..\abstract-LightVersion-URL-Removed.xml"));

            var filteredInfo = articlesFull
                 .Where(x => x.Title.Contains(magicWord))
                 .Select(x => $"{x.Title.Replace("Уикипедия:", "").TrimStart()}:\r\n{x.Description}")
                 .ToList();
            foreach (var item in filteredInfo)
            {
                Console.WriteLine(item);
            }

            //How to Serialize into XML from Class 

            var articlesSmall = new List<Article>();

            articlesSmall.Add(new Article { Title = "Шопска Салата (Shopska Salad)", Description =" It is consisted of Tomatos, Cheese,Cucumbers,Oil,Onion,Parsley. Suitable to be consumed with Bulgarian Rakia/Vodka"});

            articlesSmall.Add(new Article { Title = "Пица Тропикана (Pizza Tropicana)", Description = " It is consisted of Tomatos, Cheese,Beef steak,mushrooms,Edam,Oregano,Pineapple. Best to be consumed with Stela Artois - Beer" });

            serializer.Serialize(File.OpenWrite(@"..\..\..\serializedXml.xml"), articlesSmall);

            //How to Serialize into BIN file ( Binary)

            var binaryFormatter = new BinaryFormatter();            
            binaryFormatter.Serialize(File.OpenWrite(@"..\..\..\articles.bin"), articlesSmall);
        }
    }
}
