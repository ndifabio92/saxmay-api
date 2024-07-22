using Saxmay.Entities.Base;
using Saxmay.Entities.Dtos;

namespace Saxmay.Business.Interfaces
{
    public interface IAuthBusiness
    {
        Task<UserDto> Register(RegistrationDto registrationDto);
        Task<LoginResponseDto> Login(LoginDto loginDto);
        Task<bool> AssingRole(string email, string? roleName);
    }
}
