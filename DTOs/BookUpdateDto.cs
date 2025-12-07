using System.ComponentModel.DataAnnotations;

namespace BookManagement.API.DTOs
{
    public class BookUpdateDto
    {
        [Required(ErrorMessage = "Kitap adı boş olamaz.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Yazar adı boş olamaz.")]
        public string Author { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Stok 1 veya daha fazla olmalıdır.")]
        public int Stock { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Fiyat 1 veya daha fazla olmalıdır.")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir kategori seçiniz.")]
        public int CategoryId { get; set; }
    }
}