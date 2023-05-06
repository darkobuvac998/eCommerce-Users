using eCommerce.Users.Application.Abstractions.Handlers;
using eCommerce.Users.Application.Commands;
using eCommerce.Users.Application.Response;
using eCommerce.Users.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Users.Application.Handlers;

public sealed class GetAllAvailablePermissionsCommandHandler
    : ICommandHandler<GetAllAvailablePermissionsCommand, AvailablePermissionsResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAvailablePermissionsCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AvailablePermissionsResponse> Handle(
        GetAllAvailablePermissionsCommand request,
        CancellationToken cancellationToken
    )
    {
        var scopes = await _unitOfWork.Scopes.Entity
            .AsNoTracking()
            .Select(x => x.Name)
            .Distinct()
            .ToListAsync(cancellationToken);

        var resources = await _unitOfWork.Resources.Entity
            .AsNoTracking()
            .Select(x => x.Name)
            .Distinct()
            .ToListAsync(cancellationToken);

        var result = new List<string>();

        foreach (var resource in resources)
        {
            foreach (var scope in scopes)
            {
                var permissionName = $"{resource}-{scope}";
                result.Add(permissionName);
            }
        }

        return new AvailablePermissionsResponse { Permissions = result };
    }
}
