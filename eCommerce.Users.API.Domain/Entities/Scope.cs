namespace eCommerce.Users.Domain.Entities;

public class Scope
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Permission> Permissions { get; set; }
}
