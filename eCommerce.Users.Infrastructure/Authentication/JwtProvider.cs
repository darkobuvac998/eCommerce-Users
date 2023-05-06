﻿using eCommerce.Users.Application.Abstractions;
using eCommerce.Users.Application.Response;
using eCommerce.Users.Domain.Entities;
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

    public JwtProvider(IOptions<JwtOptions> jwtOptions, IPermissionService permissionService)
    {
        _jwtOptions = jwtOptions.Value;
        _permissionService = permissionService;
    }

    public async Task<JwtResult> GenerateTokenAsync(User user, CancellationToken cancellationToken)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Name, user.Username),
        };

        HashSet<string> permissions = await _permissionService.GetPermissionsAsync(
            user.Id,
            cancellationToken
        );

        foreach (var permission in permissions)
        {
            claims.Add(new(CustomClaims.Permissions, permission));
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var validFrom = DateTime.UtcNow;
        var validTo = DateTime.UtcNow.AddHours(_jwtOptions.ExpirationTime);

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