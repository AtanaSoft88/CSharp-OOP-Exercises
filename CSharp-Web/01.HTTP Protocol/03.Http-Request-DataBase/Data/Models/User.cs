using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Test_Http_Request.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }      
        public int Age { get; set; }

        [Required]
        [RegularExpression("[A-Za-z0-9]+@[a-zA-Z]+.[a-z]{2,4}")]
        public string Email { get; set; }



    }
}
