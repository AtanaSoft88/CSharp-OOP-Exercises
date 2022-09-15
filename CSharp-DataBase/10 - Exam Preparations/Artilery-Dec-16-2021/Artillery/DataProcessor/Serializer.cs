
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        private static string rootName = "";
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells.ToList().Where(x => x.ShellWeight > shellWeight).Select(s => new
            {
                ShellWeight = s.ShellWeight,
                Caliber = s.Caliber,
                Guns = s.Guns.Where(gs => gs.ShellId == gs.Shell.Id && gs.GunType.ToString() == "AntiAircraftGun").Select(g => new
                {
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight,
                    BarrelLength = g.BarrelLength,
                    Range = g.Range > 3000 ? "Long-range" : "Regular range",
                }).OrderByDescending(w => w.GunWeight)

            }).OrderBy(sh => sh.ShellWeight).ToList();

            var jsonString = JsonConvert.SerializeObject(shells, Formatting.Indented);
            return jsonString;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            rootName = "Guns";
            var gunsExport = context.Guns.ToArray().Where(x => x.Manufacturer.ManufacturerName == manufacturer).Select(g => new ExportGunsDTO
            {
                Manufacturer = g.Manufacturer.ManufacturerName,
                GunType = g.GunType.ToString(),
                Weight = g.GunWeight,
                BarrelLength = g.BarrelLength,
                Range = g.Range,
                Countries = g.CountriesGuns.Where(cg => cg.CountryId == cg.Country.Id && cg.Country.ArmySize > 4500000).Select(c => new CountriesDto
                { 
                    CountryName = c.Country.CountryName,
                    ArmySize = c.Country.ArmySize
                }).OrderBy(x => x.ArmySize).ToArray()
            }).OrderBy(x=>x.BarrelLength).ToArray();


            var xmlString = SerializerCustom<ExportGunsDTO[]>(gunsExport, rootName);
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
