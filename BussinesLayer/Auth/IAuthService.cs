using DataLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Auth
{
    public interface IAuthService
    {
        Task<bool> Create(User model);
        Task<bool> Login(User model);
        Task<User> GetUser(Guid id);
        object BuildToken(User user);
    }
}
