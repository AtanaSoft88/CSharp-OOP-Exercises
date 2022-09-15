using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DTO
{
    public class BookDTO
    {
        public string Title { get; set; }       //Book Title

        public string Description { get; set; } //Book Description       

        public decimal Price { get; set; }      //Book Price 

        public int Copies { get; set; } //Book Copies 
    }
}
