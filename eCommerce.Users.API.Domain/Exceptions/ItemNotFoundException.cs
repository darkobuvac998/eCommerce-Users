namespace eCommerce.Users.Domain.Exceptions;

public sealed class ItemNotFoundException : BaseException
{
    private static readonly string Code = "ITEM_NOT_FOUND";

    public ItemNotFoundException(Type type, object identifier)
        : base(Code, $"Entity of type {type.Name} with identifier {identifier} not found!") { }

    public ItemNotFoundException(Type type, object identifier, Exception innner)
        : base(Code, $"Entity of type {type.Name} with identifier {identifier} not found!", innner)
    { }
}
