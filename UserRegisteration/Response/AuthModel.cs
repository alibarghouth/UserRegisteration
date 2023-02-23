namespace UserRegisteration.Response
{
    public class AuthModel
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public byte[]? HashPassword { get; set; }

        public byte[]? PasswordSlot { get; set; }

        public DateTime? TokenCreated { get; set; }

        public DateTime? TokenExpires { get; set; }

        public string Role { get; set; }


        public bool? IsActive { get; set; }

        public bool? IsAuth { get; set; }
    }
}
