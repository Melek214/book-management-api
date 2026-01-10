# 📚 Book Management API

Bu proje, **ASP.NET Core 9.0** kullanılarak geliştirilmiş bir **Kitap Yönetimi ve Sipariş Sistemi** REST API uygulamasıdır.  
Proje, **Layered Architecture** ve **Minimal API** yaklaşımlarını birlikte kullanır.

Veriler **PostgreSQL** veritabanında tutulur ve **Entity Framework Core (Code First)** yaklaşımı kullanılmıştır.

---

## 🚀 Proje Özellikleri

### 📘 Book (Kitap) Yönetimi
- Kitap ekleme
- Kitap listeleme
- Kitap güncelleme
- Kitap silme (**Soft Delete**)
- Stok takibi
- Sipariş sonrası stoktan otomatik düşme

### 🏷️ Category (Kategori) Yönetimi
- Kategori ekleme
- Kategori listeleme
- Kategori güncelleme
- Kategori silme (**Soft Delete**)

### 🛒 Order (Sipariş) Yönetimi
- Sipariş oluşturma
- Bir siparişte birden fazla kitap
- Toplam fiyatın otomatik hesaplanması
- Order → OrderItem ilişki yönetimi

---

## 🧱 Mimari Yapı
BookManagement.API
│── Controllers
│── Data
│ └── AppDbContext.cs
│── DTOs
│── Models
│── Services
│ ├── Interfaces
│ └── Implementations
│── Migrations
│── appsettings.json
│── Program.cs


---

## 🛠️ Kullanılan Teknolojiler
- .NET 9.0
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL (Npgsql)
- Swagger / Swashbuckle
- Dependency Injection
- Logging (Microsoft.Extensions.Logging)
- EF Core Migrations (Code First)

---

## 🔌 API Endpoints

### 📘 Book
| Method | Endpoint | Açıklama |
|---|---|---|
| GET | /api/Book | Tüm kitapları getir |
| GET | /api/Book/{id} | Id’ye göre kitap |
| POST | /api/Book | Kitap ekle |
| PUT | /api/Book/{id} | Kitap güncelle |
| DELETE | /api/Book/{id} | Kitap sil (Soft Delete) |

### 🏷️ Category
| Method | Endpoint | Açıklama |
|---|---|---|
| GET | /api/Category | Tüm kategoriler |
| GET | /api/Category/{id} | Id’ye göre kategori |
| POST | /api/Category | Kategori ekle |
| PUT | /api/Category/{id} | Kategori güncelle |
| DELETE | /api/Category/{id} | Kategori sil |

### 🛒 Order
| Method | Endpoint | Açıklama |
|---|---|---|
| POST | /api/Order | Sipariş oluştur |

---

## 📦 Örnek API Response

### Kitap Ekleme (POST /api/Book)
``json
{
  "success": true,
  "message": "Book created successfully",
  "data": {
    "id": 1,
    "title": "Suç ve Ceza",
    "author": "Dostoyevski",
    "stock": 96,
    "price": 120,
    "categoryName": "Roman"
  }
}

🧪 Swagger ile Test
Uygulama çalıştırıldıktan sonra:
https://localhost:7072/swagger

⚙️ Kurulum
git clone https://github.com/Melek214/book-management-api.git
cd book-management-api
dotnet restore
dotnet ef database update
dotnet run

📝 Notlar
Proje geliştirme sürecinde PostgreSQL bağlantı ve migration düzenlemeleri yapılmıştır.
İlk commit sürecinde yaşanan bağlantı problemleri daha sonra düzeltilmiştir.


👩‍💻 Geliştirici
Melek — 2025 Güz Dönemi
Book Management API Projesi

## ⚠️ Commit Geçmişi Hakkında Bilgilendirme

Proje geliştirme sürecinde commit’ler başlangıçta `main` branch üzerinde
oluşturulmuştur. Daha sonra istenen `main` ve `dev` branch yapısına geçiş
yapılırken, `main` branch yalnızca ilk commit’e geri alınmıştır.

Bu süreçte, önceki geliştirme commit’leri git geçmişinden çıkmış ve
teknik olarak geri eklenememiştir. Bu nedenle projede yalnızca
yeniden oluşturulabilen ve mevcut kod durumunu yansıtan commit’ler yer almaktadır.

Proje geliştirme süreci boyunca uygulama; katmanlı mimari,
DTO kullanımı, iş kuralları ve REST standartlarına uygun şekilde
adım adım geliştirilmiştir.

