using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicHub.Data.Models
{
    public class SongPerformer // Mapping Table 
    {
        [ForeignKey(nameof(Song))]
        public int SongId { get; set; } //•	SongId – integer, Primary Key
        [Required]
        public virtual Song Song { get; set; } //•	Song – the performer's Song (required)
                                               


        [ForeignKey(nameof(Performer))]
        public int PerformerId { get; set; } //•	PerformerId – integer, Primary Key       
        [Required]
        public virtual Performer Performer { get; set; }  //•	Performer – the song's Performer (required)






    }
}
