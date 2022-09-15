using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            Songs = new HashSet<Song>();
        }
        public int Id { get; set; } //•	Id – integer, Primary Key

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }    //•	Name – text with max length 40 (required)                                           
        
        public DateTime ReleaseDate { get; set; } //•	ReleaseDate – date(required) //Required by default , no need attribute

        public decimal Price => this.Songs.Sum(x=>x.Price); //•	Price – calculated property(the sum of all song prices in the album)

        [ForeignKey(nameof(Producer))]
        public int? ProducerId { get; set; } //•	ProducerId – integer, foreign key - must be nullable
        public virtual Producer Producer { get; set; } //•	Producer – the album's producer

        public virtual ICollection<Song> Songs { get; set; } //•Songs – a collection of all Songs in the Album





    }
}
