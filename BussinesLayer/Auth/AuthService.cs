using DataLayer.Models.Users;
using DataLayer.Options;
using DataLayer.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Auth
{
    public class AuthService : IAuthService
    {
        public readonly ApplicationDbContext _dbContext;
        public readonly JwtOption _options;
        public AuthService(ApplicationDbContext dbContext, IOptions<JwtOption> options)
        {
            _dbContext = dbContext;
            _options = options.Value;
        }

        public async Task<bool> Create(User model)
        {
            _dbContext.Add(model);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Login(User model)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == model.UserName && x.Password == model.Password);
            return result != null;
        }

        public async Task<User> GetUser(Guid id) => await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);


        public object BuildToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: _options.ValidIssuer,
               audience: _options.ValidAudience,
               claims: claims,
               signingCredentials: creds);
            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return new
            {
                user.UserName,
                token = tokenStr,
                startLife = DateTime.Now
            };
        }
    }
}
