using System.Security.Claims;

namespace CloudManager.Api.Helpers
{
    public static class ClaimPrincipalHelper
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                return -1;

            if (principal.Claims == null || principal.Claims.Count() == 0)
                return -1;

            var userClaim = principal.Claims.First(p => p.Type == "UserId");
            if (!int.TryParse(userClaim.Value, out int userId))
                return -1;
            
            return userId;
        }
    }
}
