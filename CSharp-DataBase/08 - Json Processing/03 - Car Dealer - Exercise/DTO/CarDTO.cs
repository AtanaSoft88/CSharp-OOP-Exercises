using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace CarDealer.DTO
{
    [DataContract] // this is Needed to include that properties below which are marked with [DataMember] attribute
    public class CarDTO
    {
        
        public CarDTO()
        {
            PartsId = new List<int>();
        }
        [DataMember] // this is needed property for json file
        public int Id { get; set; }
        [DataMember] // this is needed property for json file
        public string Make { get; set; }
        [DataMember] // this is needed property for json file
        public string Model { get; set; }
        [DataMember] // this is needed property for json file
        
        public long TravelledDistance { get; set; }

        
        // This is not included  if not marked with "[DataMember]" attribute
        public IEnumerable<int> PartsId { get; set; }
    }
}
