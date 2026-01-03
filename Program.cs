using BookManagement.API.Data;
using BookManagement.API.Services.Interfaces;
using BookManagement.API.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using BookManagement.API.Models;
using BookManagement.API.DTOs;
using BookManagement.API.Middlewares;



var builder = WebApplication.CreateBuilder(args);

// PostgreSQL bağlantı dizesi (appsettings.json’dan alınacak)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controller’ları aktif et
builder.Services.AddControllers()
    .AddNewtonsoftJson(); // JSON formatlama için

// Swagger (API test arayüzü)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookService, BookService>();


// Service kayıtları (DI)
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();


var app = builder.Build();
//  GLOBAL EXCEPTION HANDLING 
app.UseMiddleware<BookManagement.API.Middlewares.GlobalExceptionMiddleware>();
// Geliştirme ortamında Swagger aç
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

