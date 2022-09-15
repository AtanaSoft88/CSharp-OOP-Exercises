using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Models
{
    public class Category
    {
        public Category()
        {
            CategoryBooks = new HashSet<BookCategory>();
        }
        [Key]
        public int CategoryId { get; set; } //CategoryId
        [MaxLength(50)]
        public string Name { get; set; }  //o Name(up to 50 characters, unicode)

        public virtual ICollection<BookCategory> CategoryBooks { get; set; } //o CategoryBooks
        


    }
}
