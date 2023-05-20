using eCommerce.Users.Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace eCommerce.Users.Infrastructure.OptionsSetup;

public class RedisOptionsSetup : IConfigureOptions<RedisOptions>
{
    private readonly IConfiguration _configuration;
    private const string SectionName = "Redis";

    public RedisOptionsSetup(IConfiguration configuration) => _configuration = configuration;

    public void Configure(RedisOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}
