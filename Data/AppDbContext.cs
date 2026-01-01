/*Bu sınıfın görevi:
PostgreSQL’e bağlanmak
Book modelini (kitap tablosunu) veritabanında yönetmek*/

using Microsoft.EntityFrameworkCore;
using BookManagement.API.Models;

namespace BookManagement.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; } // Book tablosunu temsil eder

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Roman" },
                new Category { Id = 2, Name = "Bilim" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Suç ve Ceza",
                    Author = "Dostoyevski",
                    Price = 150,
                    Stock = 10,
                    CategoryId = 1,
                    CreatedAt = new DateTime(2025, 1, 1)

                },
                new Book
                {
                    Id = 2,
                    Title = "Sefiller",
                    Author = "Victor Hugo",
                    Price = 120,
                    Stock = 8,
                    CategoryId = 1,
                    CreatedAt = new DateTime(2025, 1, 1)

                }
            );
        }
    }
}

