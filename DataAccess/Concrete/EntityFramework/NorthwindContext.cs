using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: Connection of database tables with project classes.
    class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=Northwind; Trusted_Connection=true"); // Defining that we will use SQL Server.
        }

        public DbSet<Product> Products { get; set; } // Here we define which DB Table element correspond to which class in the project.
        public DbSet<Category> Category { get; set; }
        public DbSet<Customer> Customer { get; set; }
    }
}
