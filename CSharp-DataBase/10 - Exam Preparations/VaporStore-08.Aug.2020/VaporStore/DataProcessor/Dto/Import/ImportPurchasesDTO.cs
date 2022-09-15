using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class ImportPurchasesDTO
    {
        [Required]
        [XmlAttribute("title")]
        public string GameName { get; set; } // The name of the Game //Nav property

        [Required]
        [XmlElement("Type")]
        public PurchaseType? Type { get; set; } // can be of type "PurchaseType" , set as nullable and [Required] to make it simple tricky! , as well as can be type String (also not nullable) and shall be TryParsed later to be used 

        [Required]
        [XmlElement("Key")]
        //ProductKey – text, which consists of 3 pairs of 4 uppercase Latin letters and digits,                                         separated by dashes(ex. “ABCD-EFGH-1J3L”) (required)
        [RegularExpression(@"([A-Z0-9]{4}-){2}[A-Z0-9]{4}")]
        public string Key { get; set; } 

        [Required]
        [XmlElement("Card")]
        public string Card { get; set; } //Nav property

        [Required]
        [XmlElement("Date")]
        //[DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="dd/MM/yyyy HH:mm")]
        public string Date { get; set; }
    }
}
