using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace XML_DEMO_LAB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //To read XML dont need to install any NuGet packets or something , all is situated in:  "System.Xml.Linq;"

            // We can get the xml with File.ReadAllText(docPath)
            string xmlAsString = File.ReadAllText(@"..\..\..\DemoFile.xml");
            Console.WriteLine(xmlAsString);
            Console.WriteLine(new string('*', 50));

            //1)Using Static method of "XDocument" -> Parse
            XDocument xDoc1 = XDocument.Parse(xmlAsString);

            //2)If we know the path to the document, we can use another static Method ( no need FileReader)
            XDocument xDocument = XDocument.Load(@"..\..\..\DemoFile.xml");
            Console.WriteLine($"Element: -->> {xDocument.Root.Element("book").Value}"); // gives us  element 
            
            Console.WriteLine($"Root /Whole Document/ without footer is: -->>\r\n {xDocument.Root}"); // gives us the whole document 
            Console.WriteLine(new string('*',50));
            Console.WriteLine($"Root Elements: -->>\r\n {string.Join("\r\n", xDocument.Root.Elements())}"); // gives us Array 
            Console.WriteLine(new string('*', 50));
            int count = 0;
            foreach (var elem in xDocument.Root.Elements())
            {
                count++;
                Console.WriteLine($"*************Foreach Iteration:[{count}] *************");
                Console.WriteLine(elem.Element("title").Value); // we can print the nested Element 
                Console.WriteLine("*************Foreached*************");
            }

            Console.WriteLine($"Linq to get filtered ->\r\n {xDocument.Root.Elements().Where(d=>d.Attributes().Any(at=>at.Name == "test")).First()}");

            Console.WriteLine($"Root Elements Count: {xDocument.Root.Elements().Count()}"); // Count of elements
            Console.WriteLine($"Root Name is -> {xDocument.Root.Name}"); // gives us the root Name 
            Console.WriteLine($"Version Name is -> {xDocument.Declaration.Version}"); // Version
            Console.WriteLine($"Enconding is -> {xDocument.Declaration.Encoding}"); // Enconding
            //------------------------------------------------------------------------------------------------------------------
            //We can Search for Element and filterring to access some info
            var searchedTitle = xDocument.Root.Elements().Select(x => new
            {
                Name = x.Element("title").Value,
                Isbn = x.Element("isbn").Value,
                Author = x.Element("author").Value

            }).OrderByDescending(i=>i.Isbn).Where(x=>x.Author.StartsWith("dj")).Select(n=>$"Found Title:{n.Name}\r\nFound Author: {n.Author}").First();
            
            Console.WriteLine(searchedTitle);
            //We can Access the XML and modify its content , and Add some Elements

            foreach (var book in xDocument.Root.Elements())
            {
                book.SetElementValue("price",1.20); // we add to each element new one named "price" and 1,2 value
                book.SetElementValue("clor","Blue"); // we add to each element new one named "price" and 1,2 value
                book.SetElementValue("pagesCount",new Random().Next(50,600)); //we add to each element new one named "price" and 1,2 value
            }
            xDocument.Save(@"..\..\..\DemoFile_AddPrice.xml");

            Console.WriteLine("\r\nWhat is the element which contains price -> see below\r\n");
            Console.WriteLine(xDocument.Root.Elements().Where(n => n.Elements().Any(x => x.Name == "price")).FirstOrDefault());

            //We can remove "price" Elements

            foreach (var outerElem in xDocument.Root.Elements())
            {
                foreach (var inner in outerElem.Elements())
                {
                    if (inner.Name =="price")
                    {
                        inner.Remove();
                    }
                    
                }
            }
            xDocument.Save(@"..\..\..\DemoFile_RemovedPrice.xml");

            //We can Add Attributes - for example the Count of Books we have in Library

            xDocument.Root.SetAttributeValue("BooksCount", xDocument.Root.Elements().Count());
            xDocument.Save(@"..\..\..\DemoFile_BooksCount-Attribute.xml");

            //Now the changes are not inside the original xml,but we can save it in another xml                       
            

            var xDocModified = XDocument.Load(@"..\..\..\DemoFile_RemovedPrice.xml");
            

            //We can Remove Elements

            foreach (var book in xDocModified.Root.Elements())
            {
                book.RemoveAll();
            }
            xDocModified.Save(@"..\..\..\DemoFile_RemoveAllBookElements.xml"); // removes all Elements ( books)

            //We can remove all from root

            xDocModified.Root.RemoveAll();
            xDocModified.Save(@"..\..\..\DemoFile_Root_RemoveAll.xml");


            
        }
    }
}
