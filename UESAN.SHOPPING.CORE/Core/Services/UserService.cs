using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.Core.DTOs;
using UESAN.SHOPPING.CORE.Core.Entities;
using UESAN.SHOPPING.CORE.Core.Interfaces;

namespace UESAN.SHOPPING.CORE.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }


        public async Task<UserDTO> SignIn(string email, string password)
        {
            var user = await _userRepository.SignIn(email, password);
            if (user == null)
            {
                return null;
            }
            var userDTO = new UserDTO
            {
                Id = user.Id.ToString(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = _tokenService.GenerateToken(user)
            };
            return userDTO;
        }
        public async Task<int> SignUp(UserCreateDTO userCreateDTO)
        {
            var user = new User
            {
                FirstName = userCreateDTO.FirstName,
                LastName = userCreateDTO.LastName,
                DateOfBirth = userCreateDTO.DateOfBirth,
                Email = userCreateDTO.Email,
                Password = userCreateDTO.Password,
                Country = userCreateDTO.Country,
                Address = userCreateDTO.Address,
                Type = userCreateDTO.Type,
                IsActive = true
            };
            return await _userRepository.SignUp(user);
        }
    }
}