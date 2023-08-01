using System.Security.Claims;

namespace Vaevi.Web.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetUserId(this ClaimsPrincipal claims)
        {
            return claims.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
