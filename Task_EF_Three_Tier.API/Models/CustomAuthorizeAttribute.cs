using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Task_EF_Three_Tier.API.Models
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {

        public CustomAuthorizeAttribute(string role)  { Roles = role;  }
     
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context is not null) {
                if (context.HttpContext.Request.Cookies["Role"] != Roles)
                {
                    throw new UnauthorizedAccessException("Persmission denied");
                }
            }
        }
    }
}
