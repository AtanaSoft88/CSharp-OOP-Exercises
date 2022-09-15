using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class ImportOfficersPrisonersDTO
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(3)]
        [MaxLength(30)]
        public string FullName { get; set; } //•	FullName – text with min length 3 and max length 30 (required)

        [XmlElement("Money")]
        [Range(0, (double)decimal.MaxValue)]
        public decimal Salary { get; set; } //•	Salary – decimal (non-negative, minimum value: 0) (required)

        [XmlElement("Position")] 
        public string Position { get; set; } // Enum
        
        [XmlElement("Weapon")]
        public string Weapon { get; set; } // Enum

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; } //•	DepartmentId - integer, foreign key(required)

        [XmlArray("Prisoners")]
        public PrisonersDto[] Prisoners { get; set; }                                               
    }

    [XmlType("Prisoner")]
    public class PrisonersDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
