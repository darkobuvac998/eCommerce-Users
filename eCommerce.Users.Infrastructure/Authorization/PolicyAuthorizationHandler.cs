using eCommerce.Users.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace eCommerce.Users.Infrastructure.Authorization;

public class PolicyAuthorizationHandler : AuthorizationHandler<PolicyRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PolicyRequirement requirement
    )
    {
        string? userId = context.User.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
            ?.Value;

        if (!int.TryParse(userId, out int _))
        {
            return Task.CompletedTask;
        }

        HashSet<string> permissions = context.User.Claims
            .Where(x => x.Type == CustomClaims.Permissions)
            .Select(x => x.Value)
            .ToHashSet();

        if (permissions.Contains(requirement.Policy))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
