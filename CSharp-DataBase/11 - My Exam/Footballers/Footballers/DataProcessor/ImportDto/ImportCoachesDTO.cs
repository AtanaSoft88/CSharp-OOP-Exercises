using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class ImportCoachesDTO
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string NameCoach { get; set; }

        [Required]
        [XmlElement("Nationality")]
        public string Nationality { get; set; }


        [XmlArray("Footballers")]
        public FootballersImportDTO[] Footballers { get; set; }
    }

    [XmlType("Footballer")]
    public class FootballersImportDTO
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string NameFootballer { get; set; }

        [XmlElement("ContractStartDate")]
        [Required]
        public string ContractStartDate { get; set; }

        [XmlElement("ContractEndDate")]
        [Required]
        public string ContractEndDate { get; set; }

        [XmlElement("BestSkillType")]
        [Required]
        public int BestSkillType { get; set; }

        [XmlElement("PositionType")]
        [Required]
        public int PositionType { get; set; }
    }
}
