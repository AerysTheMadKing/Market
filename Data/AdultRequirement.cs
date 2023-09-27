using Microsoft.AspNetCore.Authorization;
namespace Market.Data
{
    public class AdultRequirement : IAuthorizationRequirement
    {
        public static string ClaimName => "Age";
    }
}
