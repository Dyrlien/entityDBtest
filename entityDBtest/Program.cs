using entityDBtest.DAL;
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
            
            Task task1 = test.LoadCurrencies();
            task1.Wait();
            test.ToList();
            
            
        }
    }
}
