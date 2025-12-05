using System.Collections.Generic;

namespace BookManagement.API.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }      // Kullanıcı adı
        public string PasswordHash { get; set; }  // Şifreyi düz metin değil, hash olarak tutacağız
        public string Role { get; set; }          // "Admin" / "User" vb.

        // İlişkiler
        public ICollection<Order> Orders { get; set; }  // Kullanıcının verdiği siparişler
    }
}