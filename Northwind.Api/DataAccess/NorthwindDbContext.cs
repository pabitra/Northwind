using System;
using Microsoft.EntityFrameworkCore;
using Northwind.Api.Domain;

namespace Northwind.Api.DataAccess
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(
                //@"Server=localhost;Database=Northwind;UserName=sa;Password=Pabitra@123;Integrated Security=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Supplier>().ToTable("Suppliers");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Category>().ToTable("Categories");
        }

        
    }
}
