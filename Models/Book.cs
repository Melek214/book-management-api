using System.Collections.Generic;

namespace BookManagement.API.Models
{
    public class Book : BaseEntity //Book : BaseEntity diyerek Id, CreatedAt, UpdatedAt otomatik geliyor.
    {
        public string Title { get; set; }     // Kitap adı
        public string Author { get; set; }    // Yazar
        public int Stock { get; set; }        // Stok adedi
        public decimal Price { get; set; }    // Fiyat

        // İlişkiler
        public int CategoryId { get; set; }   // FK -> Category
        public Category Category { get; set; }   // Navigation property

        public ICollection<OrderItem> OrderItems { get; set; }  // Bir kitap birçok sipariş satırında olabilir
    }
}