using BookManagement.API.Data;
using BookManagement.API.Services.Interfaces;
using BookManagement.API.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using BookManagement.API.Models;
using BookManagement.API.DTOs;
using BookManagement.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// LOGGING
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// DATABASE
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// CONTROLLERS
builder.Services.AddControllers()
    .AddNewtonsoftJson();

// SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DEPENDENCY INJECTION (SERVICES)
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

// GLOBAL EXCEPTION HANDLING (EN ÜSTTE OLMALI)
app.UseMiddleware<GlobalExceptionMiddleware>();

// SWAGGER (DEV)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


// =======================
// MINIMAL API ENDPOINTS
// =======================

app.MapGet("/minimal/books", async (IBookService bookService) =>
{
    var books = await bookService.GetAllBooksAsync();

    return Results.Ok(
        ApiResponse<List<BookResponseDto>>.Ok(books, "Kitaplar listelendi")
    );
});

app.MapPost("/minimal/books", async (BookCreateDto dto, IBookService bookService) =>
{
    var createdBook = await bookService.CreateBookAsync(dto);

    return Results.Created(
        $"/minimal/books/{createdBook.Id}",
        ApiResponse<BookResponseDto>.Ok(createdBook, "Kitap oluşturuldu")
    );
});

app.Run();