using Microsoft.AspNetCore.Authorization;

namespace Market.Data
{
    public class OverAgeRequirement : IAuthorizationRequirement
    {
        public static string ClaimName => "Age";
    }
}
