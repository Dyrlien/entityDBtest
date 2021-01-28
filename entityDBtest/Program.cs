using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace entityDBtest
{
    public class CurrencyContext : DbContext
    {
        public DbSet<Currency> Currency { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=CurrencyDB;Trusted_Connection=True;");
        }
    }
    public class Currency
    {
        [Key]
        public string Date { get; set; }
        public string CurrencyCode { get; set; }
        public string Rate { get; set; }

}
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
