using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class ImportCastsDTO
    {
        [Required]
        [XmlElement("FullName")]
        [MinLength(4)]
        [MaxLength(30)]
        public string FullName { get; set; }


        [XmlElement("IsMainCharacter")]
        public bool IsMainCharacter { get; set; }

        [Required]
        [XmlElement("PhoneNumber")]
        [RegularExpression(@"^\+44-\d{2}-\d{3}-\d{4}$")]
        public string PhoneNumber { get; set; } 

        [XmlElement("PlayId")]
        [Required]
        public int PlayId { get; set; }

        //•	PhoneNumber  - text in the following format: "+44-{2 numbers}-{3 numbers}-{4 numbers}". Valid phone numbers are: +44-53-468-3479, +44-91-842-6054, +44-59-742-3119 (required)

    }
}
