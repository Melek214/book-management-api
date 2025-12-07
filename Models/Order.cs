using System.Collections.Generic;

namespace BookManagement.API.Models
{
    public class Order : BaseEntity
    {
        public string CustomerName { get; set; }
        public decimal TotalPrice { get; set; }

        // Bir siparişin birden fazla OrderItem'ı olabilir
        public List<OrderItem> Items { get; set; } = new();
    }
}