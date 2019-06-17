using System;
using Microsoft.EntityFrameworkCore;
using Northwind.Api.Domain;

namespace Northwind.Api.DataAccess
{
    public class NorthwindDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=Northwind;UserName=sa;Password=Pabitra@123;Integrated Security=false");
        }  


    }
}
