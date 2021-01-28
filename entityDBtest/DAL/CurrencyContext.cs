using entityDBtest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace entityDBtest
{
    public class CurrencyContext : DbContext
    {
        public DbSet<DateString> DateString { get; set; }
        public DbSet<Currency> Currency { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=CurrencyDB;Trusted_Connection=True;");
        }
    }
}
