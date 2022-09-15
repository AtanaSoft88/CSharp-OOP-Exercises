using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ImportManufacturersDTO
    {
        [XmlElement("ManufacturerName")]
        [MinLength(4)]
        [MaxLength(40)]
        [Required]
        [Index(nameof(ManufacturerName), IsUnique = true)] //- set by Attribute to be UNIQUE 
        public string ManufacturerName { get; set; } //•	ManufacturerName – unique text with length [4…40] (required)

        [XmlElement("Founded")]
        [MinLength(10)]
        [MaxLength(100)]
        [Required]
        public string Founded { get; set; } // •	Founded – text with length [10…100] (required)
    }
}
