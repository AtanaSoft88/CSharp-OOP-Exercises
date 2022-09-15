using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.Data.Models
{
    public class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; } //•	Name - text with length[2, 40] (required)

        
        public DateTime OpenDate { get; set; } //•	OpenDate - date and time(required)

        
        public DateTime? DueDate { get; set; } //•	DueDate - date and time(can be null)

        public ICollection<Task> Tasks { get; set; }

       

    }
}
