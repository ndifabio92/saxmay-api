using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Saxmay.Business.Interfaces;
using Saxmay.Data;
using Saxmay.Entities;
using Saxmay.Entities.Base;
using Saxmay.Entities.Dtos;

namespace Saxmay.Business
{
    public class AuthBusiness : IAuthBusiness
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGeneratorBusiness _jwtTokenGenerator;

        public AuthBusiness(DataContext dataContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGeneratorBusiness jwtTokenGenerator)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;

        }

        public async Task<bool> AssingRole(string email, UserRole? roleName)
        {
            var user = await _dataContext.ApplicationUsers.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
            if(user != null && roleName != null)
            {
                if(!_roleManager.RoleExistsAsync(roleName.ToString()).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(roleName.ToString())).GetAwaiter().GetResult();
                }
                await _userManager.AddToRoleAsync(user, roleName.ToString());
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginDto loginDto)
        {
            var user = await _dataContext.ApplicationUsers.FirstOrDefaultAsync(x => x.UserName.ToLower() == loginDto.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if(user == null && !isValid)
            {
                return new LoginResponseDto();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user,roles);
            return new LoginResponseDto()
            {
                User = new UserDto()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    PhoneNumber = user.PhoneNumber
                },
                Token = token
            };
        }

        public async Task<UserDto> Register(RegistrationDto registrationDto)
        {
            var user = new ApplicationUser()
            {
                UserName = registrationDto.Email,
                Email = registrationDto.Email,
                NormalizedEmail = registrationDto.Email.ToUpper(),
                Name = registrationDto.Name,
                PhoneNumber = registrationDto.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, registrationDto.Password);

            if (result.Succeeded)
            {
                var userToReturn = await _dataContext.ApplicationUsers.FirstOrDefaultAsync(x => x.UserName == registrationDto.Email);
                if (userToReturn != null)
                {
                    return new UserDto()
                    {
                        Id = userToReturn.Id,
                        Email = userToReturn.Email,
                        Name = userToReturn.Name,
                        PhoneNumber = userToReturn.PhoneNumber
                    };
                }
            }

            return new UserDto()
            {
                Errors = result.Errors
            };
        }
    }
}
