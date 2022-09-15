using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartmentAndCellsDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; } //•	Name – text with min length 3 and max length 25 (required)

        public CellDTO[] Cells { get; set; }
    }

    public class CellDTO
    {
        [Required]
        [Range(1,1000)] // This can be checked in the nested foreach loop by isValid()
        public int CellNumber { get; set; }  //•	CellNumber – integer in the range[1, 1000] (required)
        public bool HasWindow { get; set; }  //•	HasWindow – bool (required)




    }
}
