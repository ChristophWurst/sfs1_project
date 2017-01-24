using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

public class ClaimsTransformer : IClaimsTransformer
{
    public Task<ClaimsPrincipal> TransformAsync(ClaimsTransformationContext context)
    {
        ((ClaimsIdentity)context.Principal.Identity).AddClaim(new Claim("Yolo", "true"));
        return Task.FromResult(context.Principal);
    }

}