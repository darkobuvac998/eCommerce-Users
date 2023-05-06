using eCommerce.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Users.Infrastructure.Configuration;

public sealed class PermissionScopeConfiguration : IEntityTypeConfiguration<PermissionScope>
{
    public void Configure(EntityTypeBuilder<PermissionScope> builder)
    {
        builder.HasData(
            new PermissionScope { ScopeId = 1, PermissionId = 1 },
            new PermissionScope { ScopeId = 2, PermissionId = 1 },
            new PermissionScope { ScopeId = 3, PermissionId = 1 },
            new PermissionScope { ScopeId = 4, PermissionId = 1 }
        );
    }
}
