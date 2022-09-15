using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.Data.Models
{
    public class Task
    {
        public Task()
        {
            EmployeesTasks = new HashSet<EmployeeTask>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; } //Name - text with length[2, 40] (required)

        [Required]
        public DateTime OpenDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public ExecutionType ExecutionType { get; set; } //enumeration of type ExecutionType (required)
        public LabelType LabelType { get; set; } //enumeration of type LabelType (required)

        [Required]
        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<EmployeeTask> EmployeesTasks { get; set; }       
       
        

    }
}
