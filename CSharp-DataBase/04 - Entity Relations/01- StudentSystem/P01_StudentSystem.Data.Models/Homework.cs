using P01_StudentSystem.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; } //o HomeworkId

        [Required]
        [Column(TypeName ="varchar(255)")]
        public string Content { get; set; } //o Content - (string, linking to a file, not unicode)

        
        public ContentType ContentType { get; set; } //o ContentType - (enum – can be Application, Pdf or Zip)

        
        public DateTime SubmissionTime { get; set; } //o SubmissionTime

        
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; } //o StudentId
        public virtual Student Student { get; set; }

        
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }  //o CourseId
        public virtual Course Course { get; set; }
                                             




    }
}
