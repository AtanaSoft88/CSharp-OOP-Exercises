using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Writer
    {
        public Writer()
        {
            Songs = new HashSet<Song>();
        }
        [Key]
        public int Id { get; set; } //•	Id – integer, Primary Key

        [Required]
        [MaxLength(20)]
        public string Name { get; set; } //•Name – text with max length 20 (required)
        public string Pseudonym { get; set; } //•Pseudonym – text
        public virtual ICollection<Song> Songs { get; set; }  //•Songs – a collection of type Song




    }
}
