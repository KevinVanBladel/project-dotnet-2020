using System;
using System.Linq;
using System.Security.Claims;

namespace Project_dotnet.Extensions
{
    public static class UserExtensions
    {
        public static string GetUserId(this ClaimsPrincipal claims)
        {
            var claim = claims.Claims.FirstOrDefault(c => c.Type == "UserId");

            if (claim != null)
                return claim.Value;

            return "";
        }
    }
}
