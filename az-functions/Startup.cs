using az_functions;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(az_functions.Startup))]
namespace az_functions
{
  
    public class Startup : FunctionsStartup
    {
         public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
            FunctionsHostBuilderContext context = builder.GetContext();
            builder.Services.AddScoped<HttpContextAccessor>();
        }
    }
}
