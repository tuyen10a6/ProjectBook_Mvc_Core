using Microsoft.EntityFrameworkCore;
using ProjectRazor_Temp.Models;

namespace ProjectRazor_Temp.Data
{
    public class ApplicationDbContext : DbContext
    {
        // ctor  * 2 tab
        // update-databse
        //add-migration AddCategoryTableToDb
        // add-migration SeedCategoryTable
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                 new Category { Id = 1, Name = "Iphone", DisplayOrder = 1 },
                  new Category { Id = 2, Name = "SamSung", DisplayOrder = 2 },
                 new Category { Id = 3, Name = "Xiaomi", DisplayOrder = 3 }

                );
        }
    }
}
