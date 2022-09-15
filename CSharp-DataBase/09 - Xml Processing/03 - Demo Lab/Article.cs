using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XML_Deserialize_fm_File
{
    [XmlType("doc")]
    [Serializable] // This Attribute is used only for the purpose - for Binary conversion
    public class Article
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("abstract")]
        public string Description { get; set; }

        //Not used Property can be ignored ,and wont be written into XML
        [XmlIgnore]
        public DateTime DataSignedOn { get; set; }

    }
}
