using IdentityServer3.Core.Models;
using JobSearchingWebApp.Data;
using JobSearchingWebApp.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobSearchingWebApp.Helper.Services
{
    public class JWTService
    {
        private readonly IConfiguration config;
        private readonly IServiceProvider serviceProvider;


        public JWTService(IConfiguration config, IServiceProvider serviceProvider)
        {
            this.config = config;
            this.serviceProvider = serviceProvider; 
        }

        public async Task<string> CreateJWT(Korisnik user)
        {
            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
            };

            using (var scope = serviceProvider.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Korisnik>>();
                var roles = await userManager.GetRolesAsync(user);
                userClaims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            }

            var key = Encoding.ASCII.GetBytes(config["JwtSettings:Key"]);

            var creadentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaims),
                Expires = DateTime.UtcNow.AddDays(int.Parse(config["JwtSettings:ExpiresInDays"])),
                SigningCredentials = creadentials,
                Issuer = config["JwtSettings:Issuer"],
                Audience = config["JwtSettings:Audience"],
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(jwt);
        }
    }
}
