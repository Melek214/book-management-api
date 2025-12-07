using System.ComponentModel.DataAnnotations;

namespace BookManagement.API.DTOs
{
    public class OrderItemCreateDto
    {
        [Required]
        public int BookId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Miktar 1 veya daha fazla olmalıdır.")]
        public int Quantity { get; set; }
    }
}