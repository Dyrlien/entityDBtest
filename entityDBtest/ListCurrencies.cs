using entityDBtest.DAL;
using entityDBtest.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace entityDBtest
{
    public class ListCurrencies
    {
        CurrencyRep CurrRep = new CurrencyRep();        

        List<Currency> CurrenciesList = new List<Currency>();

        public static List<JToken> currencies = new List<JToken>();  
        
        public DateString CurrentDate = new DateString();
        public async Task LoadCurrencies()
        {
            currencies.Clear();
            HttpClient client = new HttpClient();

            string url = "http://data.fixer.io/api/2018-02-25?access_key=a811a7a4f347a1c280eaf781ed121ccb";
            var response = await client.GetAsync(string.Format(url));

            string result = await response.Content.ReadAsStringAsync();

            JObject data = JObject.Parse(result);
            
            CurrentDate.Date = data["date"].ToString();

            foreach (var i in data["rates"])
            {
                currencies.Add(i);
            }
        }
        public void ToList()
        {
            foreach (var entry in ListCurrencies.currencies.OfType<JProperty>())
            {
                Currency aCurrency = new Currency()
                {
                    Updated = CurrentDate,
                    CurrencyCode = entry.Name,
                    Rate = double.Parse(entry.Value.ToString())
                };
                CurrenciesList.Add(aCurrency);
            }
            Task task = CurrRep.ToDB(CurrenciesList, CurrentDate);
            task.Wait();
        }        
    }
}
