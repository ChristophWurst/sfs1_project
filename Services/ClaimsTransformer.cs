using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.Linq;

public class ClaimsTransformer : IClaimsTransformer
{
    public Task<ClaimsPrincipal> TransformAsync(ClaimsTransformationContext context)
    {
        var prince = context.Principal;
        if (prince.Claims.Any(c =>
        {
            return c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
                     && c.Value.EndsWith("@winzerhof-wurst.at");
        }))
        {
            ((ClaimsIdentity)context.Principal.Identity).AddClaim(new Claim("Yolo", "true"));
        }

        return Task.FromResult(context.Principal);
    }

}