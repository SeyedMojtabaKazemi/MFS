using MFS.Application.Services.Commands.MerchantAggregate;
using MFS.Contract;
using MFS.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace MFS.Endpoint.WebAPI.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void CustomExcpetionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public static void AddServiceRegistry(this IServiceCollection services)
        {

            var allContractLayerInterfaces = Assembly.GetAssembly(typeof(IMFSContext))
                                                            .GetTypes().Where(t => t.Namespace != null).ToList();

            var allInfrastructureLayerClasses = Assembly.GetAssembly(typeof(MFSContext))
                                                            .GetTypes().Where(t => t.Namespace != null).ToList();

            var allApplicationLayerClasses = Assembly.GetAssembly(typeof(MerchantServiceCommand))
                                                            .GetTypes().Where(t => t.Namespace != null).ToList();

            var allProviderClasses = allInfrastructureLayerClasses.Concat(allApplicationLayerClasses).ToList();

            foreach (var intfc in allContractLayerInterfaces.Where(t => t.IsInterface))
            {
                var impl = allProviderClasses.FirstOrDefault(c => c.IsClass && intfc.Name.Substring(1) == c.Name);
                if (impl != null)
                    services.AddScoped(intfc, impl);
            }
        }
    }
}
