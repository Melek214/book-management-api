using System;

namespace BookManagement.API.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }               // Her tablonun primary key'i
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Kayıt oluşturulma zamanı
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Son güncellenme zamanı
        
        // BONUS: Soft Delete için gerekli alan
        public bool IsDeleted { get; set; } = false;
    }
}