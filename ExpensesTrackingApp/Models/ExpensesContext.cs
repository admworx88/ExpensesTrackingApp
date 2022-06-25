using ExpensesTrackingApp.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackingApp.Models
{
    public class ExpensesContext:DbContext
    {
        public ExpensesContext()
        {

        }
        public ExpensesContext(DbContextOptions<ExpensesContext> options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("connString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Customers> Customers { get; set; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

    }
}
