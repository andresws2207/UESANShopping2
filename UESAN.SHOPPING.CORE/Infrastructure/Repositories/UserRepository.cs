using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.Core.Entities;
using UESAN.SHOPPING.CORE.Core.Interfaces;
using UESAN.SHOPPING.CORE.Infrastructure.Data;

namespace UESAN.SHOPPING.CORE.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _context;

        public UserRepository(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<User> SignIn(string email, string password)
        {
            return await _context.User.Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
        }
        public async Task<int> SignUp(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }
    }
}
