using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;

namespace eCommerce.Users.API.DependencyInjection;

public sealed class PresentationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddControllers()
            .AddApplicationPart(Presentation.AssemblyReference.Assembly)
            .AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();
            });

        services.AddAutoMapper(Presentation.AssemblyReference.Assembly);

        services.AddRouting(opt =>
        {
            opt.LowercaseUrls = true;
            opt.LowercaseQueryStrings = true;
        });

        services.Configure<MvcOptions>(opt =>
        {
            opt.AllowEmptyInputInBodyModelBinding = true;
        });

        services.AddSwaggerGen(conf =>
        {
            conf.DescribeAllParametersInCamelCase();
        });
    }
}
