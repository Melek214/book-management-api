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

        // İstersen burada Fluent API ile konfigürasyon yapabiliriz (ileride)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Örneğin decimal için precision ayarı vb. ileride ekleyebiliriz.
        }
    }
}