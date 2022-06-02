using BilgeAdam.Common;
using BilgeAdam.Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BilgeAdam.Api.Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtSetting jwtSettings;
        public AuthenticationController(IOptions<Settings> options)
        {
            jwtSettings = options.Value.Jwt;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto data)
        {
            if (data.Mail != "can@mail.com" || data.Password != "111")
            {
                return Unauthorized();
            }
            var claims = new Dictionary<string, object>();
            claims.Add("UserId", 1);
            claims.Add("Culture", "tr-TR");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.Now.AddMinutes(jwtSettings.Expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                                                            SecurityAlgorithms.HmacSha256Signature),
                Claims = claims,
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now
            };

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);
            var jwtToken = handler.WriteToken(token);
            return Ok(jwtToken);
        }
    }
}
