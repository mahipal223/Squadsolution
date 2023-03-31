using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net_Web_API.model;

namespace Asp.Net_Web_API.Interface
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetUser();

        Task<dynamic> SaveUser(User addUser);
    }
}