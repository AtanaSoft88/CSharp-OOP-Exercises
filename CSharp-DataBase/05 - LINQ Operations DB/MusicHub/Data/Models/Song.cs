using MusicHub.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class Song
    {
        public Song()
        {
            SongPerformers = new HashSet<SongPerformer>();
        }
        [Key]
        public int Id { get; set; } //•	Id – integer, Primary Key

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }  //•Name – text with max length 20 (required)

        [Required]
        public TimeSpan Duration { get; set; } //•Duration – timeSpan(required)

        [Required]
        public DateTime CreatedOn { get; set; } //•CreatedOn – date(required)

        [Required]
        public Genre Genre { get; set; } //•Genre - genre enumeration with possible values: "Blues, Rap, PopMusic, Rock, Jazz" (required)

        [ForeignKey(nameof(Album))]
        public int? AlbumId { get; set; } // AlbumId – integer, foreign key - > Check if Can be null?
        public virtual Album Album { get; set; } //•Album – the song's album // Nav         

        [Required]
        [ForeignKey(nameof(Writer))]
        public int WriterId { get; set; } //•WriterId – integer, Foreign key(required)
        public virtual Writer Writer { get; set; } //•	Writer – the song's writer ?? // Nav      

        public decimal Price { get; set; } //•	Price – decimal (required) by default it is no need to be Required

        public virtual ICollection<SongPerformer> SongPerformers { get; set; } //•SongPerformers – a collection of type SongPerformer

        





    }
}
