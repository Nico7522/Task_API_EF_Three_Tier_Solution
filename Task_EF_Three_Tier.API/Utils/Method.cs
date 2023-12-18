using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Task_API_EF_Three_Tier.DAL.Entities;
using Task_EF_Three_Tier.API.Models;
using Task_EF_Three_Tier.API.Models.DTO;

namespace Task_EF_Three_Tier.API.Utils
{
    public static class Method
    {
        public static TokenResponse GenerateToken(IConfiguration config, PersonDTO? person)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(config["Jwt:Issuer"],
              config["Jwt:Issuer"],
              claims: (person is null) ? null : new List<Claim>() { new Claim("name", person.LastName), new Claim(ClaimTypes.Role, person.Role)},
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
