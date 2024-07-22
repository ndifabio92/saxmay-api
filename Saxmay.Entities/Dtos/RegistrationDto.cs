using Saxmay.Entities.Base;

namespace Saxmay.Entities.Dtos
{
    public class RegistrationDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}
