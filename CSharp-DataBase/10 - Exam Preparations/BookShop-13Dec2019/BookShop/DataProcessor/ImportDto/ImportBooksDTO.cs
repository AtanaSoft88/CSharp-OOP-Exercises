using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ImportDto
{
    [XmlType("Book")]
    public class ImportBooksDTO
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        
        public string Name { get; set; }

        [XmlElement("Genre")]
        [Range(1,3)]        
        public int GenreNumb { get; set; }//Enum -> we receive it as Integer, so we must check if the input is within the possible from 1 to 3

        [XmlElement("Price")]
        [Range(0.01, (double)(decimal.MaxValue))]  //[Range(typeof(decimal),"0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Range(50,5000)]
        [XmlElement("Pages")]
        public int Pages { get; set; }

        [XmlElement("PublishedOn")]
        [Required]
        public string PublishedOn { get; set; } // MM/dd/yyyy

    }
}
