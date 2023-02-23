using WebService.Halyk.Test.Model;

namespace WebService.Halyk.Test.Interfaces
{
    public interface ICurrencyRepository
    {
        ICollection<Currency> GetCurrency(string date, string? code);
        public bool CreateCurrency(List<Currency> currencies);
        bool Save();
    }
}
