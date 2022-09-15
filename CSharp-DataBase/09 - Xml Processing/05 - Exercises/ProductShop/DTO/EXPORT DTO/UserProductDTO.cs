using System.Xml.Serialization;

namespace ProductShop.DTO.EXPORT_DTO
{
    [XmlType("Product")]
    public class UserProductDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}