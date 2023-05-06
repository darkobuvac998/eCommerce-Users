namespace eCommerce.Users.Domain.Exceptions;

public sealed class UserFriendlyException : BaseException
{
    private static readonly string Code = "BAD_REQUEST";

    public UserFriendlyException(string message)
        : base(Code, message) { }

    public UserFriendlyException(string message, Exception exception)
        : base(Code, message, exception) { }
}
