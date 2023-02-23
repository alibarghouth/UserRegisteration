using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using UserRegisteration.Context;
using UserRegisteration.DTO;
using UserRegisteration.HashPassword;
using UserRegisteration.Modle;
using UserRegisteration.Response;

namespace UserRegisteration.Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationDBContext _context;

        private readonly IMapper _map;

        private readonly IHashPass _hash;

        public UserService(ApplicationDBContext context, IMapper map, IHashPass hash, IConfiguration configuration)
        {
            _context = context;
            _map = map;
            _hash = hash;
        }

        public async Task<AuthModel> registerUser(UserRegister userRegister)
        {
            var checkUser = _context.Users.Any(x => x.Name == userRegister.Name ||userRegister.Email == x.Email);

            if (userRegister == null || checkUser is true)
            {
                return new AuthModel { IsAuth = false };
            }

            _hash.createHashPassword(userRegister.Password, out byte[] passwordhash, out byte[] passwordslot);

            var map = _map.Map<User>(userRegister);

            map.HashPassword = passwordhash;

            map.PasswordSlot = passwordslot;

            await _context.Users.AddAsync(map);

            _context.SaveChanges();

            return new AuthModel
            {
                Role = map.Role,
                IsAuth = true,
                Email = map.Email,
                HashPassword = passwordhash,
                PasswordSlot = passwordslot,
                Id = map.Id,
                IsActive = true,
                Name = map.Name,
                TokenCreated = map.TokenCreated,
                TokenExpires = map.TokenExpires
            };
        }

        public async Task<User?> LogInUser(LogInRequest logInRequest)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == logInRequest.EmailAddress);
            if (user is null)
            {
                return null;
            }
            var isVarify = _hash.verifyPassword(logInRequest.Password, user.HashPassword, user.PasswordSlot);

            if (!isVarify)
            {
                return null;
            }

            return user;
        }

        public User updateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
            return user;
        }

        public async Task<List<User>> GetUser()
        {
            var user = await _context.Users.ToListAsync();
           
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            return user;
        }
    }
}
