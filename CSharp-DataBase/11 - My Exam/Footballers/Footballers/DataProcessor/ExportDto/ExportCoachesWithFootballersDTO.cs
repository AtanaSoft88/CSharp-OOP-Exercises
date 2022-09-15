using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Coach")]
    public class ExportCoachesWithFootballersDTO
    {
        [XmlAttribute("FootballersCount")]
        public int FootballersCount { get; set; }

        [XmlElement("CoachName")]
        public string CoachName { get; set; }

        [XmlArray("Footballers")]
        public FootballesExportDTO[] Footballers { get; set; }
    }

    [XmlType("Footballer")]
    public class FootballesExportDTO
    {
        [XmlElement("Name")]
        public string FootballerName { get; set; }

        [XmlElement("Position")]
        public string FootballerPositionType { get; set; } // Type

    }
}
