using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {            
            HomeworkSubmissions = new HashSet<Homework>();
            StudentsEnrolled = new HashSet<StudentCourse>();
            Resources = new HashSet<Resource>();
        }
        [Key]
        public int CourseId { get; set; } //o CourseId

        [Required]
        [MaxLength(80)]
        public string Name { get; set; } //o Name - (up to 80 characters, unicode) - it is unicode by default

        public string Description { get; set; } //o Description - (unicode, not required)

        
        public DateTime StartDate { get; set; } //o   StartDate

        
        public DateTime EndDate { get; set; } //o   EndDate

        
        public decimal Price { get; set; } //o   Price

        public virtual ICollection<Homework> HomeworkSubmissions { get; set; } // Many to one Course
        public virtual ICollection<StudentCourse> StudentsEnrolled { get; set; } // Mapping table relation
        public virtual ICollection<Resource> Resources { get; set; } // Many to one Course

        






    }
}
