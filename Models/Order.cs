using System;
using System.Collections.Generic;

namespace BookManagement.API.Models
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }       // FK -> User
        public User User { get; set; }        // Navigation property

        public DateTime OrderDate { get; set; }  // Sipariş tarihi

        // İlişkiler
        public ICollection<OrderItem> OrderItems { get; set; } // Siparişin satırları
    }
}