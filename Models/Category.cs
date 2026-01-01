using System.Collections.Generic;

namespace BookManagement.API.Models
{
    //1 Category → n Book ilişkisini EF Core bu şekilde anlıyor.
    public class Category : BaseEntity
    {
        public string Name { get; set; }    // Örn: Roman, Bilim Kurgu, Klasik vb.

        // İlişkiler
        public ICollection<Book> Books { get; set; }   // Bu kategoriye ait kitaplar
    }
}