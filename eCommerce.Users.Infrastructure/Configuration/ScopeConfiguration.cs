using eCommerce.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Users.Infrastructure.Configuration;

public class ScopeConfiguration : IEntityTypeConfiguration<Scope>
{
    public void Configure(EntityTypeBuilder<Scope> builder)
    {
        builder.HasData(
            new Scope { Id = 1, Name = "Edit" },
            new Scope { Id = 2, Name = "Add" },
            new Scope { Id = 3, Name = "View" },
            new Scope { Id = 4, Name = "Delete" },
            new Scope { Id = 5, Name = "All" }
        );
    }
}
