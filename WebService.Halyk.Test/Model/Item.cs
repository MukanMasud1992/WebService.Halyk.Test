using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace WebService.Halyk.Test.Model
{
    [XmlRoot("item")]
    public class Item
    {
        [XmlElement("fullname")]
        public string Fullname { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("description")]
        public decimal Description { get; set; }
        [XmlElement("quant")]
        public int Quant { get; set; }
        [XmlElement("index")]
        public string Index { get; set; }
        [XmlElement("change")]
        public string Change { get; set; }
    }

}
