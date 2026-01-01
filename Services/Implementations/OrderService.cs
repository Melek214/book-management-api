using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // 1) SIPARIS OLUSTUR
        public async Task<OrderResponseDto> CreateOrderAsync(OrderCreateDto dto)
        {
            // Transaction başlat
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
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

                    if (book.Stock < item.Quantity)
                        throw new Exception($"'{book.Title}' için yeterli stok yok.");

                    // Stok düşürme
                    book.Stock -= item.Quantity;
                    _context.Books.Update(book);

                    var orderItem = new OrderItem
                    {
                        BookId = item.BookId,
                        Book = book,
                        Quantity = item.Quantity,
                        Price = book.Price * item.Quantity
                    };

                    totalPrice += orderItem.Price;
                    order.Items.Add(orderItem);
                }

                order.TotalPrice = totalPrice;

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                // Commit başarılıysa
                await transaction.CommitAsync();

                var createdOrder = await _context.Orders
                    .Include(o => o.Items)
                    .ThenInclude(i => i.Book)
                    .FirstAsync(o => o.Id == order.Id);

                return new OrderResponseDto
                {
                    Id = createdOrder.Id,
                    CustomerName = createdOrder.CustomerName,
                    TotalPrice = createdOrder.TotalPrice,
                    CreatedAt = createdOrder.CreatedAt,
                    Items = createdOrder.Items.Select(i => new OrderItemResponseDto
                    {
                        BookId = i.BookId,
                        BookTitle = i.Book.Title,
                        Quantity = i.Quantity,
                        Price = i.Price
                    }).ToList()
                };
            }
            catch
            {
                // Hata olursa rollback
                await transaction.RollbackAsync();
                throw;
            }
        }

        // 2) TUM SIPARISLERI LISTELE
        public async Task<List<OrderResponseDto>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Book)
                .ToListAsync();

            return orders.Select(o => new OrderResponseDto
            {
                Id = o.Id,
                CustomerName = o.CustomerName,
                TotalPrice = o.TotalPrice,
                CreatedAt = o.CreatedAt,
                Items = o.Items.Select(i => new OrderItemResponseDto
                {
                    BookId = i.BookId,
                    BookTitle = i.Book.Title,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList()
            }).ToList();
        }

        // 3) ID ILE SIPARIS DETAYI GETIR
        public async Task<OrderResponseDto?> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Book)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
                return null;

            return new OrderResponseDto
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                TotalPrice = order.TotalPrice,
                CreatedAt = order.CreatedAt,
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
