using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SoftJail.Data.Models
{
    public class OfficerPrisoner
    {
        [Required]
        [ForeignKey(nameof(Prisoner))]
        public int PrisonerId { get; set; }
        public Prisoner Prisoner { get; set; }

        [Required]
        [ForeignKey(nameof(Officer))]
        public int OfficerId { get; set; }
        public Officer Officer { get; set; }
        //•	PrisonerId – integer, Primary Key
        //•	Prisoner – the officer’s prisoner(required)
        //•	OfficerId – integer, Primary Key
        //•	Officer – the prisoner’s officer(required)

    }
}
