using Microsoft.AspNetCore.Authorization;

namespace eCommerce.Users.Infrastructure.Authorization;

public sealed class PolicyRequirement : IAuthorizationRequirement
{
    public string Policy { get; set; }

    public PolicyRequirement(string policy) => Policy = policy;
}
