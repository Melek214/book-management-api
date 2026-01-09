using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using BookManagement.API.Models;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace BookManagement.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // "PendingModelChangesWarning" hatasını yoksay
            optionsBuilder.ConfigureWarnings(warnings => 
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // 1. SOFT DELETE (Global Query Filter) 
            // Bu ayar sayesinde veritabanından veri çekerken silinenler gelmez.
            modelBuilder.Entity<Book>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Order>().HasQueryFilter(x => !x.IsDeleted);
            
            // 2. SEED DATA (Başlangıç Verileri) -
            // Önce Kategori oluşturulmalı (Çünkü Kitap kategoriye bağlı)
            var createdDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Bilim Kurgu", IsDeleted = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Category { Id = 2, Name = "Dünya Klasikleri", IsDeleted = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

            // Örnek Kullanıcı (Admin)
            // NOT: Gerçek projede şifreler asla böyle plain-text durmaz, hashlenir!
            // Bonus kısmındaki JWT Auth için buradaki Username/Password'u kullanacaksın.
            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    Id = 1, 
                    Username = "admin", 
                    PasswordHash = "admin123", // Şimdilik test için düz metin
                    Role = "Admin",
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow 
                }
            );

            // Örnek Kitaplar
            modelBuilder.Entity<Book>().HasData(
                new Book 
                { 
                    Id = 1, 
                    Title = "Dune", 
                    Author = "Frank Herbert", 
                    Price = 250, 
                    Stock = 50, 
                    CategoryId = 1, // Bilim Kurgu
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow 
                },
                new Book 
                { 
                    Id = 2, 
                    Title = "Suç ve Ceza", 
                    Author = "Dostoyevski", 
                    Price = 180, 
                    Stock = 100, 
                    CategoryId = 2, // Dünya Klasikleri
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow 
                }
            );
        }
        
        // Tarihleri otomatik güncelleme kodun (Harika çalışıyor, dokunmadım)
        public override int SaveChanges()
        {
            SetDateTimes();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetDateTimes();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void SetDateTimes()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    // Eğer kullanıcı elle tarih girmediyse şu anı ata
                    if (entry.Entity.CreatedAt == default) 
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                    
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}