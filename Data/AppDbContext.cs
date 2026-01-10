using BookManagement.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookManagement.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================
            // SOFT DELETE (Global Filter)
            // =========================
            modelBuilder.Entity<Book>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Order>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<OrderItem>()
                .HasQueryFilter(x => !x.IsDeleted);


            // =========================
            // SEED DATA (STATIC DATE!)
            // =========================
            var createdDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Bilim Kurgu",
                    IsDeleted = false,
                    CreatedAt = createdDate,
                    UpdatedAt = createdDate
                },
                new Category
                {
                    Id = 2,
                    Name = "Dünya Klasikleri",
                    IsDeleted = false,
                    CreatedAt = createdDate,
                    UpdatedAt = createdDate
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash = "admin123", // test için
                    Role = "Admin",
                    IsDeleted = false,
                    CreatedAt = createdDate,
                    UpdatedAt = createdDate
                }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Dune",
                    Author = "Frank Herbert",
                    Price = 250,
                    Stock = 50,
                    CategoryId = 1,
                    IsDeleted = false,
                    CreatedAt = createdDate,
                    UpdatedAt = createdDate
                },
                new Book
                {
                    Id = 2,
                    Title = "Suç ve Ceza",
                    Author = "Dostoyevski",
                    Price = 180,
                    Stock = 100,
                    CategoryId = 2,
                    IsDeleted = false,
                    CreatedAt = createdDate,
                    UpdatedAt = createdDate
                }
            );
        }

        // =========================
        // AUTOMATIC DATE HANDLING
        // =========================
        public override int SaveChanges()
        {
            SetDateTimes();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
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
