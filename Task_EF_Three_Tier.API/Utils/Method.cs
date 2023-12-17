using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Task_EF_Three_Tier.API.Models;

namespace Task_EF_Three_Tier.API.Utils
{
    public static class Method
    {
        public static TokenResponse GenerateToken(IConfiguration config)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(config["Jwt:Issuer"],
              config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            string token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return new TokenResponse(token);
        }

        public static void GenerateCookie(HttpResponse response, string? key, string? value)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value)) return;
           

            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            response.Cookies.Append(key, value, cookieOptions);

        }
    }
}
