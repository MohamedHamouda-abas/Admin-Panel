using LastRevisonRazor_Temp.Models;
using Microsoft.EntityFrameworkCore;

namespace LastRevisonRazor_Temp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                 new Category { Id = 1, Name = "Action", DisPlayOrder = 1 },
                 new Category { Id = 2, Name = "Drama", DisPlayOrder = 2 },
                 new Category { Id = 3, Name = "Comedy", DisPlayOrder = 3 }
                );
        }
    }
}
