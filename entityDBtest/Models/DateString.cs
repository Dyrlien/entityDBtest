using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace entityDBtest.Models
{
    public class DateString
    {
        [Key]
        public string Date { get; set; }
    }
}
