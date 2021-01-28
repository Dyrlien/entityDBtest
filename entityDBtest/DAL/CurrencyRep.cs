using entityDBtest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace entityDBtest.DAL
{
    public class CurrencyRep
    {
        public async Task ToDB(List<Currency> CurrenciesList, DateString CurrentDate)
        {
            await using (var context = new CurrencyContext())
            {
                context.DateString.Add(CurrentDate);
                foreach (var i in CurrenciesList)
                {
                    context.Currency.Add(i);
                }
                context.SaveChanges();
            }
        }
    }
}
