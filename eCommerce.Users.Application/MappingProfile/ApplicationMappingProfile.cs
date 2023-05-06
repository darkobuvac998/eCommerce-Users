using AutoMapper;
using eCommerce.Users.Application.Response;

namespace eCommerce.Users.Application.MappingProfile;

public sealed class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<JwtResult, LoginResponse>();
    }
}
