using System.Xml.Serialization;

namespace CarDealer.DTO.Export_DTO
{
    [XmlType("suplier")]
    public class ExportSuppliersDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("parts-count")]
        public int PartsCount { get; set; }
    }
}
