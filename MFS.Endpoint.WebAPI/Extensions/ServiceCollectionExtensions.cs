using AutoMapper;
using MFS.Application.Common;
using MFS.Application.Services.Commands.MerchantAggregate;
using MFS.Contract;
using MFS.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MFS.Endpoint.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddServiceRegistry(this IServiceCollection services)
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

            return services;
        }

        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MFSProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
