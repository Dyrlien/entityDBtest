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
        }
    }
}
