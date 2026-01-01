using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.API.DTOs
{
    public class OrderCreateDto
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public List<OrderItemCreateDto> Items { get; set; }
    }
}