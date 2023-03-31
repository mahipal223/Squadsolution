using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net_Web_API.Data;
using Asp.Net_Web_API.Interface;
using Asp.Net_Web_API.model;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_Web_API.Services
{
    public class UserService : IUser
    {
        private readonly DataDbContext _context;
        public UserService(DataDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUser()
        {
            return await _context.users.ToListAsync();
        }

        public async Task<dynamic> SaveUser(User _user)
        {
            _context.Add(_user);
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}