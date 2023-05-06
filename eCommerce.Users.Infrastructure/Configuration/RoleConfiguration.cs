using eCommerce.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Users.Infrastructure.Configuration;

public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
            new Role { Id = 1, Name = "Admin", },
            new Role { Id = 2, Name = "Techincal", },
            new Role { Id = 3, Name = "CustomerBasic", },
            new Role { Id = 4, Name = "CustomerGold", },
            new Role { Id = 5, Name = "CustomerPremium", }
        );
    }
}
