using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace WebService.Halyk.Test.Model
{
    [XmlRoot("rates")]
    public class Rates
    {
        [XmlElement("item")]
        public Item[] Items { get; set; }
    }
}
