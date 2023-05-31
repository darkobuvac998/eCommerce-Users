using Microsoft.AspNetCore.Authorization;

namespace eCommerce.Users.Infrastructure.Authorization;

public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(string permission)
        : base(policy: permission) { }
}
