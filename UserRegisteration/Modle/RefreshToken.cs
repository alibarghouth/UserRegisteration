namespace UserRegisteration.Modle
{
    public class RefreshToken 
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Token { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;


        public DateTime Expires { get; set; }

        public User User { get; set; }
    }
}
