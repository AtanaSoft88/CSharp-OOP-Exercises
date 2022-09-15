using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CarDealer.Models
{
    public class Car
    {
        public Car()
        {
            PartCars = new HashSet<PartCar>();
            Sales = new HashSet<Sale>();
        }
        [Key]
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TraveledDistance { get; set; }

        public ICollection<Sale> Sales { get; set; }
        
        public ICollection<PartCar> PartCars { get; set; }

    }   //	A car has many parts and one part can be placed in many cars.
}