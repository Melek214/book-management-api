using System.ComponentModel.DataAnnotations;

public class BookCreateDto
{
    [Required(ErrorMessage = "Kitap adı boş olamaz.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Yazar adı boş olamaz.")]
    public string Author { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Stok 1 veya daha fazla olmalıdır.")]
    public int Stock { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "Fiyat 1 veya daha fazla olmalıdır.")]
    public decimal Price { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir kategori seçiniz.")]
    public int CategoryId { get; set; }
}