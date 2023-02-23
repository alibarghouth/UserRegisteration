using AutoMapper;
using UserRegisteration.DTO;
using UserRegisteration.Modle;

namespace UserRegisteration.Helper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegister, User>()
                .ForMember(x => x.HashPassword, option => option.Ignore())
                .ForMember(x => x.PasswordSlot, option => option.Ignore());
        }
    }
}
