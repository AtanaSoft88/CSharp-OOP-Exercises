using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{

    public class ImportUsersDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"\b[A-Z][a-z]+ [A-Z][a-z]+\b")]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }
        [Range(3,103)]
        public int Age { get; set; }
        public IEnumerable<CardDto> Cards { get; set; }
    }

    public class CardDto
    {
        [Required]
        [RegularExpression(@"[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}")] // ->> same as:  @"([0-9]{4} ){3}[0-9]{4}"
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{3}")]
        public string CVC { get; set; }

        [Required]
        public CardType? Type { get; set; } //Tricky -> Directly prop of type Enum , if input is incorrect ,will be set to null, and the Attribute [Required] will not let null value to pass validation, so wont be set as value!

        //[Required]
        //public string Type { get; set; } 
    }

}
