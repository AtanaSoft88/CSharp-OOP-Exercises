﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Import_DTO
{
    [XmlType("Customer")]
    public class ImportCustomerDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("birthDate")]
        public DateTime BirthDate { get; set; }


        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
        
    }
}
