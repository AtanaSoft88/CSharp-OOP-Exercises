using Artillery.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Artillery.DataProcessor.ImportDto
{

    public class ImportGunsDTO
    {
      
        public int ManufacturerId { get; set; }
        
        [Range(100,1350000)]
        public int GunWeight { get; set; }

        
        [Range(2.00,35.00)]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        
        [Range(1,100000)]
        public int Range { get; set; }

        
        public string GunType { get; set; } 

        public int ShellId { get; set; }

      
        public CountriesDTO[] Countries { get; set; }
    }

    public class CountriesDTO
    {
        
        public int Id { get; set; }
    }
}
