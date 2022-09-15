using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportPrisonersMailsDTO
    {
        //Prisoner's info
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [JsonProperty(nameof(FullName))]
        public string FullName { get; set; }

        [Required]        
        [RegularExpression("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+")]
        [JsonProperty(nameof(Nickname))]
        public string Nickname { get; set; }

        [Range(18,65)]
        [JsonProperty(nameof(Age))]
        public int Age { get; set; }

        [JsonProperty(nameof(IncarcerationDate))]
        public string IncarcerationDate { get; set; }

        [JsonProperty(nameof(ReleaseDate))]
        public string ReleaseDate { get; set; } // can be null!

        [Range(0, (double)decimal.MaxValue)]
        [JsonProperty(nameof(Bail))]
        public decimal? Bail { get; set; }

        [JsonProperty(nameof(CellId))]
        public int? CellId { get; set; }
        [JsonProperty(nameof(Mails))]
        public MailsDto[] Mails { get; set; }

        //•	FullName – text with min length 3 and max length 20 (required)
        //•	Nickname – text starting with "The " and a single word only of letters with an uppercase letter for beginning(example: The Prisoner) (required)
        //•	Age – integer in the range[18, 65] (required)
        //•	IncarcerationDate ¬– Date(required)
        //•	ReleaseDate– Date
        //•	Bail– decimal (non-negative, minimum value: 0)
        //•	CellId - integer, foreign key        
        //•	Mails - collection of type Mail

    }

    //Mail's info
    public class MailsDto
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Sender { get; set; }

        [RegularExpression(@"^[A-Za-z\s0-9]+? str\.$")]  // ^([A-Za-z\s0-9]+?)( str\.)$  - here "+?" means no greedy
        public string Address { get; set; } //•	Address – text, consisting only of letters, spaces and numbers, which ends with “ str.” (required)

    }
}
