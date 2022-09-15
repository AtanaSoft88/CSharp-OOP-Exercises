namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            //If i have to OrderBy price and formatted to the 2nd decimal ,the OrderBy() has to be done earlier and not to Book.Price.ToString
            var craziestAuthors = context.Authors.Select(x => new
            {
                AuthorName = x.FirstName + ' ' + x.LastName ,
                Books = x.AuthorsBooks.OrderByDescending(x=>x.Book.Price).Select(ab=> new 
                {
                    BookName = ab.Book.Name,
                    BookPrice = ab.Book.Price.ToString("F2")
                }).ToArray()
            }).ToArray().OrderByDescending(x=>x.Books.Length).ThenBy(a=>a.AuthorName).ToArray();
            

            var jsonString = JsonConvert.SerializeObject(craziestAuthors,Formatting.Indented);
            return jsonString;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var rootName = "Books";

            var oldestBooks = context.Books.Where(d => d.PublishedOn < date && (int)d.Genre == 3).ToArray().Select(b => new ExportOldestBooksDTO 
            { 
                Name = b.Name,
                Date = b.PublishedOn.ToString("d",CultureInfo.InvariantCulture),
                Pages =b.Pages

            }).OrderByDescending(x=>x.Pages).ThenByDescending(x=>x.Date).Take(10).ToArray();
            var xmlString = SerializerCustom<ExportOldestBooksDTO[]>(oldestBooks,rootName);
            return xmlString;
        }

        private static string SerializerCustom<T>(T dto, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty); // This way we delete any namespaces trails for judje!

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, dto, namespaces);

            return sb.ToString().TrimEnd();
        }       // Usefull Method fm ClassDto[] to XML file
    }
}