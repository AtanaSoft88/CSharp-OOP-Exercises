using System.Xml.Serialization;

namespace CarDealer.DTO.Import_DTO
{
    [XmlType("partId")]
    public class ImportCarPartsDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}