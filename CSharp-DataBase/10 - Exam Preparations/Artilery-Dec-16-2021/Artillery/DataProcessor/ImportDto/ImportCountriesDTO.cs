using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class ImportCountriesDTO
    {
        [XmlElement("CountryName")]
        [MinLength(4)]
        [MaxLength(60)]
        public string CountryName { get; set; } //•	CountryName – text with length [4, 60] (required)

        [XmlElement("ArmySize")]        
        [Range(50000, 10000000)]
        public int ArmySize { get; set; } //•	ArmySize – integer in the range [50_000….10_000_000] (required)
    }
}
