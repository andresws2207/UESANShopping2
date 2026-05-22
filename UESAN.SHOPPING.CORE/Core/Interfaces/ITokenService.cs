using UESAN.SHOPPING.CORE.Core.Entities;

namespace UESAN.SHOPPING.CORE.Core.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
