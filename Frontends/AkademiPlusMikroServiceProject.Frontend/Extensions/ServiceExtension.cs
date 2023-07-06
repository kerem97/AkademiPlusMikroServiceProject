using AkademiPlusMikroServiceProject.Frontend.Models;
using AkademiPlusMikroServiceProject.Frontend.Services.Abstract;
using AkademiPlusMikroServiceProject.Frontend.Services.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AkademiPlusMikroServiceProject.Frontend.Extensions
{
    public static class ServiceExtension
    {
        public static void AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceApiSettings = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
            services.AddHttpClient<ICategoryService, ICategoryService>(opt =>
            {
                opt.BaseAddress = new System.Uri($"{serviceApiSettings.GatewayBaseUrl}/{serviceApiSettings.Catalog.Path}");
            });
        }
    }
}
