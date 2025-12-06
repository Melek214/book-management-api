using BookManagement.API.Data;
using Microsoft.EntityFrameworkCore;
using BookManagement.API.Services.Interfaces;
using BookManagement.API.Services.Implementations;


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
builder.Services.AddScoped<ICategoryService, CategoryService>();



var app = builder.Build();

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