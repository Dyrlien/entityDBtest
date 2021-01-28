using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace entityDBtest
{
    public class Currencies
    {
        public string Date { get; set; }
        public string CurrencyCode { get; set; }
        public string Rate { get; set; }

        public Currencies(string date, string CC, string rate)
        {
            Date = date;
            CurrencyCode = CC;
            Rate = rate;
        }

    }
    public class ListCurrencies
    {
        List<Currency> CurrenciesList = new List<Currency>();

        public static List<JToken> currencies = new List<JToken>();
        public string CurrentDate;
        //public Date CurrentDate = new Date();
        public async Task LoadCurrencies()
        {
            currencies.Clear();
            HttpClient client = new HttpClient();

            string url = "http://data.fixer.io/api/latest?access_key=a811a7a4f347a1c280eaf781ed121ccb";
            var response = await client.GetAsync(string.Format(url));

            string result = await response.Content.ReadAsStringAsync();

            JObject data = JObject.Parse(result);
            CurrentDate = data["date"].ToString();

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
                    Date = CurrentDate,
                    CurrencyCode = entry.Name,
                    Rate = entry.Value.ToString()
                };
                CurrenciesList.Add(aCurrency);
            }
        }
        public async Task ToDB()
        {
            await using (var context = new CurrencyContext())
            {
                foreach (var i in CurrenciesList)
                {
                    context.Currency.Add(i);
                }
                context.SaveChanges();
            }
        }
    }
    public class CurrencyContext : DbContext
    {
        public DbSet<Currency> Currency { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=CurrencyDB;Trusted_Connection=True;");
        }
    }
    /*public class Date
    {
        [Key]
        public string date;
    }
    [Keyless]*/
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        public string Date { get; set; }
        public string CurrencyCode { get; set; }
        public string Rate { get; set; }

        //[ForeignKey("Date")]
        
               
    }
    class Program
    {
        static void Main(string[] args)
        {
            ListCurrencies test = new ListCurrencies();
            Task task = test.LoadCurrencies();
            task.Wait();
            test.ToList();
            task = test.ToDB();
            task.Wait();
            Console.ReadLine();
        }
    }
}
