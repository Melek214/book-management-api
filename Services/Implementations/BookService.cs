using BookManagement.API.Data;
using BookManagement.API.DTOs;
using BookManagement.API.Models;
using BookManagement.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.API.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BookResponseDto>> GetAllBooksAsync()
        {
            var books = await _context.Books
                .Include(b => b.Category)
                .ToListAsync();

            return books.Select(b => new BookResponseDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Stock = b.Stock,
                Price = b.Price,
                CategoryId = b.CategoryId,
                CategoryName = b.Category.Name,
                CreatedAt = b.CreatedAt,
                UpdatedAt = b.UpdatedAt
            }).ToList();
        }

        public async Task<BookResponseDto> GetBookByIdAsync(int id)
        {
            var book = await _context.Books
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null) return null;

            return new BookResponseDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Stock = book.Stock,
                Price = book.Price,
                CategoryId = book.CategoryId,
                CategoryName = book.Category.Name,
                CreatedAt = book.CreatedAt,
                UpdatedAt = book.UpdatedAt
            };
        }

        public async Task<BookResponseDto> CreateBookAsync(BookCreateDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Stock = dto.Stock,
                Price = dto.Price,
                CategoryId = dto.CategoryId
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return await GetBookByIdAsync(book.Id);
        }

        public async Task<BookResponseDto> UpdateBookAsync(int id, BookUpdateDto dto)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return null;

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.Stock = dto.Stock;
            book.Price = dto.Price;
            book.CategoryId = dto.CategoryId;
            book.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return await GetBookByIdAsync(book.Id);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
