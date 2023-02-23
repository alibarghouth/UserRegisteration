using FluentValidation;
using UserRegisteration.DTO;

namespace UserRegisteration.Validation
{
    public class ValidationLogin : AbstractValidator<LogInRequest>
    {

        public ValidationLogin()
        {
            RuleFor(x => x.EmailAddress)
                .EmailAddress()
                .NotEmpty()
                .WithMessage("email is not valid");

            RuleFor(x => x.Password)
                .NotEmpty()
                .Matches("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$")
                .WithMessage("password must Contains at least 8 characters\r\nContains at least one uppercase letter\r\nContains at least one lowercase letter\r\nContains at least one digit\r\nContains at least one special character (e.g. !, @, #, $, %, ^, &, *)");
        }
    }
}
