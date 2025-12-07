using BookManagement.API.Data;
using BookManagement.API.DTOs;
using BookManagement.API.Models;
using BookManagement.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.API.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OrderResponseDto> CreateOrderAsync(OrderCreateDto dto)
        {
            var order = new Order
            {
                CustomerName = dto.CustomerName,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            decimal totalPrice = 0;

            foreach (var item in dto.Items)
            {
                var book = await _context.Books.FindAsync(item.BookId);

                if (book == null)
                    throw new Exception("Kitap bulunamadı!");

                var orderItem = new OrderItem
                {
                    BookId = item.BookId,
                    Quantity = item.Quantity,
                    Price = book.Price * item.Quantity
                };

                totalPrice += orderItem.Price;
                order.Items.Add(orderItem);
            }

            order.TotalPrice = totalPrice;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return new OrderResponseDto
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                TotalPrice = totalPrice,
                Items = order.Items.Select(i => new OrderItemResponseDto
                {
                    BookId = i.BookId,
                    BookTitle = i.Book.Title,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList()
            };
        }

        public async Task<List<OrderResponseDto>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Book)
                .Select(o => new OrderResponseDto
                {
                    Id = o.Id,
                    CustomerName = o.CustomerName,
                    TotalPrice = o.TotalPrice,
                    Items = o.Items.Select(i => new OrderItemResponseDto
                    {
                        BookId = i.BookId,
                        BookTitle = i.Book.Title,
                        Quantity = i.Quantity,
                        Price = i.Price
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<OrderResponseDto> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Book)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return null;

            return new OrderResponseDto
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                TotalPrice = order.TotalPrice,
                Items = order.Items.Select(i => new OrderItemResponseDto
                {
                    BookId = i.BookId,
                    BookTitle = i.Book.Title,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList()
            };
        }
    }
}
