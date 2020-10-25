using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;

namespace estudo_aspnetcore_identity.Extensions
{
    public static class RazorExtensions
    {
        public static bool IfClaim(this RazorPage page, string claimName, string claimValue)
        {
            return CustomerAuthorization
                    .ValidarClaimsUsuario(page.Context, claimName, claimValue);
        }

        public static string IfClaimShow(this RazorPage page, string claimName, string claimValue)
        {
            return CustomerAuthorization.ValidarClaimsUsuario(page.Context, claimName, claimValue) ? "" : "disabled";
        }

        public static IHtmlContent IfClaimShow(this IHtmlContent page,
                                                  HttpContext context,
                                                  string claimName,
                                                  string claimValue)
        {
            return CustomerAuthorization.ValidarClaimsUsuario(context, claimName, claimValue) ? page : null;
        }
    }
}
