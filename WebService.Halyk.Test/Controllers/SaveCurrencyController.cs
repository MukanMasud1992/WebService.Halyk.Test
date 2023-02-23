using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using System.Data.SqlTypes;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using WebService.Halyk.Test.Interfaces;
using WebService.Halyk.Test.Model;
using static System.Net.WebRequestMethods;

namespace WebService.Halyk.Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveCurrencyController : Controller
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IDeserializerXML _deserializerXML;

        public SaveCurrencyController(ICurrencyRepository currencyRepository, IDeserializerXML deserializerXML)
        {
            this._currencyRepository=currencyRepository;
            this._deserializerXML=deserializerXML;
        }

        [HttpGet("currency/save/{date}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Currency>))]
        [ProducesResponseType(400)]
        public IActionResult GetCurrency(string date)
        
        {
            List<Currency> currencies= new List<Currency>();
            Rates rates = _deserializerXML.GetRates(date);
            DateTime dateTime = DateTime.Parse(date);
             
            if (rates!=null)
            {
                for (int i = 0; i < rates.Items.Length; i++)
                {
                    Currency currency = new Currency();
                    currency.Title = rates.Items[i].Fullname;
                    currency.Code = rates.Items[i].Title.ToUpper();
                    currency.Value = rates.Items[i].Description;
                    currency.A_Date = dateTime;
                    currencies.Add(currency);

                }
                _currencyRepository.CreateCurrency(currencies);
                return Ok("Succes data saved in localDB " + currencies.Count.ToString());
            }
            else
            {
                ModelState.AddModelError("", "Something goes wrong when get XML file");
                return BadRequest(ModelState);
            }
        }

        [HttpGet("currency/{date}/{code?}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Currency>))]
        [ProducesResponseType(400)]
        public IActionResult GetCurrency(string date, string? code)
        
        {
            var currencies = _currencyRepository.GetCurrency(date, code);
            if(currencies!=null) 
            {
                return Ok(currencies);
            }
            ModelState.AddModelError("", "Something goes wrong go to developer");
            return BadRequest(ModelState);
        }
    }
}
