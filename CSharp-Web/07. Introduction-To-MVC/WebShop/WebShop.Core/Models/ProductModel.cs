using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Models
{    
    public class ProductModel
    {        
        public Guid Id => Guid.NewGuid();

        [Required]
        [StringLength(35)]
        public string Name { get; set; } = null!; // It will be fulfilled after initialization "null!"

        
        [Range(typeof(decimal),"0.00","10000.00", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
