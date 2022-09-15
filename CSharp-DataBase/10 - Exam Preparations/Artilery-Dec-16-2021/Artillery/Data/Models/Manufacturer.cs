using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Artillery.Data.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Guns = new HashSet<Gun>();
        }
        public int Id { get; set; }        

        [Index(nameof(ManufacturerName),IsUnique =true)] //- set by Attribute to be UNIQUE 
        [Required]
        [MaxLength(40)]
        public string ManufacturerName { get; set; } // Cab be set Unique in DB Context 

        [Required]
        [MaxLength(100)]
        public string Founded { get; set; }

        public ICollection<Gun> Guns { get; set; }
        //•	Id – integer, Primary Key
        //•	ManufacturerName – unique text with length[4…40] (required)
        //•	Founded – text with length[10…100] (required)
        //•	Guns – a collection of Gun

    }
}
