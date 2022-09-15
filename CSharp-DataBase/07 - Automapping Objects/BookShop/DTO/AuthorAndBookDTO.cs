using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DTO
{
    public class AuthorAndBookDTO
    {
        //This way we Manually MAP the needed properties and Classes to a single Class with needed properties
        // we dont have Author's FullName property ,so we need to configure it in order to be mapped properly
        
        public int Id { get; set; }
        public string FullName { get; set; }  //Author FullName
        public string Title { get; set; } //Book Title 
        public decimal Price { get; set; } //Book Price 
        public string CategoryName { get; set; } //Category Name
        


    }
}
