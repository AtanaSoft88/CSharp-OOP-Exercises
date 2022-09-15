using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        public Performer()
        {
            PerformerSongs = new HashSet<SongPerformer>();
        }
        [Key]
        public int Id { get; set; } //•	Id – integer, Primary Key
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; } //•	FirstName – text with max length 20 (required) 

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; } //•	LastName – text with max length 20 (required) 
        public int Age { get; set; }    //•	Age – integer(required) by default - ok

        public decimal NetWorth { get; set; } //•	NetWorth – decimal (required) by default - ok

        public ICollection<SongPerformer> PerformerSongs { get; set; }  //•	PerformerSongs – a collection of type SongPerformer 

        


    }
}
