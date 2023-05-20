using eCommerce.Users.Application.Abstractions;
using eCommerce.Users.Application.Response;
using eCommerce.Users.Domain.Entities;
using eCommerce.Users.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eCommerce.Users.Infrastructure.Authentication;

public sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _jwtOptions;
    private readonly IPermissionService _permissionService;
    private readonly ICacheService _cacheService;
    private readonly IRoleService _roleService;

    public JwtProvider(
        IOptions<JwtOptions> jwtOptions,
        IPermissionService permissionService,
        ICacheService cacheService,
        IRoleService roleService
    )
    {
        _jwtOptions = jwtOptions.Value;
        _permissionService = permissionService;
        _cacheService = cacheService;
        _roleService = roleService;
    }

    public async Task<JwtResult> GenerateTokenAsync(User user, CancellationToken cancellationToken)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Name, user.Username),
        };

        List<string> roles = await _roleService.GetUserRolesAsync(user.Id, cancellationToken);

        foreach (var role in roles)
        {
            claims.Add(new(CustomClaims.Roles, role));
        }

        HashSet<string> permissions = await _permissionService.GetPermissionsAsync(
            user.Id,
            cancellationToken
        );

        //foreach (var permission in permissions)
        //{
        //    claims.Add(new(CustomClaims.Permissions, permission));
        //}

        var cacheKey = $"user[permissions]-{user.Id}";
        await _cacheService.SetAsync(
            cacheKey,
            permissions,
            TimeSpan.FromDays(_jwtOptions.ExpirationTime),
            cancellationToken
        );

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var validFrom = DateTime.UtcNow;
        var validTo = DateTime.UtcNow.AddDays(_jwtOptions.ExpirationTime);

        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            expires: validTo,
            signingCredentials: signingCredentials
        );

        string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return new()
        {
            Token = tokenValue,
            Username = user.Username!,
            ValidFrom = validFrom,
            ValidTo = token.ValidTo,
        };
    }
}
