using AutoMapper;
using eCommerce.Users.Application.Commands;
using eCommerce.Users.Application.Response;
using eCommerce.Users.Domain.Entities;

namespace eCommerce.Users.Application.MappingProfile;

public sealed class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<JwtResult, LoginResponse>();
        CreateMap<SignInCommand, User>();
        CreateMap<User, SignInResponse>();
    }
}
