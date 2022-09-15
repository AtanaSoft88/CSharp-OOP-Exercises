using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarDealer.DTO.Import_DTO
{
    [XmlType("Car")]
    public class ImportCarDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }
        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public List<ImportCarPartsDTO> PartsIds { get; set; }        

    }
  
}
