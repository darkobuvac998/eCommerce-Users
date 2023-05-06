using eCommerce.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Users.Infrastructure.Configuration;

public sealed class ResourceConfiguration : IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> builder)
    {
        builder.HasData(
            new Resource
            {
                Id = 1,
                Name = "Product",
                PermissionId = 1
            }
        );
    }
}
