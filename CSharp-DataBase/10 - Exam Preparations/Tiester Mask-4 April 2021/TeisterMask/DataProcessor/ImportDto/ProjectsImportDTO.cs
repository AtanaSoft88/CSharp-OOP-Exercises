using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ProjectsImportDTO
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]        
        public string OpenDate { get; set; }


        [XmlElement("DueDate")] // can be null
        
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public TasksImportDTO[] Tasks { get; set; }    

    }

    [XmlType("Task")]
    public class TasksImportDTO
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        [Required]
        
        public string DueDate { get; set; }

        [Required]
        public int ExecutionType { get; set; }

        [Required]
        public int LabelType { get; set; }
        
    }
}
