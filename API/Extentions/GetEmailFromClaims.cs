using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace API.Extentions
{
    public static class GetEmailFromClaims
    {
        public static string RetriveEmail(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
        }
    }
}
