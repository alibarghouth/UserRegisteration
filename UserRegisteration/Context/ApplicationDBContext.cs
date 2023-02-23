using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using UserRegisteration.Modle;

namespace UserRegisteration.Context
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }


        public DbSet<User> Users { get; set; }

        
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        
    }
}
