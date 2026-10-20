using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TrialA_API.Models;

namespace TrialA_API.Helpers
{
    public class TokenHelper : ITokenHelper
    {
        private readonly IConfiguration _config;

        public TokenHelper(IConfiguration configuration)
        {
            _config = configuration;
        }
        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.FullName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.NameIdentifier,Convert.ToString(user.Id)),
                new Claim(ClaimTypes.Role,user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["JWT:SecretKey"]));

            var signingCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var tokenOBJ = new JwtSecurityToken(
                  issuer: _config["JWT:Issuer"],
                  audience: _config["JWT:Audience"],
                  claims: claims,
                  signingCredentials: signingCredentials,
                  expires: DateTime.Now.AddHours(Convert.ToDouble(_config["JWT:ExpirationInHours"]))
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOBJ);
        }
    }
}
