using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using P224FirstApi.Configurations;
using P224FirstApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P224FirstApi.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //dotnet ef migrations add CratedCategoryTable --context AppDbContext --output-dir DAL/Migrations
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //modelBuilder.Entity<Category>().HasData(
            //    new Category { Id = 1, Name = "Test" },
            //    new Category { Id = 2, Name = "Test" },
            //    new Category { Id = 3, Name = "Test" },
            //    new Category { Id = 4, Name = "Test" },
            //    new Category { Id = 5, Name = "Test" },
            //    new Category { Id = 6, Name = "Test" },
            //    new Category { Id = 7, Name = "Test" }
            //        );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
