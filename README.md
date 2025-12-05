📘 Book Management API
Bu proje, ASP.NET Core 9.0 kullanılarak geliştirilmiş basit bir kitap yönetimi REST API uygulamasıdır.
Veritabanı olarak PostgreSQL ve ORM aracı olarak Entity Framework Core kullanılmıştır.

🚀 Özellikler
📚 Kitap ekleme
📄 Kitap listeleme
✏️ Kitap güncelleme
❌ Kitap silme
🗂 Kategori yapısı
🧱 DTO kullanımı
🏗 Katmanlı mimari
🗃 PostgreSQL + EF Core Code-First
📄 Swagger API dokümantasyonu (yakında eklenecek)

🛠 Kullanılan Teknolojiler
.NET 9.0
ASP.NET Core Web API
Entity Framework Core 9
PostgreSQL
Swagger / Swashbuckle
JetBrains Rider
Git & GitHub

🏗 Proje Mimarisi
BookManagement.API
│
├── Controllers
│     └── BookController.cs
│
├── Services
│     ├── Interfaces
│     │      └── IBookService.cs
│     └── Implementations
│            └── BookService.cs
│
├── Models
│     ├── BaseEntity.cs
│     ├── Book.cs
│     ├── Category.cs
│     ├── Order.cs
│     └── OrderItem.cs
│
├── DTOs
│     ├── BookCreateDto.cs
│     ├── BookResponseDto.cs
│     └── BookUpdateDto.cs
│
├── Data
│     └── AppDbContext.cs
│
├── Migrations
│
└── Program.cs

🗄 Veritabanı Ayarları
appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5433;Database=BookDb;Username=postgres;Password=your_password"
}

Migration Komutları
dotnet ef migrations add InitialCreate
dotnet ef database update

▶ API Örnekleri
📍 Tüm Kitapları Listele – GET
GET /api/book
[
  {
    "id": 1,
    "title": "Example Book",
    "author": "John Doe",
    "stock": 10,
    "price": 120,
    "categoryName": "Roman"
  }
]


📍 Kitap Ekle – POST
POST /api/book
{
  "title": "Yeni Kitap",
  "author": "Melek",
  "stock": 5,
  "price": 99,
  "categoryId": 1
}


