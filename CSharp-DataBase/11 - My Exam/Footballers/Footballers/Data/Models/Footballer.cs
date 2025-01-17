﻿using Footballers.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Footballers.Data.Models
{
    public class Footballer
    {
        public Footballer()
        {
            TeamsFootballers = new HashSet<TeamFootballer>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public DateTime ContractStartDate { get; set; }
        
        [Required]
        public DateTime ContractEndDate { get; set; }

        [Required]
        public PositionType PositionType { get; set; }

        [Required]
        public BestSkillType BestSkillType { get; set; }

        [Required]
        [ForeignKey(nameof(Coach))]
        public int CoachId { get; set; }

        public Coach Coach { get; set; }

        public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; }
        //•	Id – integer, Primary Key
        //•	Name – text with length[2, 40] (required)
        //•	ContractStartDate – date and time(required)
        //•	ContractEndDate – date and time(required)
        //•	PositionType – enumeration of type PositionType, with possible values(Goalkeeper, Defender, Midfielder, Forward) (required) 
        //•	BestSkillType – enumeration of type BestSkillType, with possible values(Defence, Dribble, Pass, Shoot, Speed) (required)
        //•	CoachId – integer, foreign key(required)
        //•	Coach – Coach 
        //•	TeamsFootballers – collection of type TeamFootballer

    }
}
