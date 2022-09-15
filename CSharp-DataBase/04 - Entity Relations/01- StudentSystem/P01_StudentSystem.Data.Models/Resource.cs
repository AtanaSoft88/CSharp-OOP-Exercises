using P01_StudentSystem.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }  //o ResourceId

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } //o Name - (up to 50 characters, unicode)

        [Required]
        [Column(TypeName ="varchar(2050)")]
        public string Url { get; set; } //o Url - (not unicode)

        public ResourceType ResourceType { get; set; }  //o   ResourceType - (enum – can be Video, Presentation, Document or Other)    

        
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; } //o CourseId 
        public virtual Course Course { get; set; }


    }
}
