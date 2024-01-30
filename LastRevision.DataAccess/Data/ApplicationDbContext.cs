using LastRevision.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace LastRevision.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options) : base(Options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisPlayOrder = 1 },
                new Category { Id = 2, Name = "Drama", DisPlayOrder = 2 },
                new Category { Id = 3, Name = "Comedy", DisPlayOrder = 3 }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Nemo", Description = "I try do inter any data", ISBN = "8000Aa961211", Author = "MicelAnglo", Price = 63 ,CategoryId=1, ImageUrl =""},
                new Product { Id = 2, Title = "ToyStory", Description = "I try do inter any data", ISBN = "8000Aa961211", Author = "MicelAnglo", Price = 62 ,CategoryId = 3, ImageUrl = "" },
                new Product { Id = 3, Title = "Tangle", Description = "I try do inter any data", ISBN = "8000Aa961211", Author = "MicelAnglo", Price = 87 ,CategoryId = 1 , ImageUrl = "" },
                new Product { Id = 4, Title = "Snowite", Description = "I try do inter any data", ISBN = "8000Aa961211", Author = "MicelAnglo", Price = 16, CategoryId = 2, ImageUrl = "" },
                new Product { Id = 5, Title = "Fola", Description = "I try do inter any data", ISBN = "8000Aa961211", Author = "MicelAnglo", Price = 80 ,CategoryId = 3 , ImageUrl = "" },
                new Product { Id = 6, Title = "mongel", Description = "I try do inter any data", ISBN = "8000Aa961211", Author = "MicelAnglo", Price = 40 ,CategoryId = 1, ImageUrl = "" },
                new Product { Id = 7, Title = "Trazan", Description = "I try do inter any data", ISBN = "8000Aa961211", Author = "MicelAnglo", Price = 78 ,CategoryId = 2 , ImageUrl = "" }
            );
        }
    }
}
