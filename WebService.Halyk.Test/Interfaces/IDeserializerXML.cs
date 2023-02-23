using WebService.Halyk.Test.Model;

namespace WebService.Halyk.Test.Interfaces
{
    public interface IDeserializerXML
    {
        public Rates GetRates(string date);
    }
}
