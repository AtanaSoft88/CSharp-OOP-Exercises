using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VaporStore.Data.Models
{
    public class Game
    {
        public Game()
        {
            Purchases = new HashSet<Purchase>();
            GameTags = new HashSet<GameTag>();
        }
        [Key]
        public int Id { get; set; } //•	Id – integer, Primary Key
        [Required]
        public string Name { get; set; } //•	Name – text(required)
        [Required]
        public decimal Price { get; set; } //•	Price – decimal (non-negative, minimum value: 0) (required)

        public DateTime ReleaseDate { get; set; } //•	ReleaseDate – Date(required)

        [ForeignKey(nameof(Developer))]
        [Required]
        public int DeveloperId { get; set; }  //•	DeveloperId – integer, foreign key(required)

        [Required]
        public Developer Developer { get; set; } //•	Developer – the game’s developer(required)

        [Required]
        public int GenreId { get; set; } //•	GenreId – integer, foreign key(required)

        public Genre Genre { get; set; } //•	Genre – the game’s genre(required)

        public ICollection<Purchase> Purchases { get; set; } //•	Purchases - collection of type Purchase

        public ICollection<GameTag> GameTags { get; set; } //•	GameTags - collection of type GameTag.Each game must have at least one tag.



    }
}
