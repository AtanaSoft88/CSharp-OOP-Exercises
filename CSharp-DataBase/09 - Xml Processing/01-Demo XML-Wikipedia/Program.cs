using System;
using System.Linq;
using System.Xml.Linq;

namespace XML_Big_File_Manipulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            //Reading from Large XML 

            /*             
            XDocument docX = XDocument.Load(@"..\..\..\abstract.xml");

            //Document is too big ,so we remove some data 

            foreach (var element in docX.Root.Elements())
            {
                element.Elements().Where(x => x.Name == "links").Remove();
            }
            docX.Save(@"..\..\..\abstract-LightVersion.xml");
            */



            /*
             XDocument lightVerXml = XDocument.Load(@"..\..\..\abstract-LightVersion.xml");
            Console.WriteLine($"Light version Xml Root is ->> : {lightVerXml.Root.Name}");

            foreach (var elem in lightVerXml.Root.Elements())
            {
                elem.Elements().Where(x => x.Name == "url").Remove();
            }

            lightVerXml.Save(@"..\..\..\abstract-LightVersion-URL-Removed.xml");
             */

            //After we reduced the xml size from 300mb to 80 mb ,we can extract some data
            //We can search for specific word and find information about it in this xml which represents Wikipedia
            XDocument docInfoReduced = XDocument.Load(@"..\..\..\abstract-LightVersion-URL-Removed.xml");
            Console.WriteLine("Напишете една дума на български, по която да търся информация, моля...");
            string magicWord = Console.ReadLine();            

            var info = docInfoReduced.Root
                .Elements()
                .Where(x=>x.Element("title").Value.Contains(magicWord))
                .Select(x=> $"{x.Element("title").Value.Replace("Уикипедия:","").TrimStart()}:\r\n--{x.Element("abstract").Value}").ToList();

            Console.WriteLine(String.Join("\r\n",info));



        }
    }
}
