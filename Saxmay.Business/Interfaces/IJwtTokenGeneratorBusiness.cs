using Saxmay.Entities;

namespace Saxmay.Business.Interfaces
{
    public interface IJwtTokenGeneratorBusiness
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
