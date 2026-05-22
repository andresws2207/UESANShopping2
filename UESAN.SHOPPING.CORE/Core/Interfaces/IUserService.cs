using UESAN.SHOPPING.CORE.Core.DTOs;

namespace UESAN.SHOPPING.CORE.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> SignIn(string email, string password);
        Task<int> SignUp(UserCreateDTO userCreateDTO);
    }
}
