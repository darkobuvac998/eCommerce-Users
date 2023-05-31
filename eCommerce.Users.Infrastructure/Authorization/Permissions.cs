namespace eCommerce.Users.Infrastructure.Authorization;

public static class Permissions
{
    public static class Permission
    {
        public const string Add = $"{Resources.Permissions}-{Scopes.Add}";
        public const string View = $"{Resources.Permissions}-{Scopes.View}";
        public const string Delete = $"{Resources.Permissions}-{Scopes.Delete}";
        public const string Edit = $"{Resources.Permissions}-{Scopes.Edit}";
        public const string AllScopes = $"{Resources.Permissions}-{Scopes.AllScopes}";
    }
}
