📚 Book Management API
Bu proje, ASP.NET Core 9.0 kullanılarak geliştirilmiş bir kitap yönetimi ve sipariş sistemi REST API'sidir.
Proje içerisinde kitap, kategori ve sipariş yönetimi yapılabilmekte; veriler PostgreSQL veritabanında saklanmaktadır.

🚀 API Özellikleri
📘 Kitap Yönetimi (Book)
Kitap ekleme
Kitap listeleme
Kitap güncelleme
Kitap silme

🏷️ Kategori Yönetimi (Category)
Kategori ekleme
Kategori listeleme
Kategori güncelleme
Kategori silme

🛒 Sipariş Yönetimi (Order)
Sipariş oluşturma
Sipariş içerisinde birden fazla kitap belirtme
Sipariş toplam fiyatının otomatik hesaplanması
Order → OrderItem ilişki yönetimi

🛠️ Kullanılan Teknolojiler
.NET 9.0
ASP.NET Core Web API
Entity Framework Core
PostgreSQL (Npgsql provider)
Swagger / Swashbuckle
Dependency Injection
Migrations (EF Core Code First)
🗄️ Veritabanı Yapısı

Category
Alan	Açıklama
Id -	Birincil anahtar
Name -	Kategori adı

Book
Alan	Açıklama
Id -	Birincil anahtar
Title -	Kitap adı
Author -	Yazar
Stock	- Stok
Price	- Fiyat
CategoryId	- Kategori ilişkisi
CreatedAt	- Oluşturulma zamanı
UpdatedAt -	Güncellenme zamanı

Order
Alan	Açıklama
Id	- Sipariş numarası
CustomerName	- Siparişi veren kişi
TotalPrice -	Toplam fiyat
CreatedAt -	Oluşturulma tarihi

OrderItem
Alan	Açıklama
Id -	Kayıt numarası
OrderId	- Sipariş ilişkisi
BookId -	Kitap ilişkisi
Quantity -	Adet
Price -	Kitabın sipariş anındaki fiyatı

🔌 API Uç Noktaları (Endpoints)
📘 Book Endpoints
Metot	Endpoint	Açıklama
GET	/api/Book	Tüm kitapları listele
GET	/api/Book/{id}	ID’ye göre kitap getir
POST	/api/Book	Yeni kitap ekle
PUT	/api/Book/{id}	Kitap güncelle
DELETE	/api/Book/{id}	Kitap sil

🏷️ Category Endpoints
Metot	Endpoint	Açıklama
GET	/api/Category	Tüm kategorileri listele
GET	/api/Category/{id}	ID’ye göre kategori getir
POST	/api/Category	Kategori ekle
PUT	/api/Category/{id}	Kategori güncelle
DELETE	/api/Category/{id}	Kategori sil

🛒 Order Endpoints
Metot	Endpoint	Açıklama
POST	/api/Order	Yeni sipariş oluştur
GET	/api/Order (ileride)	Tüm siparişleri listele
GET	/api/Order/{id} (ileride)	Tek sipariş bilgisi

🧪 Swagger ile Test Etme
Projeyi çalıştırdıktan sonra tarayıcıda:
👉 https://localhost:7072/swagger
veya
👉 http://localhost:5000/swagger
adresine giderek API'yi test edebilirsiniz.

📦 Örnek Sipariş JSON (Order Create)
{
  "customerName": "Melek",
  "items": [
    { "bookId": 1, "quantity": 2 },
    { "bookId": 2, "quantity": 1 }
  ]
}
Bu istek sonrası sistem:
Kitapların veritabanında olup olmadığını kontrol eder
Toplam fiyatı otomatik hesaplar
Siparişi kaydeder

🧱 Proje Mimarisi
BookManagement.API
│── Controllers
│── Data
│   └── AppDbContext.cs
│── DTOs
│── Models
│── Services
│   ├── Interfaces
│   └── Implementations
│── Migrations
│── appsettings.json
│── Program.cs
👩‍💻 Geliştirici
Melek — 2025 Güz Dönemi
Book Management API Projesi

## ⚠️ Commit Geçmişi Hakkında Bilgilendirme

Proje geliştirme sürecinde commit'ler başlangıçta `main` branch üzerinde atılmıştır.
Daha sonra istenen `main` ve `dev` branch yapısına geçiş yapılırken,
`main` branch yalnızca ilk commit’e geri alınmıştır.

Bu işlem sırasında önceki geliştirme commit’leri git geçmişinden çıkmıştır
ve teknik olarak geri eklenememiştir.
Bu nedenle projede yalnızca yeniden oluşturulabilen ve mevcut kod durumunu
yansıtan commit’ler yer almaktadır.

Proje geliştirme süreci boyunca uygulama; katmanlı mimari, DTO kullanımı,
iş kuralları ve REST standartlarına uygun şekilde adım adım geliştirilmiştir.

