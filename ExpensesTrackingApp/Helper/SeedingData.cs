using ExpensesTrackingApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackingApp.Helper
{
    public static class SeedingData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>().HasData(
                new Customers
                {
                    Id = 1,
                    Name = "Customer A"
                },

                 new Customers
                 {
                     Id = 2,
                     Name = "Customer B",
                 },
                 new Customers
                 {
                     Id = 3,
                     Name = "Customer C",
                 },
                 new Customers
                 {
                     Id = 4,
                     Name = "Customer D",
                 },
                 new Customers
                 {
                     Id = 5,
                     Name = "Customer E",
                 }
               );

            modelBuilder.Entity<Projects>().HasData(
                 new Projects
                 {
                     Id = 1,
                     CustomerId = 1,
                     Name = "Project One",
                 },

                  new Projects
                  {
                      Id = 2,
                      CustomerId = 4,
                      Name = "Project One",
                  },

                  new Projects
                  {
                      Id = 3,
                      CustomerId = 2,
                      Name = "Project Two",
                  },

                  new Projects
                  {
                      Id = 4,
                      CustomerId = 2,
                      Name = "Project Three",
                  },
                  new Projects
                  {
                      Id = 5,
                      CustomerId = 3,
                      Name = "Project Four",
                  },
                  new Projects
                  {
                      Id = 6,
                      CustomerId = 4,
                      Name = "Project Three",
                  },
                  new Projects
                  {
                      Id = 7,
                      CustomerId = 5,
                      Name = "Project Four",
                  }
               );
        }
    }
}
