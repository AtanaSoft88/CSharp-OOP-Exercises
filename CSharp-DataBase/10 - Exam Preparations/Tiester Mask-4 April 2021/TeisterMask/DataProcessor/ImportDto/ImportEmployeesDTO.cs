using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeesDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression("^[A-Za-z0-9]{3,40}$")]
        public string Username { get; set; } //text with length [3, 40]. Should contain only lower or upper case letters and/or digits. (required)
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]        
        [RegularExpression("^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        public string Phone { get; set; }

        public List<int> Tasks { get; set; }
    }

    
}
