using FluentValidation;
using UserRegisteration.DTO;
using UserRegisteration.Modle;

namespace E_Commerce_System.Validation
{
    public class CustomerValidation : AbstractValidator<UserRegister>
    {
        public CustomerValidation()
        {
            RuleFor(x => x.Name).NotEmpty()
                 .WithMessage("Please write name");
            RuleFor(x => x.Email).EmailAddress()
                .NotEmpty();

            RuleFor(x => x.Role).NotEmpty();

            RuleFor(x => x.Password).NotEmpty()
                .Matches("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$");
        }
    }
}
