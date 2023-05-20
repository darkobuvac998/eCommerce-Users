using AutoMapper;
using eCommerce.Users.Application.Abstractions;
using eCommerce.Users.Application.Abstractions.Handlers;
using eCommerce.Users.Application.Commands;
using eCommerce.Users.Application.Response;
using eCommerce.Users.Domain.Contracts;
using eCommerce.Users.Domain.Entities;

namespace eCommerce.Users.Application.Handlers;

public sealed class SignInCommandHandler : ICommandHandler<SignInCommand, SignInResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordService _passwordService;
    private readonly IMapper _mapper;

    public SignInCommandHandler(
        IUnitOfWork unitOfWork,
        IPasswordService passwordService,
        IMapper mapper
    ) => (_unitOfWork, _passwordService, _mapper) = (unitOfWork, passwordService, mapper);

    public async Task<SignInResponse> Handle(
        SignInCommand request,
        CancellationToken cancellationToken
    )
    {
        var user = _mapper.Map<User>(request);

        user.Password = _passwordService.HashPassword(request!.Password, out byte[] salt);
        user.Salt = salt;

        await _unitOfWork.Users.CreateUserAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<SignInResponse>(user);
    }
}
