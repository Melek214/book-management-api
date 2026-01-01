using BookManagement.API.DTOs;
using BookManagement.API.Models;
using BookManagement.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await _bookService.GetAllBooksAsync();
            return Ok(ApiResponse<List<BookResponseDto>>.Ok(result, "Books listed successfully"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var result = await _bookService.GetBookByIdAsync(id);
            if (result == null)
                return NotFound(ApiResponse<string>.Fail("Book not found"));

            return Ok(ApiResponse<BookResponseDto>.Ok(result, "Book retrieved successfully"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdBook = await _bookService.CreateBookAsync(dto);
            return Ok(ApiResponse<BookResponseDto>.Ok(createdBook, "Book created successfully"));
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var updatedBook = await _bookService.UpdateBookAsync(id, dto);
            if (updatedBook == null)
                return NotFound(ApiResponse<string>.Fail("Book not found"));

            return Ok(ApiResponse<BookResponseDto>.Ok(updatedBook, "Book updated successfully"));
            
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);
            if (!result)
                return NotFound(ApiResponse<string>.Fail("Book not found"));

            return Ok(ApiResponse<string>.Ok("Book deleted successfully"));
        }

    }
}
