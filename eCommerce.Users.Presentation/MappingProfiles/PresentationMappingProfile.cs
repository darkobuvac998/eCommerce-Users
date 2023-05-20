using AutoMapper;
using eCommerce.Users.Application.Commands;
using eCommerce.Users.Presentation.Requests;

namespace eCommerce.Users.Presentation.MappingProfiles;

public sealed class PresentationMappingProfile : Profile
{
    public PresentationMappingProfile()
    {
        CreateMap<LoginRequest, LoginCommand>();
        CreateMap<SignInRequest, SignInCommand>();
    }
}
