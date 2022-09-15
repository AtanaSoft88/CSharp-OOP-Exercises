using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Import_DTO
{
    [XmlType("Supplier")] // must include this attribute for the Class
    public class ImportSupplierDTO
    {
        [XmlElement("name")] // must include this attribute for prop
       public string Name { get; set; }

        [XmlElement("isImporter")] // must include this attribute for prop
        public bool IsImporter { get; set; }
    }
}
