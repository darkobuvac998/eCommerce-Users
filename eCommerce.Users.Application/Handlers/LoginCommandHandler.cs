using AutoMapper;
using eCommerce.Users.Application.Abstractions;
using eCommerce.Users.Application.Abstractions.Handlers;
using eCommerce.Users.Application.Commands;
using eCommerce.Users.Application.Response;
using eCommerce.Users.Domain.Contracts;
using eCommerce.Users.Domain.Entities;
using eCommerce.Users.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Users.Application.Handlers;

public sealed class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    private readonly IMapper _mapper;

    public LoginCommandHandler(
        IUserRepository userRepository,
        IJwtProvider jwtProvider,
        IMapper mapper
    )
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
        _mapper = mapper;
    }

    public async Task<LoginResponse> Handle(
        LoginCommand request,
        CancellationToken cancellationToken
    )
    {
        if (string.IsNullOrEmpty(request.Username) && string.IsNullOrEmpty(request.Email))
            throw new UserFriendlyException("Username or email must be provided");

        if (string.IsNullOrEmpty(request.Password))
            throw new UserFriendlyException("Password must be provider");

        User? user;
        if (!string.IsNullOrEmpty(request.Username))
        {
            user =
                (
                    await _userRepository
                        .GetByUsername(request.Username)
                        .FirstOrDefaultAsync(cancellationToken)
                ) ?? throw new ItemNotFoundException(typeof(User), request.Username);
        }
        else
        {
            user =
                (
                    await _userRepository
                        .GetByEmail(request.Email!)
                        .FirstOrDefaultAsync(cancellationToken)
                ) ?? throw new ItemNotFoundException(typeof(User), request.Email!);
        }

        var tokenResult = await _jwtProvider.GenerateTokenAsync(user, cancellationToken);

        return _mapper.Map<LoginResponse>(tokenResult);
    }
}
