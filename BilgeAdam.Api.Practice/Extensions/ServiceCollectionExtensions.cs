using BilgeAdam.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BilgeAdam.Api.Practice.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddJwt(this IServiceCollection services, Settings settings)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.Key)),
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }
    }
}
