using examen_final_csharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;

namespace examen_final_csharp.Services
{
    public class AuthService
    {
        private readonly GimnasioDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(GimnasioDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<string?> Login(string email, string password)
        {
            var user = await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null || !user.IsActive)
                return null;

            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            var claims = new List<Claim>
            {
                new Claim("id", user.UserId.ToString()),
                new Claim("email", user.Email)
            };

            foreach (var ur in user.UserRoles)
            {
                claims.Add(new Claim("role", ur.Role.Name));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            user.LastLoginAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
