using eCommerce.Users.Domain.Contracts;
using eCommerce.Users.Domain.Entities;
using eCommerce.Users.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Users.Infrastructure.Contexts;

public sealed class UsersDbContext : DbContext, IUsersDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Scope> Scopes { get; set; }

    public UsersDbContext(DbContextOptions<UsersDbContext> options)
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSnakeCaseNamingConvention();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (
            var entry in ChangeTracker
                .Entries<User>()
                .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added)
        )
        {
            entry.Entity.UpdatedAt = DateTime.UtcNow;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Username).IsUnique();

            entity
                .HasMany(e => e.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<UserRoles>(
                    l => l.HasOne<Role>().WithMany().HasForeignKey(e => e.RoleId),
                    r => r.HasOne<User>().WithMany().HasForeignKey(e => e.UserId)
                );
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity
                .HasMany(e => e.Permissions)
                .WithMany(e => e.Roles)
                .UsingEntity<RolePermission>(
                    l => l.HasOne<Permission>().WithMany().HasForeignKey(e => e.PermissionId),
                    r => r.HasOne<Role>().WithMany().HasForeignKey(e => e.RoleId)
                );
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity
                .HasMany(e => e.Scopes)
                .WithMany(s => s.Permissions)
                .UsingEntity<PermissionScope>(
                    l => l.HasOne<Scope>().WithMany().HasForeignKey(e => e.ScopeId),
                    r => r.HasOne<Permission>().WithMany().HasForeignKey(e => e.PermissionId)
                );

            entity
                .HasOne(e => e.Resource)
                .WithOne(r => r.Permission)
                .HasForeignKey<Resource>(r => r.PermissionId)
                .IsRequired();

            entity.Navigation(p => p.Resource).AutoInclude();
        });

        modelBuilder.Entity<Scope>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.ApplyAllConfiguration();
    }
}
