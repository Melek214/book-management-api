using BookManagement.API.DTOs;

namespace BookManagement.API.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookResponseDto>> GetAllBooksAsync();
        Task<BookResponseDto> GetBookByIdAsync(int id);
        Task<BookResponseDto> CreateBookAsync(BookCreateDto dto);
        Task<BookResponseDto> UpdateBookAsync(int id, BookUpdateDto dto);
        Task<bool> DeleteBookAsync(int id);
    }
}