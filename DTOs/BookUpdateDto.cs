namespace BookManagement.API.DTOs
{
    public class BookUpdateDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}