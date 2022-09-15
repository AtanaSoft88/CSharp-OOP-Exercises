using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {            
            HomeworkSubmissions = new HashSet<Homework>();
            CourseEnrollments = new HashSet<StudentCourse>();
        }

        [Key]
        public int StudentId { get; set; } //o StudentId


        [Required]                        
        [MaxLength(100)]                  //o Name - (up to 100 characters, unicode)
        public string Name { get; set; }  // any String is mapped by default as unicode , so no need to declare here 


        [Column(TypeName = "char(10)")] 
        public string PhoneNumber { get; set; } //o PhoneNumber - (exactly 10 characters, not unicode, not required)

        public DateTime RegisteredOn { get; set; } //o RegisteredOn

        public DateTime? Birthday { get; set; } //o Birthday - (not required) , use nullable "?"

        public virtual ICollection<Homework> HomeworkSubmissions { get; set; } // Many to one Student        
        public virtual ICollection<StudentCourse> CourseEnrollments { get; set; } // Mapping table relation

    }
}
