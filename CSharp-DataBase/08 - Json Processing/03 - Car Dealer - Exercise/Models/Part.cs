﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarDealer.Models
{
    public class Part
    {
        public Part()
        {
            PartCars = new HashSet<PartCar>();
        }
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public ICollection<PartCar> PartCars { get; set; }

        //•	A car has many parts and one part can be placed in many cars.
    }
}
