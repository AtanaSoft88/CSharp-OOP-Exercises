using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportProjectionDTO
    {
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }  //•	Name – text with length[4, 30] (required)

        [Required]
        [Range(typeof(sbyte),"1","10")]
        public sbyte NumberOfHalls { get; set; } //•	NumberOfHalls – sbyte between[1…10] (required)


        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        [JsonProperty("Director")]
        public string DirectorName { get; set; }  //•	Director – text with length[4, 30] (required)

        public TicketsDTO[] Tickets { get; set; }    
               
    }
    public class TicketsDTO
    {
        [Required]
        [Range(typeof(decimal), "1.00", "100.00")]
        public decimal Price { get; set; }

        [Required]
        [Range(typeof(sbyte), "1", "10")]
        public sbyte RowNumber { get; set; }

        [Required]
        public int PlayId { get; set; }
    }
}
