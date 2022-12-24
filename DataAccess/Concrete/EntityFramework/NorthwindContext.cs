using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=True");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("admin");
            modelBuilder.Entity<Car>().ToTable("Products");

            modelBuilder.Entity<Car>().Property(c=>c.Id).HasColumnName("ProductID");
            modelBuilder.Entity<Car>().Property(c => c.Name).HasColumnName("ProductName");
            modelBuilder.Entity<Car>().Property(c => c.CategoryId).HasColumnName("CategoryID");
            modelBuilder.Entity<Car>().Property(c => c.DailyPrice).HasColumnName("UnitPrice");


        }


    }
}
