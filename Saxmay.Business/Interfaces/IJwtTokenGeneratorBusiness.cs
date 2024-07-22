using Saxmay.Entities;
using Saxmay.Entities.Base;

namespace Saxmay.Business.Interfaces
{
    public interface IJwtTokenGeneratorBusiness
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
