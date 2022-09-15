using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Footballers.Data.Models
{
    public class TeamFootballer     // Mapping table with composite PK key -> {tf.FootballerId,tf.TeamId });
    {
        [Required]
        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
        public Team Team { get; set; }


        [Required]
        [ForeignKey(nameof(Footballer))]
        public int FootballerId { get; set; }
        public Footballer Footballer { get; set; }

        //•	TeamId – integer, Primary Key, foreign key(required)
        //•	Team – Team
        //•	FootballerId – integer, Primary Key, foreign key(required)
        //•	Footballer – Footballer


    }
}
