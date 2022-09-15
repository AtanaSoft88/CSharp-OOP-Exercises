using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Export_DTO
{
    [XmlType("sale")]
    public class ExportSalesWithDiscount
    {
        [XmlElement("car")]
        public ExportCarInfoDTO CarInfo { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public decimal PriceDiscounted 
        {
            get => Price * (1 - (Discount / 100.0M));
            set 
            {
                this.PriceDiscounted = value;
            }
        } 

    }
}
