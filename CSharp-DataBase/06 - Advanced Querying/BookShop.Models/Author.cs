using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; } //o AuthorId

        [MaxLength(50)]
        public string FirstName { get; set; } //o FirstName(up to 50 characters, unicode, not required) -> it is unicode by default

        [Required]
        public string LastName { get; set; } //o LastName(up to 50 characters, unicode) -> it is unicode by default

        public ICollection<Book> Books { get; set; } // not given by default but we know Author is refered by Book ,as One Author has Many books

    }
}
