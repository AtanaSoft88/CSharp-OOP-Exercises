using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlaysDTO
    {
        [Required]
        [XmlElement("Title")]
        [MinLength(4)]
        [MaxLength(50)]
        public string Title { get; set; }

        [XmlElement("Duration")]
        public string Duration { get; set; }

        [XmlElement("Rating")]
        [Range((float)0.00, (float)10.00)]
        public float Rating { get; set; }

        [XmlElement("Genre")]
        public string Genre { get; set; }

        [Required]
        [XmlElement("Description")]
        [MaxLength(700)]
        public string Description { get; set;}


        [XmlElement("Screenwriter")]
        [MinLength(4)]
        [MaxLength(30)]
        public string Screenwriter { get; set; }

    }
}
