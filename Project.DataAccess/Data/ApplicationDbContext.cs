using Microsoft.EntityFrameworkCore;
using Project.Models;


namespace Project.DataAccess.Data
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
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                 new Category { Id = 1, Name = "Iphone", DisplayOrder = 1 },
                  new Category { Id = 2, Name = "SamSung", DisplayOrder = 2 },
                 new Category { Id = 3, Name = "Xiaomi", DisplayOrder = 3 }

                );
            //modelBuilder.Entity<Product>().HasData(
            //     new Product
            //     {
            //         Id = 1,
            //         Title = "Đắc Nhân Tâm",
            //         Author = "Phạm Xuân Tuyển",
            //         Description = "Sách về cuộc sống",
            //         ISBN = "17122002",
            //         ListPrice = 99,
            //         Price = 90,
            //         Price50 = 85,
            //         Price100 = 80,
            //         CategoryId = 1,
            //         ImageUrl = ""
            //     },
            //     new Product
            //     {
            //         Id = 2,
            //         Title = "Cha giàu cha nghèo",
            //         Author = "Phạm Xuân Tuyển",
            //         Description = "Sách về cuộc sống",
            //         ISBN = "31032008",
            //         ListPrice = 99,
            //         Price = 90,
            //         Price50 = 85,
            //         Price100 = 80,
            //         CategoryId = 2,
            //         ImageUrl = ""
            //     }


            //    );
        }
    }
}