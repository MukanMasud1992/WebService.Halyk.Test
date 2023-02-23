using System.Net;
using System.Xml.Serialization;
using WebService.Halyk.Test.Interfaces;
using WebService.Halyk.Test.Model;

namespace WebService.Halyk.Test.Services
{
    public class DeserializerXML:IDeserializerXML
    {
        public Rates GetRates(string date)
        {
            var url = $"https://nationalbank.kz/rss/get_rates.cfm?fdate={date}";
            using (WebClient client = new WebClient())
            {
                string xmlData = client.DownloadString(url);
                XmlSerializer serializer = new XmlSerializer(typeof(Rates));
                using (StringReader reader = new StringReader(xmlData))
                {
                    // Десериализация XML в объект класса Example
                    Rates? rate = (Rates)serializer.Deserialize(reader);
                    if (rate.Items.Length>0)
                    {
                        return rate;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
