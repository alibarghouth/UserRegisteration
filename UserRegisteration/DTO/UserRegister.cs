﻿namespace UserRegisteration.DTO
{
    public class UserRegister
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Role { get; set; } = "user";

    }
}
