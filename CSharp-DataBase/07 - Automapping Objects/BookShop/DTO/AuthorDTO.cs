using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DTO
{
    public class AuthorDTO
    {
        public int AuthorId { get; set; }

        public string FullName { get; set; } // we dont have FullName property ,so we need to configure it in order to be mapped properly

       

    }
}
