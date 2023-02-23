using UserRegisteration.DTO;
using UserRegisteration.Modle;
using UserRegisteration.Response;

namespace UserRegisteration.Service
{
    public interface IUserService
    {
        Task<AuthModel> registerUser(UserRegister userRegister);

        Task<User?> LogInUser(LogInRequest logInRequest);

        Task<List<User>> GetUser();

        User updateUser(User user);

        Task<User> GetUserById(int id);
    }
}
