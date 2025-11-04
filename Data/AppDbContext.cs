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
    }
}