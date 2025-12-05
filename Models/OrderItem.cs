namespace BookManagement.API.Models
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; }   // FK -> Order
        public Order Order { get; set; }

        public int BookId { get; set; }    // FK -> Book
        public Book Book { get; set; }

        public int Quantity { get; set; }       // Kaç adet alınmış?
        public decimal PriceAtPurchase { get; set; } // Alındığı andaki fiyat
    }
}