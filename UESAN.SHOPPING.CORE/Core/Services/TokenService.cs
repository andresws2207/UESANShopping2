using UESAN.SHOPPING.CORE.Core.Entities;
using UESAN.SHOPPING.CORE.Core.Interfaces;

namespace UESAN.SHOPPING.CORE.Core.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(User user)
        {
            // TODO: Implement JWT token generation
            // This is a placeholder implementation
            return $"token_for_user_{user.Id}";
        }
    }
}
