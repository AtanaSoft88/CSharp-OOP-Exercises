using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.Players = new List<Player>();
            this.HomeGames = new List<Game>();
            this.AwayGames = new List<Game>();
        }

        [Key]
        public int TeamId { get; set; }

        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string LogoUrl { get; set; }

        [Required]
        [MaxLength(3)]
        public string Initials { get; set; }

        // it is Required by default -> int,decimal,double,DateTime..etc
        // if we add "?" it will be able to accept NULL values!
        public decimal Budget { get; set; }


        [ForeignKey(nameof(PrimaryKitColor))]
        public int PrimaryKitColorId { get; set; } // FK
        public virtual Color PrimaryKitColor { get; set; } // nav prop   


        [ForeignKey(nameof(SecondaryKitColor))]
        public int SecondaryKitColorId { get; set; } //FK
        public virtual Color SecondaryKitColor { get; set; } // nav prop   

        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }  //FK
        public virtual Town Town { get; set; } // nav prop  

        public ICollection<Player> Players { get; set; }


        [InverseProperty(nameof(Game.HomeTeam))]
        public ICollection<Game> HomeGames { get; set; }


        [InverseProperty(nameof(Game.AwayTeam))]
        public ICollection<Game> AwayGames { get; set; }
    }
}
