namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        private static string rootName = "";
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prosoners = context.Prisoners.Where(p => ids.Contains(p.Id)).Select(p => new 
            {
                Id = p.Id,
                Name = p.FullName,
                CellNumber = p.Cell.CellNumber,
                Officers = p.PrisonerOfficers.Select(x=> new 
                {
                    OfficerName = x.Officer.FullName,
                    Department = x.Officer.Department.Name
                }).OrderBy(x=>x.OfficerName).ToArray(),           // needs to be formatted to 2nd decimal point and number so parse it
                TotalOfficerSalary = decimal.Parse(p.PrisonerOfficers.Sum(x => x.Officer.Salary).ToString("F2")), 
            }).OrderBy(x=>x.Name).ThenBy(x=>x.Id).ToArray();

            var jsonString = JsonConvert.SerializeObject(prosoners, Formatting.Indented);   

            return jsonString;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            rootName = "Prisoners";
            string[] namesOfPrisoners = prisonersNames.Split(",");
            var prisonersMessages = context.Prisoners.Where(n => namesOfPrisoners.Contains(n.FullName)).Select(p => new InboxForPrisonersDTO
            {
                Id = p.Id,
                Name = p.FullName,
                IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                Messages = p.Mails.Select(m => new EncryptedMessagesDto 
                { 
                    Description = new string(m.Description.Reverse().ToArray()),
                }).ToArray()
            }).OrderBy(x=>x.Name).ThenBy(x=>x.Id).ToArray();

            var xmlString = SerializerCustom<InboxForPrisonersDTO[]>(prisonersMessages,rootName);
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