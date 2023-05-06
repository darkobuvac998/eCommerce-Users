namespace eCommerce.Users.Domain.Entities;

public class Resource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PermissionId { get; set; }
    public virtual Permission Permission { get; set; }
}
