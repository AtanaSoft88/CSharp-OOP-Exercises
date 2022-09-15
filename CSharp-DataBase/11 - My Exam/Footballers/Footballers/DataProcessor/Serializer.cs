namespace Footballers.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string rootName = "";
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            rootName = "Coaches";

            var coachesExport = context.Coaches.ToArray().Where(x => x.Footballers.Any()).Select(c => new ExportCoachesWithFootballersDTO
            {
                FootballersCount = c.Footballers.Count(),
                CoachName = c.Name,
                Footballers = c.Footballers.Select(fb => new FootballesExportDTO
                {
                    FootballerName = fb.Name,
                    FootballerPositionType = fb.PositionType.ToString(),
                }).OrderBy(x => x.FootballerName).ToArray()
            }).OrderByDescending(x => x.FootballersCount).ThenBy(x=>x.CoachName).ToArray();

            string xmlString = SerializerCustom < ExportCoachesWithFootballersDTO[]>(coachesExport, rootName);
            return xmlString;

        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            
            var teams = context.Teams.Where(x=>x.TeamsFootballers.Any(c=>c.Footballer.ContractStartDate>=date)).ToArray().Select(t=> new 
            {
                Name = t.Name,
                Footballers = t.TeamsFootballers.ToArray().Where(d=>d.Footballer.ContractStartDate >= date).OrderByDescending(x=>x.Footballer.ContractEndDate).ThenBy(x=>x.Footballer.Name).Select(n => new 
                {
                    FootballerName = n.Footballer.Name,
                    ContractStartDate = n.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                    ContractEndDate = n.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                    BestSkillType = n.Footballer.BestSkillType.ToString(),
                    PositionType = n.Footballer.PositionType.ToString(),

                }).ToArray()
            }).OrderByDescending(x=>x.Footballers.Count()).ThenBy(x=>x.Name).Take(5).ToArray();

            var stringJson = JsonConvert.SerializeObject(teams, Formatting.Indented);
            return stringJson;
        }

        private static string SerializerCustom<T>(T dto, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty); 

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, dto, namespaces);

            return sb.ToString().TrimEnd();
        }

    }
}
