using Microsoft.Extensions.Options;
using Project_dotnet.Helpers;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Project_dotnet.Models;

namespace Project_dotnet.Services
{
    public interface IUserService
    {
        Gebruiker Authenticate(Gebruiker gebruiker);
    }
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public Gebruiker Authenticate(Gebruiker gebruiker)
        {
            // return null if user not found
            if (gebruiker == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", gebruiker.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            gebruiker.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            gebruiker.PasswordHash = null;

            return gebruiker;
        }

        /*public IEnumerable<Gebruiker> GetAll()
        {
            // return users without passwords
            return _users.Select(x => {
                x.Password = null;
                return x;
            });
        }*/
    }
}
