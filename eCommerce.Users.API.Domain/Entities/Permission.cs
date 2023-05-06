namespace eCommerce.Users.Domain.Entities;

public class Permission
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual Resource Resource { get; set; }
    public virtual ICollection<Scope> Scopes { get; set; }
    public virtual ICollection<Role> Roles { get; set; }
}
