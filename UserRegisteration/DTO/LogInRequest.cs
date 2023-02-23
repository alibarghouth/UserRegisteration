using System.ComponentModel.DataAnnotations;

namespace UserRegisteration.DTO
{
    public class LogInRequest
    {

        [Required][EmailAddress]
        public string EmailAddress { get; set;}

        [Required]
        public string Password { get; set; }
    }
}
