using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlTypes;
using WebService.Halyk.Test.Data;
using WebService.Halyk.Test.Interfaces;
using WebService.Halyk.Test.Model;

namespace WebService.Halyk.Test.Repository
{
    public class CurrencyRepository:ICurrencyRepository
    {
        private readonly DataContext _dataContext;

        public CurrencyRepository(DataContext dataContext) 
        {
            this._dataContext=dataContext;
        }

        public bool CreateCurrency(List<Currency> currencies)
        {
            _dataContext.Currencies.AddRange(currencies);
            return Save();
        }

        public ICollection<Currency> GetCurrency(string date, string? code)
        {
            List<Currency> currencies;
            DateTime dateTime = DateTime.Parse(date);
            SqlParameter dateParam = new SqlParameter("@A_DATE", dateTime);
            if (code==null)
            {
                SqlParameter codeParam2 = new SqlParameter("@CODE", code??(object)DBNull.Value);
                return currencies = _dataContext.Currencies.FromSqlRaw("sp_GetRates @A_DATE, @CODE", dateParam, codeParam2).ToList();
                
            }
            SqlParameter codeParam = new SqlParameter("@CODE", code);
            return currencies = _dataContext.Currencies.FromSqlRaw("sp_GetRates @A_DATE, @CODE", dateParam,codeParam).ToList();
        }
        public bool Save()
        {
            var saveChanges = _dataContext.SaveChanges();
            return saveChanges>0?true:false;
        }
    }
}
