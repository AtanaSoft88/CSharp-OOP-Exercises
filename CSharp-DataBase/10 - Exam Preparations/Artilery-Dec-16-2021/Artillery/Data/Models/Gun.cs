﻿using Artillery.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Artillery.Data.Models
{
    public class Gun
    {
        public Gun()
        {
            CountriesGuns = new HashSet<CountryGun>();
        }
        public int Id { get; set; }


        [ForeignKey(nameof(Manufacturer))]
        [Required]
        public int ManufacturerId { get; set; }
        
        public Manufacturer Manufacturer { get; set; }  
        
        public int GunWeight { get; set; }
        
        public double BarrelLength { get; set; }
        public int? NumberBuild { get; set; }  // NULLABLE! - it is not written in the description
        public int Range { get; set; }
        public GunType GunType { get; set; }

        [ForeignKey(nameof(Shell))]
        [Required]
        public int ShellId { get; set; }        
        public Shell Shell { get; set; }

        public ICollection<CountryGun> CountriesGuns { get; set; }
        //•	Id – integer, Primary Key
        //•	ManufacturerId – integer, foreign key(required)
        //•	GunWeight– integer in range[100…1_350_000] (required)
        //•	BarrelLength – double in range[2.00….35.00] (required)
        //•	NumberBuild – integer
        //•	Range – integer in range[1….100_000] (required)
        //•	GunType – enumeration of GunType, with possible values(Howitzer, Mortar, FieldGun, AntiAircraftGun, MountainGun, AntiTankGun) (required)
        //•	ShellId – integer, foreign key(required)
        //•	CountriesGuns – a collection of CountryGun

    }
}
