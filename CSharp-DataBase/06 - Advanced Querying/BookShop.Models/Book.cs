using BookShop.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShop.Models
{
    public class Book
    {
        public Book()
        {
            BookCategories = new HashSet<BookCategory>();
        }
        [Key]
        public int BookId { get; set; }  //o BookId

        [Required]
        [MaxLength(50)]
        public string Title { get; set; } //o Title(up to 50 characters, unicode)

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } //o Description(up to 1000 characters, unicode)

        public DateTime? ReleaseDate { get; set; } //o ReleaseDate(not required) -> can be null ,it is value type we must make it nullable with "?"

        public int Copies { get; set; } //o Copies(an integer)        
        public decimal Price { get; set; } //o Price

        public EditionType EditionType { get; set; } //o EditionType – enum (Normal, Promo, Gold)
        public AgeRestriction AgeRestriction { get; set; } //o   AgeRestriction – enum (Minor, Teen, Adult)

        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; } 
        public Author Author { get; set; } //o   Author

        public virtual ICollection<BookCategory> BookCategories { get; set; } //o   BookCategories
        



    }
}
