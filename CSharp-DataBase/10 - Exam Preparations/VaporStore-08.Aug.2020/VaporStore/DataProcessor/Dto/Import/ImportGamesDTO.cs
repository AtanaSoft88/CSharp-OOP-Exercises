using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportGamesDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }


        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "yyyy-MM-dd")] - if DateTime is more complicated!
        [Required]
        public DateTime? ReleaseDate { get; set; } // string??? / Tricky DateTime? + [Required]

        [Required]
        [JsonProperty("Developer")]
        public string DeveloperName { get; set; }

        [Required]
        public string Genre { get; set; }
        
        public string[] Tags { get; set; }
    }
}
