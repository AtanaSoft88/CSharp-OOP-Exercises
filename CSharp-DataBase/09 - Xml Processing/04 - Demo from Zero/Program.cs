using System;
using System.Linq;
using System.Xml.Linq;

namespace XML_From_Zero
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            XDocument document = new XDocument();
            var root = new XElement("library"); // that way we create first Root , ( or we cant create the xml file)
            document.Add(root);
            document.Save(@"..\..\..\myXmlFromZero.xml"); // now we have created our XML file with Root = "library"
            int count = 0;
            var textTitles = Title.TitleArray;
            
            for (int i = 0; i < 100; i++)
            {
                var startColor = (Colours)1;
                count++;
                var book = new XElement("book");
                root.Add(book);
                book.Add(new XElement("Title", textTitles[new Random().Next(1,textTitles.Length)]));
                book.Add(new XElement("Color", (Colours)new Random().Next(1, 20)));//Here Random nums 1-20 Cast as Enum-name representation
                book.Add(new XElement("BookNo", (20 + i * 2).ToString()));
                book.Add(new XElement("Price", (25 + i * (2 / 0.3)).ToString("F2")));

            }
            document.Save(@"..\..\..\myXmlFromZero-AddBooks.xml");//,SaveOptions.DisableFormatting);


            //Now some playing with this newly created xml from Zero

            XDocument myDocXml = XDocument.Load(@"..\..\..\myXmlFromZero-AddBooks.xml");
            var titlesFilter = myDocXml.Root.Elements().Where(x => x.Element("Title").Value.Contains("Book")).Select(t => t.Element("Title").Value.Replace("Book","****")).ToList().Distinct();

            // I've got all Titles where it is contained string "Book" into a List and replace "Book" with ****
            Console.WriteLine(String.Join("\r\n", titlesFilter)); 



        }

        public enum Colours
        {
            Red = 1,
            Blue = 2,
            Green = 3,
            Yellow = 4,
            Brown = 5,
            Cyan = 6,
            Magenta = 7,
            Pink = 8,
            DarkRed = 9,
            DarkGreen = 10,
            DarkYellow = 11,
            DarkBlack = 12,
            DarkWhite = 13,
            DarkGray = 14,
            Orange = 15,
            OrangeRed = 16,
            OrangeGreen = 17,
            OrangeYellow = 18,
            OrangeBlack = 19,
            OrangeWhite = 20,

        }

        public class Title
        {
            public static  string[] TitleArray => new string[] 
            {
                "You May Win",
                "Live your Life",
                "Nice Book",
                "FootSteps",
                "Finger Prints on my old book",
                "I know what you did last summer",
                "Code London",
                "RedBull is the best",
                "The car need a mechanic",
                "Pay as much as you want",
                "Never back down",
                "The Face Book is not like Facebook!",
                "Book-ing dot com -> Booking.com?",
                "Balbook Balbooook I am here!",
                "BalBook BalBooook I am here!",
                "Think twice,do it once",
                "What the fuk u doing ,havent you read this book before...Yes! I meanbookBoomBammBumBuukBook?",
                "You are never too young",
                "Don't forget where you started from",
                "Break your brain",
                "Save money but not today",
                "7 Days to die",
                "Live now,tommorow is late",
                "One coffee never enough",
                "One Book is never enough"
            };

        }
    }
}
