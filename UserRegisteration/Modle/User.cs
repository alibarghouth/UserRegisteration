using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace UserRegisteration.Modle
{
    public class User 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public byte[] HashPassword { get; set; }

        public byte[] PasswordSlot { get; set; }

        public DateTime TokenCreated { get; set; }

        public DateTime TokenExpires { get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; } = true;

        public RefreshToken RefreshToken { get; set; }


    }
}
