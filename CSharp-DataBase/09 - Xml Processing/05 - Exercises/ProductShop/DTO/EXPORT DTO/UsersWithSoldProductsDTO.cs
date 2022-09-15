using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DTO.EXPORT_DTO
{
    [XmlType("User")]
    public class UsersWithSoldProductsDTO
    {        
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public List<UserProductDTO> SoldProducts { get; set; }
    }
}
