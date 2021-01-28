using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace entityDBtest.Models
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        public string CurrencyCode { get; set; }
        public double Rate { get; set; }        
        public DateString Updated { get; set; }

    }
}
