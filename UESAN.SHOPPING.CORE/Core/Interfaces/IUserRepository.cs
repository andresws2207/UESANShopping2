using UESAN.SHOPPING.CORE.Core.Entities;

namespace UESAN.SHOPPING.CORE.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> SignIn(string email, string password);
        Task<int> SignUp(User user);
    }
}
