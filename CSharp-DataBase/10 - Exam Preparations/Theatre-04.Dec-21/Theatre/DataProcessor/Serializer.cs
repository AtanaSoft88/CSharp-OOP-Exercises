namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string rootName = "";
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres.ToArray().Where(h => h.NumberOfHalls >= numbersOfHalls && h.Tickets.Count() >= 20).Select(t => new 
            {
                Name = t.Name,
                Halls = t.NumberOfHalls,
                TotalIncome = t.Tickets.Where(x=>x.RowNumber >=1 && x.RowNumber <= 5).Sum(x => x.Price),
                Tickets = t.Tickets.Where(x => x.RowNumber >= 1 && x.RowNumber <= 5).Select(x=> new 
                {
                    Price = x.Price,
                    RowNumber = x.RowNumber
                }).OrderByDescending(p=>p.Price).ToArray()
            }).OrderByDescending(x=>x.Halls).ThenBy(x=>x.Name).ToArray();

            string jsonString = JsonConvert.SerializeObject(theatres,Formatting.Indented);

            return jsonString;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            rootName = "Plays";
            
            var plays = context.Plays.ToArray().Where(r => r.Rating <= rating).Select(p => new ExportPlaysDTO 
            {
                Title = p.Title,
                Duration = p.Duration.ToString("c",CultureInfo.InvariantCulture),
                Rating = p.Rating==0? "Premier": p.Rating.ToString(),
                Genre = p.Genre.ToString(),
                Actors = p.Casts.Where(mc=>mc.IsMainCharacter==true).Select(a=> new ActorsDto 
                { 
                    FullName = a.FullName,
                    MainCharacter = $"Plays main character in '{p.Title}'."
                }).OrderByDescending(x=>x.FullName).ToArray()

            }).OrderBy(x=>x.Title).ThenByDescending(x=>x.Genre).ToArray();

            string xmlString = SerializerCustom<ExportPlaysDTO[]>(plays,rootName);
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
